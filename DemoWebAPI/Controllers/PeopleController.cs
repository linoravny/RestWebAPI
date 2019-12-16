using DemoWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoWebAPI.Controllers
{
    public class PeopleController : ApiController
    {
        List<Person> people = new List<Person>();

        public PeopleController() { //always initiallize
            people.Add(new Person { FirstName = "Linor", LastName = "Avny" });
            people.Add(new Person { FirstName = "Linor2", LastName = "Avny2" });
            people.Add(new Person { FirstName = "Linor3", LastName = "Avny3" });
        }

        // GET
        // postman: http://localhost:50731/api/people/GetAll
        public List<Person> GetAll()
        {
            return people;
        }

        // GET
        // postman: http://localhost:50731/api/people/GetPerson/1
        public Person GetPerson(int id)
        {
            return people[id];
        }

        // postman: http://localhost:50731/api/people/getWithActionName
        [HttpGet]
        [ActionName("getWithActionName")]
        public List<Person> getWithActionNameInner()
        {
            return people;
        }

        // POST
        // postman: http://localhost:50731/api/people/AddPerson
        // body->row: {FirstName: "333",LastName:"444"}
        // if we will set in DB so we can get the list with the added person
        public void AddPerson(Person person)
        {
            people.Add(new Person { FirstName = person.FirstName, LastName = person.LastName });
        }

        // PUT 
        public void EditPerson(int id, Person person)
        {
            people[id].FirstName = person.FirstName;
            people[id].LastName = person.LastName;
        }

        // DELETE
        public void DeletePerson(int id)
        {
            people.RemoveAt(id);
        }
    }
}