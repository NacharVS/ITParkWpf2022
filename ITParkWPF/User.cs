using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITParkWPF
{
    internal class User
    {
        public User(string name, string login, string email, string phoneNumber)
        {
            Name = name;
            Login = login;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static void AddToDB(string name, string login, string email, string phoneNumber)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registrtion");
            var collection = database.GetCollection<User>("Users");
            collection.InsertOne(new User(name, login, email, phoneNumber));
        }


        public static List<string> GetLoginList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registrtion");
            var collection = database.GetCollection<User>("Users");
            var listUserFromDB = collection.Find(x => true).ToList();
            List<string> listToReturn = new();
            foreach (var item in listUserFromDB)
            {
                listToReturn.Add(item.Login);
            }
            return listToReturn;
        }

        public static User GetUser(string name)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registrtion");
            var collection = database.GetCollection<User>("Users");
            var FoundUser = collection.Find(x => x.Name == name).FirstOrDefault();

            return FoundUser;
        }

        public static void UpdateUser(string name, User newInfo)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registrtion");
            var collection = database.GetCollection<User>("Users");
            collection.ReplaceOne(x => x.Name == name, newInfo);
        }

    }
}
