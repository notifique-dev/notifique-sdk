defmodule NotifiqueTest do
  use ExUnit.Case

  setup do
    client = Notifique.new("test-key")
    {:ok, client: client}
  end

  test "client initialization", %{client: client} do
    assert client.api_key == "test-key"
    assert client.base_url == "https://api.notifique.dev/v1"
  end

  describe "WhatsApp" do
    test "send_text success", %{client: client} do
      adapter = fn %Req.Request{} = req ->
        assert req.method == :post
        assert to_string(req.url) =~ "whatsapp/messages"
        body = req.options[:json]
        assert body["instanceId"] == "instance-1"
        assert body["payload"]["message"] == "Hello"
        {req, Req.Response.new(status: 200, body: %{"messageIds" => ["msg-123"], "status" => "queued"})}
      end

      {:ok, response} = Notifique.Whatsapp.send_text(client, "instance-1", "5511999999999", "Hello", adapter: adapter)
      assert response["messageIds"] == ["msg-123"]
      assert response["status"] == "queued"
    end

    test "send_text error returns status and body", %{client: client} do
      adapter = fn req ->
        {req, Req.Response.new(status: 400, body: %{"error" => "Invalid instance"})}
      end

      assert {:error, %{status: 400, body: body}} = Notifique.Whatsapp.send_text(client, "x", "1", "hi", adapter: adapter)
      assert body["error"] == "Invalid instance"
    end

    test "send with params", %{client: client} do
      adapter = fn req -> {req, Req.Response.new(status: 200, body: %{"messageIds" => ["m1"], "status" => "queued"})} end

      params = %{
        "to" => ["5511888888888"],
        "type" => "text",
        "payload" => %{"message" => "Hi"}
      }

      {:ok, resp} = Notifique.Whatsapp.send(client, "instance-1", params, adapter: adapter)
      assert resp["messageIds"] == ["m1"]
    end

    test "get_message", %{client: client} do
      adapter = fn %Req.Request{} = req ->
        assert to_string(req.url) =~ "whatsapp/messages/msg-1"
        {req, Req.Response.new(status: 200, body: %{"messageId" => "msg-1", "status" => "delivered"})}
      end

      {:ok, status} = Notifique.Whatsapp.get_message(client, "msg-1", adapter: adapter)
      assert status["messageId"] == "msg-1"
      assert status["status"] == "delivered"
    end

    test "list_instances", %{client: client} do
      adapter = fn req -> {req, Req.Response.new(status: 200, body: %{"success" => true, "data" => [], "pagination" => %{}})} end
      {:ok, list} = Notifique.Whatsapp.list_instances(client, %{}, adapter: adapter)
      assert list["success"] == true
    end
  end

  describe "SMS" do
    test "send", %{client: client} do
      adapter = fn %Req.Request{} = req ->
        assert to_string(req.url) =~ "sms/messages"
        assert req.options[:json]["to"] == ["5511999999999"]
        {req, Req.Response.new(status: 200, body: %{"success" => true, "data" => %{"smsIds" => ["sms-1"], "status" => "queued"}})}
      end

      {:ok, resp} = Notifique.Sms.send(client, %{"to" => ["5511999999999"], "message" => "Test"}, adapter: adapter)
      assert resp["data"]["smsIds"] == ["sms-1"]
    end

    test "get", %{client: client} do
      adapter = fn req -> {req, Req.Response.new(status: 200, body: %{"success" => true, "data" => %{"smsId" => "sms-1", "status" => "delivered"}})} end
      {:ok, resp} = Notifique.Sms.get(client, "sms-1", adapter: adapter)
      assert resp["data"]["smsId"] == "sms-1"
    end

    test "cancel", %{client: client} do
      adapter = fn req -> {req, Req.Response.new(status: 200, body: %{"success" => true, "data" => %{"smsId" => "sms-1", "status" => "cancelled"}})} end
      {:ok, resp} = Notifique.Sms.cancel(client, "sms-1", adapter: adapter)
      assert resp["success"] == true
      assert resp["data"]["status"] == "cancelled"
    end
  end

  describe "Email" do
    test "send", %{client: client} do
      adapter = fn req ->
        {req, Req.Response.new(status: 200, body: %{"success" => true, "data" => %{"emailIds" => ["email-1"], "status" => "queued"}})}
      end

      params = %{"from" => "noreply@example.com", "to" => ["u@example.com"], "subject" => "Test", "text" => "Body"}
      {:ok, resp} = Notifique.Email.send(client, params, adapter: adapter)
      assert resp["data"]["emailIds"] == ["email-1"]
    end

    test "cancel", %{client: client} do
      adapter = fn req -> {req, Req.Response.new(status: 200, body: %{"success" => true, "data" => %{"emailId" => "email-1", "status" => "cancelled"}})} end
      {:ok, resp} = Notifique.Email.cancel(client, "email-1", adapter: adapter)
      assert resp["success"] == true
    end
  end

  describe "Messages" do
    test "send", %{client: client} do
      adapter = fn %Req.Request{} = req ->
        assert to_string(req.url) =~ "templates/send"
        body = req.options[:json]
        assert body["template"] == "welcome"
        assert body["channels"] == ["whatsapp", "sms"]
        {req, Req.Response.new(status: 200, body: %{"success" => true, "data" => %{"messageIds" => ["m1", "m2"], "status" => "queued"}})}
      end

      params = %{
        "to" => ["5511999999999"],
        "template" => "welcome",
        "variables" => %{"name" => "User"},
        "channels" => ["whatsapp", "sms"],
        "instance_id" => "inst-1"
      }

      {:ok, resp} = Notifique.Messages.send(client, params, adapter: adapter)
      assert resp["data"]["messageIds"] == ["m1", "m2"]
    end
  end
end
