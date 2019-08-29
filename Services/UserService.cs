
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using livechat.Data;
using livechat.Models;
using livechat.ViewModels;

namespace livechat.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserVM>> GetUsers();
        Task<UserVM> GetUser(string id);
        Task<UserVM> UserExist(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly IMapper mapper;
        private readonly IRepository<User> repository;

        public UserService(
            IMapper mapper,
            IRepository<User> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<IEnumerable<UserVM>> GetUsers()
        {
            var users = await repository.GetAll();
            return mapper.Map<IEnumerable<UserVM>>(users);
        }

        public async Task<UserVM> GetUser(string id)
        {
            var user = await repository.GetOne(id);
            return mapper.Map<UserVM>(user);
        }

        public async Task<UserVM> UserExist(string username, string password)
        {
            var users = await repository.GetAll();
            var user = users.FirstOrDefault(u => 
                u.UserName == username &&
                u.Password == password
            );

            return user != null ? mapper.Map<UserVM>(user) : null;
        }
    }
}