using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarkAPI.Data;
using StarkAPI.Models;

namespace StarkAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JokeController(IConfiguration configuration) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
                     // For now, we'll return a placeholder response
            var jokes = new List<Joke>
            {
                new Joke { PartitionKey = "1", RowKey = "1", Leadin = "Why did the chicken cross the road?", Hit = "To get to the other side!", Category = "Animal" },
                new Joke { PartitionKey = "2", RowKey = "2", Leadin = "What do you call a fake noodle?", Hit = "An impasta!", Category = "Food" }
            };
      var _jokeService = new DataService(configuration);
             jokes = await _jokeService.GetJokes("DadJokes");
            return Ok(jokes);
        }
        
        [HttpGet("jokes")]
        public async Task<IActionResult> GetJokes()
        {
            // Here you would typically call your data service to get jokes
            // For now, we'll return a placeholder response
            var jokes = new List<Joke>();
            // {
            //     new Joke { PartitionKey = "1", RowKey = "1", Leadin = "Why did the chicken cross the road?", Hit = "To get to the other side!", Category = "Animal" },
            //     new Joke { PartitionKey = "2", RowKey = "2", Leadin = "What do you call a fake noodle?", Hit = "An impasta!", Category = "Food" }
            // };
            var _dataService = new DataService(configuration);
            var _jokeService = new DataService(configuration);
             jokes = await _jokeService.GetJokes("DadJokes");
            // Replace placeholder with data service call
            // Example: var jokes = _jokeService.GetAllJokes();
            return Ok(jokes);
        }
}
}
