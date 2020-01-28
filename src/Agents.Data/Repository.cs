using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Agents.Data.Model;
using Newtonsoft.Json;

namespace Agents.Data
{
    public class Repository<T> : MockDataProvider<T>, IRepository<T> where T : EntityBase
    {
        public List<T> GetAll()
        {
            return Data;
        }

        public T GetById(int id)
        {
            return Data.FirstOrDefault(a => a.Id == id);
        }

        public void Create(T entity)
        {
            Data.Add(entity);
        }

        public void Delete(T entity)
        {
            Data.Remove(entity);
        }

        public void Update(T entity)
        {
            var index = Data.FindIndex(a => a.Id == entity.Id);
            Data[index] = entity;
        }

        public void Upsert(T entity)
        {
            if (entity.IsNew())
            {
                entity.Id = GenerateMockId();
                Create(entity);
            }
            else
            {
                var dbEntity = GetById(entity.Id);
                if(dbEntity != null)
                    Update(entity);
                else
                    throw new Exception($"Cannot update record that does not exist Id: {entity.Id}");
            }
        }
    }

    public class MockDataProvider<T> where T : EntityBase
    {
        private List<T> _data;

        protected List<T> Data => Get();

        private List<T> Get()
        {
            
            if (_data == null || _data.Count == 0)
                using (StreamReader file = File.OpenText(GetMockData($"{typeof(T).Name}s.json")))
                {
                    _data = JsonConvert.DeserializeObject<List<T>>(file.ReadToEnd());
                }

            return _data;
        }

        private static string GetMockData(string jsonFileName)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var jsonPath = Path.Combine(basePath, $"MockData/{jsonFileName}");
            return jsonPath;
        }

        protected int GenerateMockId()
        {
            return Data.Max(a => a.Id) + 1;
        }
    }
}