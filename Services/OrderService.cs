using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TableauxApi.Models;

namespace TableauxApi.Services
{
    public class OrderService
    {
        private readonly IMongoCollection<Order> _orders;

        public OrderService(IConfiguration config)
        {
            var client = new MongoClient(config.GetConnectionString("TableauDb"));
            var database = client.GetDatabase("TableauDb");
            _orders = database.GetCollection<Order>("Order");
        }

        public Order Create(Order order)
        {
            _orders.InsertOne(order);
            return order;
        }
        public List<Order> Get()
        {
            return _orders.Find(order => true).ToList();
        }
    }
}
