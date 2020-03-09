using Config;
using Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class TodoService
    {
        private readonly IMongoCollection<Todo> _Todos;

        public TodoService(IDbDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _Todos = database.GetCollection<Todo>(nameof(Todo));
        }

        public List<Todo> Get() =>
            _Todos.Find(Todo => true).ToList();

        public Todo Get(string id) =>
            _Todos.Find<Todo>(Todo => Todo.Id == id).FirstOrDefault();

        public Todo Create(Todo Todo)
        {
            _Todos.InsertOne(Todo);
            return Todo;
        }

        public void Update(string id, Todo TodoIn) =>
            _Todos.ReplaceOne(Todo => Todo.Id == id, TodoIn);

        public void Remove(Todo TodoIn) =>
            _Todos.DeleteOne(Todo => Todo.Id == TodoIn.Id);

        public void Remove(string id) => 
            _Todos.DeleteOne(Todo => Todo.Id == id);
    }
}