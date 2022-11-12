using Aquarium.Managers;
using Aquarium.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aquarium.Controllers
{
    [Route("fishes")]
    [ApiController]
    public class FishesController : Controller
    {
        private readonly FishesManager _manager = new FishesManager();

        [HttpGet]
        public IEnumerable<Fish> Get()
        {
            return _manager.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Fish> Get(int id)
        {
            Fish fish = _manager.GetById(id);
            if (fish == null) return NotFound("No such fish, id: " + id);
            return Ok(fish);
        }

        [HttpPost]
        public ActionResult<Fish> Post([FromBody] Fish value)
        {
            Fish fish = _manager.Add(value);
            if (fish == null) return NotFound("No such fish, id: " + fish.Id);
            return Created("api/[controller]", fish);
        }

        [HttpPut("{id}")]
        public ActionResult<Fish> Put(int id, [FromBody] Fish value)
        {
            Fish fish = _manager.Update(id, value);
            if (fish == null) return NotFound("No such fish, id: " + id);
            return Ok(fish);
        }

        [HttpDelete("{id}")]
        public ActionResult<Fish> Delete(int id)
        {
            Fish fish = _manager.Delete(id);
            if (fish == null) return NotFound("No such fish, id: " + id);
            return Ok(fish);
        }
    }
}
