using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using livechat.Models;
using Newtonsoft.Json;

namespace livechat.Data
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetOne(string id);
    }

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly string data = null;

        public Repository()
        {
            var baseUrl = string.Concat("Data/", typeof(T).Name, "s", ".json");
            this.data = File.ReadAllText(baseUrl);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var entities = await LoadData();
            return entities;
        }

        public async Task<T> GetOne(string id)
        {
            var entities = await LoadData();
            return entities.FirstOrDefault(entity => entity.Id == id);
        }

        private async Task<IEnumerable<T>> LoadData()
        {
            await Task.Delay(0);
            return JsonConvert.DeserializeObject<IEnumerable<T>>(data);
        }

    }
}