"""
Exemplo de uso do Notifique SDK para Python — WhatsApp, SMS, Email e template.
"""

from notifique import Notifique, NotifiqueApiError


def main():
    notifique = Notifique(api_key="your_api_key_here")
    instance_id = "your_instance_id_here"
    phone = "5511999999999"
    email = "user@example.com"

    print("--- Notifique Python SDK ---")

    # WhatsApp: texto (payload.message)
    print("\n1. WhatsApp texto...")
    res = notifique.whatsapp.send_text(instance_id, phone, "Olá do Python!")
    print("messageIds:", res.get("data", {}).get("messageIds"), "status:", res.get("data", {}).get("status"))

    # WhatsApp: imagem (mediaUrl, fileName, mimetype obrigatórios)
    print("\n2. WhatsApp imagem...")
    res = notifique.whatsapp.send(instance_id, {
        "to": [phone],
        "type": "image",
        "payload": {"mediaUrl": "https://placehold.co/600x400/png", "fileName": "image.png", "mimetype": "image/png"},
    })
    print("messageIds:", res.get("data", {}).get("messageIds"))

    # SMS
    print("\n3. SMS...")
    res = notifique.sms.send({"to": [phone], "message": "SMS de teste"})
    print("smsIds:", res.get("data", {}).get("smsIds"))

    # Email (use from_address; domínio deve estar verificado)
    print("\n4. Email...")
    res = notifique.email.send({
        "from": "noreply@seudominio.com",
        "to": [email],
        "subject": "Teste",
        "html": "<p>Olá!</p>",
    })
    print("emailIds:", res.get("data", {}).get("emailIds"))

    # Envio por template (whatsapp + sms + email)
    print("\n5. Template multi-canal...")
    res = notifique.messages.send({
        "to": [phone, email],
        "template": "welcome",
        "variables": {"name": "Trial", "credits": 300},
        "channels": ["whatsapp", "sms", "email"],
        "instanceId": instance_id,
        "from": "noreply@seudominio.com",
    })
    print("data:", res.get("data"))


if __name__ == "__main__":
    try:
        main()
    except NotifiqueApiError as e:
        print(f"Error: {e.status_code} - {e.message}")
        raise SystemExit(1)
