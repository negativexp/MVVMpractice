using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Windows;
using MongoDB.Bson;

namespace WpfAppMVVMdatagridOperations.DataAccess
{
    //operations in database

    class PersonRepo
    {
        string connectionString = "mongodb://localhost:27017";
        string databaseName = "testing_db";
        string CollectionName = "People";

        MongoHelper database;

        public PersonRepo()
        {
            database = new MongoHelper(connectionString, databaseName);
        }

        public void AddPerson(Models.Person person)
        {
            database.InsertDocument(CollectionName, person);
        }

        public void DeletePerson(ObjectId id)
        {
            database.DeleteDocument<Models.Person>("People", id);
        }

        public List<Models.Person> GetAll()
        {
            return database.LoadAllDocuments<Models.Person>("People");
        }
    }
}
