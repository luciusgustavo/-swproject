using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebTestProject.Models;

namespace WebTestProject.Controllers
{
    [RoutePrefix("v1/persons")] //Quando é prefixado, o arquivo de configuração fica obsoleto
    public class PersonsController : ApiController
    {
        private string Name { get; set; } //Propriedade -> acesso à uma variável

        private static IList<Person> _person = new List<Person>(); //Interface começa com a letra I maiúscula

        [Route("{id}/name")]
        [HttpGet]
        public string GetName(int id)
        {
            Name = "Gustavo"; //atribuição na proriedade
            return Name;
        }

        [Route("{id}/old")]
        [HttpGet]
        public int GetOld(int id)
        {
            return id;
        }

        [Route("{id}/surname")]
        [HttpGet]
        public string GetSurName(int id)
        {
            return "Lúcius Fernandes";
        }

        [Route("{id}")]
        [HttpGet]
        public Person GetPersons(int id)
        {
            return _person[id];
        }

        [Route]
        [HttpGet]
        public IList<Person> GetPersons()
        {
            return _person;
        }

        [Route]
        [HttpPost]
        public Person PostPersons(Person person)
        {
            _person.Add(person);
            return person;
        }
    }
}
