using DemoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebAPI.Controllers
{
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
        // postman: http://localhost:50731/api/people/GetAll
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
        // postman: http://localhost:50731/api/people/GetPerson/1
        //[HttpGet]
        //public HttpResponseMessage GetPerson(int id)
        //{
        //    HttpResponseMessage result = Request.CreateResponse(HttpStatusCode.OK);

        //    result = Request.CreateResponse<Person>(HttpStatusCode.OK, studentsLst[id], "text/json");
        //    return result;
        //}

        // postman: http://localhost:50731/api/people/getWithActionName
        //[HttpGet]
        //[ActionName("getWithActionName")]
        //public List<Person> getWithActionNameInner()
        //{
        //    //return people;
        //}

        // POST
        // postman: http://localhost:50731/api/people/AddPerson
        // body->row: {FirstName: "333",LastName:"444"}
        // if we will set in DB so we can get the list with the added person
        public void AddPerson(Person person)
        {
            //people.Add(new Person { FirstName = person.FirstName, LastName = person.LastName });
        }

        // PUT 
        public void EditPerson(int id, Person person)
        {
            //people[id].FirstName = person.FirstName;
            //people[id].LastName = person.LastName;
        }

        // DELETE
        public void DeletePerson(int id)
        {
            //people.RemoveAt(id);
        }
    }
}