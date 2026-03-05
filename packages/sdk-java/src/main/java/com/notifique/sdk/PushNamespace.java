package com.notifique.sdk;

/**
 * Push API: apps, devices, messages.
 */
public class PushNamespace {
    public final PushAppsNamespace apps;
    public final PushDevicesNamespace devices;
    public final PushMessagesNamespace messages;

    public PushNamespace(Notifique client) {
        this.apps = new PushAppsNamespace(client);
        this.devices = new PushDevicesNamespace(client);
        this.messages = new PushMessagesNamespace(client);
    }
}
