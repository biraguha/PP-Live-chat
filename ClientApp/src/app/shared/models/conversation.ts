import { Message } from './message';
import { User } from './user';

export interface Conversation {
    id: string;
    recipient: string;
    authors: Array<User>;
    messages: Array<Message>;
    created_at: Date;
    update_at: Date;
}