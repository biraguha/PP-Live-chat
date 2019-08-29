using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using livechat.Data;
using livechat.Models;
using livechat.ViewModels;

namespace livechat.Services
{
    public interface IConversationService
    {
        Task<IEnumerable<ConversationVM>> GetConversations(string id);
    }

    public class ConversationService : IConversationService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Conversation> repositoryConv;
        private readonly IRepository<User> repositoryUser;

        public ConversationService(
            IMapper mapper,
            IRepository<Conversation> repositoryConv,
            IRepository<User> repositoryUser)
        {
            this.repositoryConv = repositoryConv;
            this.repositoryUser = repositoryUser;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ConversationVM>> GetConversations(string id)
        {
            var dbConvs = await repositoryConv.GetAll();
            var dbUsers = await repositoryUser.GetAll();
            var convs = dbConvs.Where(conv => conv.Authors.Contains(id));
            var users = mapper.Map<IEnumerable<UserVM>>(dbUsers);

            var convAuthors = new Dictionary<string, IEnumerable<UserVM>>();
            foreach (var conv in convs)
                convAuthors[conv.Id] = users.Where(
                    u => conv.Authors.Contains(u.Id)
                );
 
            var newConvs = mapper.Map<IEnumerable<ConversationVM>>(convs);
            foreach (var conv in newConvs)
            {
                var authors = convAuthors[conv.Id].Where(a => a.Id != id);
                conv.Authors = authors;
                conv.Recipient = string.Join(", ", authors.Select(a => a.FullName));
            }

            return newConvs;
        }

    }
}