using DemoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;
using Newtonsoft.Json.Linq;
using System.Web.Http.Cors;

namespace DemoWebAPI.Controllers
{

    [EnableCors(
        origins: "*", 
        headers: "Access-Control-Allow-Origin,Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With",
        methods: "GET, POST, PUT, DELETE, OPTIONS")]
    [RoutePrefix("")]
    public class UsersController : ApiController
    {
        //List<Person> people = new List<Person>();

        //public UsersController() { //always initiallize
        //    people.Add(new Person { FirstName = "Linor", LastName = "Avny" });
        //    people.Add(new Person { FirstName = "Linor2", LastName = "Avny2" });
        //    people.Add(new Person { FirstName = "Linor3", LastName = "Avny3" });
        //}

        //private static List<Person> studentsLst = new List<Person>() {
        //    new Person { FirstName = "Linor", LastName = "Avny" },
        //    new Person { FirstName = "Yoav", LastName = "Bar" },
        //    new Person { FirstName = "Roni", LastName = "Cohen" },
        //    new Person { FirstName = "Suzi", LastName = "Boom" },
        //    new Person { FirstName = "Guy", LastName = "Roby" },
        //};

        private static string path = "C:/Dev/linorGIT/RestWebAPI/DemoWebAPI/App_Data/";

        private string getUsersJson() {
            string ret = System.IO.File.ReadAllText(path + "users.json");
            return ret;
        }

        // GET
        // postman: http://localhost:50731/api/users/GetAll
        [HttpGet]
        [ActionName("getUsers")]
        public HttpResponseMessage getUsersFromJsonFile()
        {

            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);

            string ret = getUsersJson();

            result = Request.CreateResponse<string>(HttpStatusCode.OK, ret, "text/json");
            return result;
        }

        // GET
        // postman: http://localhost:50731/api/users/GetAllUsersFromDB
        [HttpGet]
        [ActionName("getUsersFromDB")]
        public HttpResponseMessage getUsersFromDB()
        {

            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);

            IMongoClient client = new MongoClient("mongodb://localhost:27017/");
            IMongoDatabase database = client.GetDatabase("RestApiTestdb");
            var collection = database.GetCollection<Users>("users");

            var ret = collection.Find(new BsonDocument()).ToList();

            result = Request.CreateResponse<List<Users>>(HttpStatusCode.OK, ret, "text/json");
            return result;
        }

        // GET
        // postman: http://localhost:50731/api/users/GetUserById/1
        [HttpGet]
        public HttpResponseMessage GetUserById(int id)
        {
            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);

            result = Request.CreateResponse(HttpStatusCode.OK, result, "text/json");
            return result;
        }


        // POST
        // postman: http://localhost:50731/api/users/AddUser
        // body->row: {first_name: "333", last_name:"444"}
        [HttpPost]
        [ActionName("AddUserToDB")]
        public HttpResponseMessage AddUserToDB([FromBody]Users user)
        {

            //var entity = new Users
            //{
            //    first_name = "Tom11",
            //    last_name = "Ron222",
            //    email = "aa@aa.aa"
            //};

            HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);
            bool success = true;
            var client = new MongoClient("mongodb://localhost:27017/");
            IMongoDatabase db = client.GetDatabase("RestApiTestdb");
            var col = db.GetCollection<Users>("users");
            

            try
            {
                if (user != null) {
                    col.InsertOne(user);
                }
            }
            catch (Exception e)
            {
                success = false;
                //Console.WriteLine($"User not added to DB: '{e}'");
                //result = Request.CreateResponse<HttpResponseMessage>(HttpStatusCode.ExpectationFailed, result);
            }

            result = Request.CreateResponse<bool>(HttpStatusCode.OK, success, "text/json");
            return result;
        }

        // PUT 
        public void EditUser(int id, Person person)
        {
        }

        // DELETE
        public void DeleteUser(int id)
        {
        }
    }
}