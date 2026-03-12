using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASPCoreWebApi.Models;

namespace ASPCoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsAPIController : ControllerBase
    {
        public List<string> fruits = new List<string>() { "Apple", "Banana", "Cherry", "Mango", "Grapes" };

        [HttpGet]
        public List<string> GetFruits() { return fruits; }

        [HttpGet("{id}")]
        public string GetFruitsByIndex(int id) { return fruits.ElementAt(id); }

        [Route("DoSomeTask1")]
        [HttpPost]
        public void DoSomeTask1(int id, string name)
        {

        }

        [Route("DoSomeTask2")]
        [HttpPost]
        public ActionResult DoSomeTask2(Student stud)
        {
            return Ok();
        }
    }
}
    

