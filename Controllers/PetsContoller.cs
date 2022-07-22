using Microsoft.AspNetCore.Mvc;
using TestAppAPI.Model;

namespace TestAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsContoller : ControllerBase
    {
        private static List<Pets> pets = new List<Pets>
        {
            new Pets {
                    Id = 1,
                    Name = "Bobby",
                    Category = "Cats",
                    Age = 3},

            new Pets {
                    Id = 2,
                    Name = "Bruno",
                    Category = "Dogs",
                    Age = 1}
        };

        [HttpGet]
        public async Task<ActionResult<List<Pets>>> Get()
        {           
            return Ok(pets);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Pets>> Get(int id)
        {
            var pet = pets.Find(h => h.Id == id);
            if (pet == null)
                return BadRequest("Pet not found.");
            return Ok(pet);
        }

        [HttpPost]
        public async Task<ActionResult<List<Pets>>> AddPet(Pets pet)
        {
            pets.Add(pet);
            return Ok(pets);
        }

        [HttpPut]
        public async Task<ActionResult<List<Pets>>> UpdatePet(Pets request)
        {
            var pet = pets.Find(p => p.Id == request.Id);
            if (pet == null)
                return BadRequest("Pet not found.");

            pet.Name = request.Name;
            pet.Category = request.Category;
            pet.Age = request.Age;

            return Ok(pets);
        }

        [HttpDelete]
        public async Task<ActionResult<List<Pets>>> DeletePet(int id)
        {
            var pet = pets.Find(p => p.Id == id);
            if (pet == null)
                return BadRequest("Pet not found.");

            pets.Remove(pet);
            return Ok(pets);
        }
    }
}
