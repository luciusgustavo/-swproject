using Models.Commons;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClientWebTestProject
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient()) //O using no final do escopo disponibiliza o objeto para que seja apagado da memória
            {
                /*var id = 10; //transforma para o tipo diretamente
                var expectresult = client.GetStringAsync($"http://localhost:8080/v1/persons/{id}/name"); //O sifrão transforma tudo que está entre chave em variável
                //Console.Write("Request in progress...");
                var result = expectresult.Result;
                //Console.WriteLine(result);*/

                var person = new Person()
                {
                    Cpf= "12979856579",
                    Name = "Gustavo",
                    Old = 20,
                    Surname = "Lúcius",
                    Telephone = "99999999",
                };


                
                Console.WriteLine("Pressione enter para cadastrar a pessoa");
                Console.ReadLine();
                var result = client.PostAsJsonAsync("http://localhost:8080/v1/persons", person).Result;
                //string com o jason do person
                var getperson = client.GetStringAsync($"http://localhost:8080/v1/persons/0").Result;

                //converter para objeto
                var personResult = JsonConvert.DeserializeObject<Person>(getperson); //Deserealiza diretamente para a classe Person (Objeto Person)

                Console.WriteLine($"Name: {personResult.Name} {personResult.Surname}" ); //Escreve o Json
                Console.WriteLine($"CPF: {personResult.Cpf}");
                //Console.WriteLine(result.IsSuccessStatusCode);
                Console.ReadLine();

            }
        }

    }
}
