import { Pipe, PipeTransform } from '@angular/core';
import { Conversation } from '../models/conversation';

@Pipe({
    name: 'conversationFilter'
})

export class ConversationFilterPipe implements PipeTransform {

    transform(items: Conversation[], filter?: string): any {
        if (!items || !filter) {
            return items;
        }

        return items.filter(item => 
            item.recipient.toLowerCase().includes(filter.toLowerCase())
        );
    }

}
