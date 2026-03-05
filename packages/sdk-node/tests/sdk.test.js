"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
const axios_1 = __importDefault(require("axios"));
const src_1 = require("../src");
jest.mock('axios');
const mockedAxios = axios_1.default;
describe('Node.js SDK', () => {
    let notifique;
    beforeEach(() => {
        mockedAxios.create.mockReturnValue(mockedAxios);
        mockedAxios.isAxiosError.mockImplementation((payload) => !!payload?.isAxiosError);
        notifique = new src_1.Notifique({ apiKey: 'test-api-key' });
    });
    it('should send a whatsapp message correctly', async () => {
        const mockResponse = { data: { success: true, data: { messageIds: ['msg-123'], status: 'queued' } } };
        mockedAxios.post.mockResolvedValueOnce(mockResponse);
        const result = await notifique.whatsapp.send('instance-1', {
            to: ['5511999999999'],
            type: 'text',
            payload: { message: 'Test message' }
        });
        expect(mockedAxios.post).toHaveBeenCalledWith('/whatsapp/messages', expect.objectContaining({
            instanceId: 'instance-1',
            type: 'text',
            payload: { message: 'Test message' }
        }));
        expect(result.success).toBe(true);
        expect(result.data.messageIds).toContain('msg-123');
    });
    it('should send a simple text message via sendText shortcut', async () => {
        const mockResponse = { data: { success: true, data: { messageIds: ['msg-shortcut'], status: 'queued' } } };
        mockedAxios.post.mockResolvedValueOnce(mockResponse);
        const result = await notifique.whatsapp.sendText('instance-1', '5511999999999', 'Shortcut test');
        expect(mockedAxios.post).toHaveBeenCalledWith('/whatsapp/messages', expect.objectContaining({
            instanceId: 'instance-1',
            to: ['5511999999999'],
            type: 'text',
            payload: { message: 'Shortcut test' }
        }));
        expect(result.success).toBe(true);
        expect(result.data.messageIds).toContain('msg-shortcut');
    });
    it('should handle API errors gracefully', async () => {
        mockedAxios.post.mockRejectedValueOnce({
            isAxiosError: true,
            response: { data: { message: 'Invalid API Key' } }
        });
        await expect(notifique.whatsapp.send('instance-1', {
            to: ['5511999999999'],
            type: 'text',
            payload: { text: 'Test' }
        })).rejects.toThrow();
    });
});
