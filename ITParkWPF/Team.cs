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
    class Team
    {
        public Team(string teamName, string teammate1, string teammate2, string teammate3, string teammate4, string teammate5)
        {
            TeamName = teamName;
            Teammate1 = teammate1;
            Teammate2 = teammate2;
            Teammate3 = teammate3;
            Teammate4 = teammate4;
            Teammate5 = teammate5;
        }
        [BsonIgnoreIfDefault]
        public ObjectId _id { get; set; }
        public string TeamName { get; set; }

        public string Teammate1 { get; set; }
        public string Teammate2 { get; set; }
        public string Teammate3 { get; set; }
        public string Teammate4 { get; set; }
        public string Teammate5 { get; set; }

        public static void AddTeamToDB(Team team)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<Team>("Teams");
            collection.InsertOne(team);
        }
        public static List<string> GetTeamList()
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<Team>("Teams");
            var listUsersFromDB = collection.Find(x => true).ToList();
            List<string> listToReturn = new List<string>();
            foreach (var item in listUsersFromDB)
            {
                listToReturn.Add(item.TeamName);
            }
            return listToReturn;
        }

        public static Team GetTeam(string teamName)
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<Team>("Teams");
            var foundedUser = collection.Find(x => x.TeamName == teamName).FirstOrDefault();
            return foundedUser;
        }

        public static void AddCustom() 
        {
            var client = new MongoClient("mongodb://localhost");
            var database = client.GetDatabase("Registration");
            var collection = database.GetCollection<Team>("Teams");
        }


        // Реализовать функцию приложения добавление игрока вручную (Add Сustom). Выбраный из ссписка Users игрок добавляется
        // на первое свободное место в команде. До тех, пока команла не будет заполнена. Нельзя добавить команду в базу,
        // если в ней менне 5 игроков.
        // Добавить функцию удаления одного игрока из команды, по аналогии с добавлением.
        // Нельзя добить одно и того же игрока в 1 команду.

    }
}
