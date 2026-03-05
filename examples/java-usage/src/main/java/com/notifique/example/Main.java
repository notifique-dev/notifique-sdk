package com.notifique.example;

import com.notifique.sdk.Notifique;
import com.notifique.sdk.model.*;

import java.util.List;

public class Main {
    public static void main(String[] args) {
        Notifique notifique = new Notifique("your_api_key_here");

        String instanceId = "your_instance_id_here";
        String recipient = "5511999999999";

        System.out.println("--- Notifique Java SDK Example ---");

        System.out.println("\n1. Sending text...");
        WhatsAppSendEnvelope res1 = notifique.whatsapp.sendText(instanceId, recipient, "Hello from Java! ☕");
        System.out.println("Result: Success=" + res1.isSuccess() + ", MessageIDs=" + res1.getData().getMessageIds());

        System.out.println("\n2. Sending image...");
        WhatsAppSendParams imageParams = new WhatsAppSendParams();
        imageParams.setTo(List.of(recipient));
        imageParams.setType("image");
        imageParams.setPayload(new WhatsAppPayloads.MediaPayload("https://placehold.co/600x400/png", "image.png", "image/png"));
        WhatsAppSendEnvelope res2 = notifique.whatsapp.send(instanceId, imageParams);
        System.out.println("Result: Success=" + res2.isSuccess());
    }
}
