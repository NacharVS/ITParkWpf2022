using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITParkWPF
{
    class User
    {
        public User(string name, string login, string email, string phoneNumber)
        {
            Name = name;
            Login = login;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public ObjectId _id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static void AddProductToDatabase(string name, string login, string email, string phone)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("Users");
            collection.InsertOne(new User(login, name, email, phone));

        }

        public static List<string> GetUserList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("Users");
            var listUserFromBD = collection.Find(x => true).ToList();
            List<string> listToReturn = new List<string>();
            foreach (var item in listUserFromBD)
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

        public static void ReplaceUser(string name, User newInfo)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registrtion");
            var collection = database.GetCollection<User>("Users");
            collection.ReplaceOne(x => x.Name == name, newInfo);
        }
    }
}
