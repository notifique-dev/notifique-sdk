package com.notifique.sdk;

import com.notifique.sdk.model.*;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.ArgumentCaptor;

import java.net.http.HttpClient;
import java.net.http.HttpRequest;
import java.net.http.HttpResponse;
import java.util.List;
import java.util.Map;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.*;

class NotifiqueTest {
    private Notifique notifique;
    private HttpClient mockHttpClient;
    private HttpResponse<String> mockResponse;

    @BeforeEach
    @SuppressWarnings("unchecked")
    void setUp() throws Exception {
        mockHttpClient = mock(HttpClient.class);
        mockResponse = mock(HttpResponse.class);
        notifique = new Notifique("test-api-key", "https://api.notifique.dev/v1", mockHttpClient);
    }

    // --- WhatsApp ---

    @Test
    @SuppressWarnings("unchecked")
    void testWhatsAppSendTextSuccess() throws Exception {
        String jsonResponse = "{\"success\": true, \"data\": {\"messageIds\": [\"msg-123\"], \"status\": \"QUEUED\"}}";
        when(mockResponse.statusCode()).thenReturn(202);
        when(mockResponse.body()).thenReturn(jsonResponse);
        doReturn(mockResponse).when(mockHttpClient).send(any(HttpRequest.class), any(HttpResponse.BodyHandler.class));

        WhatsAppSendEnvelope response = notifique.whatsapp.sendText("instance-1", "5511999999999", "Hello");

        assertEquals(List.of("msg-123"), response.getData().getMessageIds());
        assertEquals("QUEUED", response.getData().getStatus());

        ArgumentCaptor<HttpRequest> requestCaptor = ArgumentCaptor.forClass(HttpRequest.class);
        verify(mockHttpClient).send(requestCaptor.capture(), any());
        HttpRequest req = requestCaptor.getValue();
        assertEquals("POST", req.method());
        assertEquals("https://api.notifique.dev/v1/whatsapp/messages", req.uri().toString());
        assertTrue(req.bodyPublisher().isPresent());
    }

    @Test
    @SuppressWarnings("unchecked")
    void testWhatsAppSendErrorThrows() throws Exception {
        when(mockResponse.statusCode()).thenReturn(400);
        when(mockResponse.body()).thenReturn("{\"error\": \"Invalid instance\"}");
        doReturn(mockResponse).when(mockHttpClient).send(any(HttpRequest.class), any(HttpResponse.BodyHandler.class));

        assertThrows(NotifiqueApiException.class, () ->
                notifique.whatsapp.sendText("wrong", "123", "hi"));
    }

    @Test
    @SuppressWarnings("unchecked")
    void testWhatsAppSendWithParams() throws Exception {
        when(mockResponse.statusCode()).thenReturn(202);
        when(mockResponse.body()).thenReturn("{\"success\": true, \"data\": {\"messageIds\": [\"m1\"], \"status\": \"QUEUED\"}}");
        doReturn(mockResponse).when(mockHttpClient).send(any(), any());

        WhatsAppSendParams params = new WhatsAppSendParams();
        params.setTo(List.of("5511888888888"));
        params.setType("text");
        params.setPayload(new WhatsAppPayloads.TextPayload("Hi"));
        WhatsAppSendEnvelope res = notifique.whatsapp.send("instance-1", params);
        assertEquals(List.of("m1"), res.getData().getMessageIds());
    }

    @Test
    @SuppressWarnings("unchecked")
    void testWhatsAppGetMessage() throws Exception {
        when(mockResponse.statusCode()).thenReturn(200);
        when(mockResponse.body()).thenReturn("{\"success\": true, \"data\": {\"messageId\": \"msg-1\", \"status\": \"DELIVERED\"}}");
        doReturn(mockResponse).when(mockHttpClient).send(any(), any());

        WhatsAppMessageEnvelope envelope = notifique.whatsapp.getMessage("msg-1");
        assertEquals("msg-1", envelope.getData().getMessageId());
        assertEquals("DELIVERED", envelope.getData().getStatus());
    }

