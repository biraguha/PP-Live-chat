import { Message } from './message';

export interface Conversation {
    id: number;
    author: string;
    recipient: string;
    messages: Array<Message>;
    update_at: Date;
}