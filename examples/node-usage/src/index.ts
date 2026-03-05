import { Notifique, NotifiqueApiError } from '@notifique/sdk-node';

/**
 * Notifique SDK — WhatsApp (alinhado à API)
 *
 * Run: npm run build (monorepo root), then npm start (here)
 * Set NOTIFIQUE_API_KEY e NOTIFIQUE_INSTANCE_ID para chamar a API.
 * Respostas e erros vêm em camelCase; erros são NotifiqueApiError com statusCode e message.
 */

async function main() {
  const apiKey = process.env.NOTIFIQUE_API_KEY || 'your_api_key_here';
  const instanceId = process.env.NOTIFIQUE_INSTANCE_ID || 'your_instance_id_here';
  const myPhoneNumber = process.env.MY_PHONE || '5511999999999';

  if (apiKey === 'your_api_key_here' || instanceId === 'your_instance_id_here') {
    console.log('Dica: defina NOTIFIQUE_API_KEY e NOTIFIQUE_INSTANCE_ID para chamar a API de verdade.');
  }

  const notifique = new Notifique({ apiKey });

  console.log('--- Notifique SDK WhatsApp Example ---\n');

  try {
    console.log('Sending text (sendText)...');
    const simpleRes = await notifique.whatsapp.sendText(instanceId, myPhoneNumber, 'Simple hello! 👋');
    console.log('Result:', simpleRes.data?.messageIds, simpleRes.data?.status);

    console.log('\nSending text (send)...');
    const textRes = await notifique.whatsapp.send(instanceId, {
      to: [myPhoneNumber],
      type: 'text',
      payload: { message: 'Hello from Notifique! 🚀' },
    });
    console.log('Result:', textRes.data?.messageIds);

    // Imagem: use URL pública e direta (sem redirect, sem login). placehold.co às vezes não é exibida no WhatsApp.
    console.log('\nSending image...');
    const imageRes = await notifique.whatsapp.send(instanceId, {
      to: [myPhoneNumber],
      type: 'image',
      payload: {
        mediaUrl: 'https://static.wixstatic.com/media/082347_8e0de42df3924a62b4bada32eebaf087~mv2.png',
        fileName: 'image.png',
        mimetype: 'image/png',
        caption: 'Notifique Logo',
      },
    });
    console.log('Result:', imageRes.data?.messageIds);

    console.log('\nDone.');
  } catch (err: unknown) {
    if (err instanceof NotifiqueApiError) {
      console.error(`Error: ${err.statusCode} - ${err.message}`);
    } else {
      console.error('Error:', err instanceof Error ? err.message : String(err));
    }
  }
}

main();