    @Test
    @SuppressWarnings("unchecked")
    void testWhatsAppListInstances() throws Exception {
        when(mockResponse.statusCode()).thenReturn(200);
        when(mockResponse.body()).thenReturn("{\"success\": true, \"data\": [], \"pagination\": {\"total\": 0, \"page\": 1, \"limit\": 10}}");
        doReturn(mockResponse).when(mockHttpClient).send(any(), any());

        WhatsAppInstanceListResponse list = notifique.whatsapp.listInstances();
        assertNotNull(list);
    }

    // --- SMS ---

    @Test
    @SuppressWarnings("unchecked")
    void testSmsSend() throws Exception {
        when(mockResponse.statusCode()).thenReturn(200);
        when(mockResponse.body()).thenReturn("{\"success\": true, \"data\": {\"status\": \"queued\", \"count\": 1, \"smsIds\": [\"sms-1\"]}}");
        doReturn(mockResponse).when(mockHttpClient).send(any(), any());

        SmsSendParams params = new SmsSendParams(List.of("5511999999999"), "Test SMS");
        SmsSendResponse res = notifique.sms.send(params);
        assertTrue(res.isSuccess());
        assertEquals(List.of("sms-1"), res.getData().getSmsIds());
    }

    @Test
    @SuppressWarnings("unchecked")
    void testSmsGet() throws Exception {
        when(mockResponse.statusCode()).thenReturn(200);
        when(mockResponse.body()).thenReturn("{\"success\": true, \"data\": {\"smsId\": \"sms-1\", \"status\": \"delivered\"}}");
        doReturn(mockResponse).when(mockHttpClient).send(any(), any());

        SmsStatusResponse status = notifique.sms.get("sms-1");
        assertEquals("sms-1", status.getData().getSmsId());
    }

    @Test
    @SuppressWarnings("unchecked")
    void testSmsCancel() throws Exception {
        when(mockResponse.statusCode()).thenReturn(200);
        when(mockResponse.body()).thenReturn("{\"success\": true, \"data\": {\"smsId\": \"sms-1\", \"status\": \"cancelled\"}}");
        doReturn(mockResponse).when(mockHttpClient).send(any(), any());

        SmsCancelResponse res = notifique.sms.cancel("sms-1");
        assertTrue(res.isSuccess());
        assertEquals("sms-1", res.getData().getSmsId());
    }

    // --- Email ---

    @Test
    @SuppressWarnings("unchecked")
    void testEmailSend() throws Exception {
        when(mockResponse.statusCode()).thenReturn(200);
        when(mockResponse.body()).thenReturn("{\"success\": true, \"data\": {\"emailIds\": [\"email-1\"], \"status\": \"queued\"}}");
        doReturn(mockResponse).when(mockHttpClient).send(any(), any());

        EmailSendParams params = new EmailSendParams();
        params.setFrom("noreply@example.com");
        params.setTo(List.of("user@example.com"));
        params.setSubject("Test");
        params.setText("Body");
        EmailSendResponse res = notifique.email.send(params);
        assertEquals(List.of("email-1"), res.getData().getEmailIds());
    }

    @Test
    @SuppressWarnings("unchecked")
    void testEmailCancel() throws Exception {
        when(mockResponse.statusCode()).thenReturn(200);
        when(mockResponse.body()).thenReturn("{\"success\": true, \"data\": {\"emailId\": \"email-1\", \"status\": \"cancelled\"}}");
        doReturn(mockResponse).when(mockHttpClient).send(any(), any());

        EmailCancelResponse res = notifique.email.cancel("email-1");
        assertTrue(res.isSuccess());
    }

    // --- Messages (templates) ---

    @Test
    @SuppressWarnings("unchecked")
    void testMessagesSend() throws Exception {
        when(mockResponse.statusCode()).thenReturn(200);
        when(mockResponse.body()).thenReturn("{\"success\": true, \"data\": {\"messageIds\": [\"m1\", \"m2\"], \"status\": \"queued\"}}");
        doReturn(mockResponse).when(mockHttpClient).send(any(), any());

        MessagesSendParams params = new MessagesSendParams();
        params.setTo(List.of("5511999999999"));
        params.setTemplate("welcome");
        params.setVariables(Map.of("name", "User"));
        params.setChannels(List.of("whatsapp", "sms"));
        params.setInstanceId("inst-1");
        MessagesSendResponse res = notifique.messages.send(params);
        assertEquals(List.of("m1", "m2"), res.getData().getMessageIds());
    }
}
