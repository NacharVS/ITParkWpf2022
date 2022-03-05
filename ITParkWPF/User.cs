﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
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
        public User(string login, string name, string email, string phoneNumber)
        {
            Login = login;
            Name = name;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        [BsonId]
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public static void AddToDB(string login, string name, string email, string phone)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("Users");
            collection.InsertOne(new User(login, name, email, phone));
        }

        public static List<string> GetLoginList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("Users");
            var listUsersFromDB = collection.Find(x => true).ToList();
            List<string> listToReturn = new List<string>();
            foreach (var item in listUsersFromDB)
            {
                listToReturn.Add(item.Login);
            }
            return listToReturn;
        }
        public static User GetUser(string login)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("Users");
            var foundedUser = collection.Find(x => x.Login == login).FirstOrDefault();
            return foundedUser;
        }

        public static void ReplaceOne(string login, string name, string email, string phoneNumber, User newinfo)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<User>("Users");
            collection.ReplaceOne(x => x.Login == login, newinfo);
            collection.ReplaceOne(x => x.Name == name, newinfo);
            collection.ReplaceOne(x => x.Email == email, newinfo);
            collection.ReplaceOne(x => x.PhoneNumber == phoneNumber, newinfo);
        }
        // Реализовать кнопку редактирования уже существующего пользователя

    }
}
