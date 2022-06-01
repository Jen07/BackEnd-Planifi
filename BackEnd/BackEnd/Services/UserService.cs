
using System.Collections.Generic;
using Microsoft.Extensions.Options;
using BackEnd.Models;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace BackEnd.Services 
{
    public class UserService
    {
        private IMongoCollection<User> _users;

        public UserService(IUserSettings settings) {

            var client = new MongoClient(settings.Server);

            var database = client.GetDatabase(settings.Database);


            IMongoCollection<User> mongoCollection = database.GetCollection<User>(settings.Collection);
            _users = mongoCollection;

        }

        public object VerifyCredentials(string userName,string password)
        {
            var result = from d in _users.AsQueryable<User>()
                         where d.UserName == userName && d.Password == password
                         select d;

            if (result != null)
            {
                return result;//JsonSerializer.Serialize(result); //result.ToString(); //
            }
            else
            {
                return "no hay"; //JsonSerializer.Serialize("mesaje:Invalido");
            }
        }

            public List<User> AllUsers()
        {
            return _users.Find(d => true).ToList();
        }

        public User OneUser(string id)
        {
           return _users.Find(d => d.Id == id).First();
        }
        public User Create(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public void Update(string id, User user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
        }

        public void Delete(string id)
        {
            _users.DeleteOne(d => d.Id == id);
        }
    }
}

