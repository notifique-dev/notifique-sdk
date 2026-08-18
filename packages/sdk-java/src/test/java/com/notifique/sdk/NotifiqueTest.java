package com.notifique.sdk;

import com.notifique.sdk.model.*;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;

import java.util.List;
import java.util.Map;

import static org.junit.jupiter.api.Assertions.*;

class NotifiqueTest {
    private Notifique notifique;
    private FakeHttpExecutor fakeHttp;

    @BeforeEach
    void setUp() {
        fakeHttp = new FakeHttpExecutor();
        notifique = new Notifique("test-api-key", "https://api.notifique.dev/v1", fakeHttp);
    }

    @Test
    void testWhatsAppSendTextSuccess() {
        fakeHttp.setResponse(202, "{\"success\": true, \"data\": {\"messageIds\": [\"msg-123\"], \"status\": \"QUEUED\"}}");

        WhatsAppSendEnvelope response = notifique.whatsapp.sendText("instance-1", "5511999999999", "Hello");

        assertEquals(List.of("msg-123"), response.getData().getMessageIds());
        assertEquals("QUEUED", response.getData().getStatus());
        assertEquals("POST", fakeHttp.lastRequest.method());
        assertEquals("https://api.notifique.dev/v1/whatsapp/messages", fakeHttp.lastRequest.uri().toString());
    }

    @Test
    void testWhatsAppSendWithParams() {
        fakeHttp.setResponse(202, "{\"success\": true, \"data\": {\"messageIds\": [\"m1\"], \"status\": \"QUEUED\"}}");

        WhatsAppSendParams params = new WhatsAppSendParams();
        params.setTo(List.of("5511999999999"));
        params.setType("text");
        params.setPayload(Map.of("message", "Hi"));

        notifique.whatsapp.send("instance-1", params);

        assertEquals("POST", fakeHttp.lastRequest.method());
    }

    @Test
    void testWhatsAppSendErrorThrows() {
        fakeHttp.setResponse(400, "{\"success\":false,\"message\":\"Bad request\"}");

        assertThrows(NotifiqueApiException.class, () ->
                notifique.whatsapp.sendText("instance-1", "5511999999999", "Hello"));
    }

    @Test
    void testWhatsAppGetMessage() {
        fakeHttp.setResponse(200, "{\"success\": true, \"data\": {\"messageId\": \"msg-1\", \"to\": \"5511\", \"type\": \"text\", \"status\": \"SENT\"}}");

        WhatsAppMessageEnvelope response = notifique.whatsapp.getMessage("msg-1");
        assertEquals("msg-1", response.getData().getMessageId());
    }

    @Test
    void testWhatsAppListInstances() {
        fakeHttp.setResponse(200, "{\"success\": true, \"data\": []}");

        WhatsAppInstanceListResponse response = notifique.whatsapp.listInstances();
        assertTrue(response.isSuccess());
    }

    @Test
    void testSmsSend() {
        fakeHttp.setResponse(202, "{\"success\": true, \"data\": {\"smsIds\": [\"sms-1\"], \"status\": \"QUEUED\"}}");

        SmsSendResponse response = notifique.sms.send(new SmsSendParams(List.of("5511"), "text"));
        assertEquals(List.of("sms-1"), response.getData().getSmsIds());
    }

    @Test
    void testEmailSend() {
        fakeHttp.setResponse(202, "{\"success\": true, \"data\": {\"messageIds\": [\"e1\"], \"status\": \"QUEUED\", \"count\": 1}}");

        EmailSendParams params = new EmailSendParams();
        params.setFrom("noreply@example.com");
        params.setTo(List.of("user@example.com"));
        params.setSubject("Hi");
        params.setHtml("<p>Hi</p>");

        EmailSendResponse response = notifique.email.send(params);
        assertEquals(List.of("e1"), response.getData().getMessageIds());
    }

    @Test
    void testMessagesSend() {
        fakeHttp.setResponse(202, "{\"success\": true, \"data\": {\"messageIds\": [\"m1\"]}}");

        MessagesSendParams params = new MessagesSendParams();
        params.setTo(List.of("5511"));
        params.setTemplate("welcome");
        params.setChannels(List.of("whatsapp"));

        MessagesSendResponse response = notifique.messages.send(params);
        assertEquals(List.of("m1"), response.getData().getMessageIds());
    }
}
