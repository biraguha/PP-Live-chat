
export interface Message {
    id: number;
    author: number;
    recipient: number;
    content: string;
    created_at: Date;
    update_at: Date;
}