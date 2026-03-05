"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const sdk_node_1 = require("@notifique/sdk-node");

async function main() {
  const notifique = new sdk_node_1.Notifique({ apiKey: 'your_api_key_here' });
  const instanceId = 'your_instance_id_here';
  const myPhoneNumber = '5511999999999';

  console.log('--- Notifique SDK WhatsApp Example ---');

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

    console.log('\nSending image...');
    const imageRes = await notifique.whatsapp.send(instanceId, {
      to: [myPhoneNumber],
      type: 'image',
      payload: { mediaUrl: 'https://placehold.co/600x400/png', fileName: 'image.png', mimetype: 'image/png' },
    });
    console.log('Result:', imageRes.data?.messageIds);
  } catch (error) {
    console.error('Error:', error);
  }
}

main();
