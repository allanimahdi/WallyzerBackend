using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableauxApi.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace TableauxApi.Services
{
    public class TableauService
    {
        private readonly IMongoCollection<Tableau> _tableaux;
        public TableauService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("TableauDb"));
            var database = client.GetDatabase("TableauDb");
            _tableaux = database.GetCollection<Tableau>("Tableau");
        }
        public List<Tableau> Get()
        {
            return _tableaux.Find(tableau => true).ToList();
        }

        public Tableau Get(string id)
        {
            return _tableaux.Find<Tableau>(tableau => tableau.Id.Equals(id)).FirstOrDefault();
        }

        public Tableau Create(Tableau tableau)
        {
            _tableaux.InsertOne(tableau);
            return tableau;
        }

        public void Update(string id, Tableau tableauIn)
        {
            _tableaux.ReplaceOne(tableau => tableau.Id.Equals(id), tableauIn);
        }

        public void Remove(Tableau tableauIn)
        {
            _tableaux.DeleteOne(tableau => tableau.Id == tableauIn.Id);
        }

        public void Remove(string id)
        {
            _tableaux.DeleteOne(tableau => tableau.Id.Equals(id));
        }
    }
}
