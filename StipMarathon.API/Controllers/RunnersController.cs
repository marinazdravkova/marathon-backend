using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StipMarathon.Backend;
using StipMarathon.Backend.Enums;

namespace StipMarathon.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RunnersController : ControllerBase
    {
        private static readonly MarathonManager _manager = new MarathonManager();

        [HttpGet]
        public IActionResult GetAllRunners()
        {
            var runners = _manager.GetAllRunners();
            return Ok(runners);
        }

        [HttpGet("underage")]
        public IActionResult GetUnderageRunners()
        {
            var underageRunners = _manager.GetUnderageRunners();
            return Ok(underageRunners);
        }

        [HttpGet("category/{category}")]

        public IActionResult GetRunnersByCategory(Category category)
        {
            var filteredRunners = _manager.GetRunnersByCategory(category);
            return Ok(filteredRunners);
        }

        [HttpPost]

        public IActionResult RegisterRunner([FromBody] Runner newRunner)
        {
            try
            {
                _manager.AddRunner(newRunner);
                _manager.SaveJsonToFile();

                return CreatedAtAction(nameof(GetAllRunners), new { id = newRunner.Id }, newRunner);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]

        public IActionResult GetRunnerById(int id)
        {
            var runner = _manager.GetAllRunners().FirstOrDefault(r => r.Id == id);

            if (runner == null)
            {
                return NotFound(new { message = $"Runner with ID {id} wasnot found." });
            }

            return Ok(runner);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateRunner(int id, [FromBody] Runner updatedRunner)
        {
            var runner = _manager.GetAllRunners().FirstOrDefault(r => r.Id == id);

            if (runner == null)
            {
                return NotFound(new { message = $"Runner with ID {id} was not found." });
            }

            runner.FirstName = updatedRunner.FirstName;
            runner.LastName = updatedRunner.LastName;
            runner.Email = updatedRunner.Email;
            runner.Age = updatedRunner.Age;
            runner.Category = updatedRunner.Category;

            _manager.SaveJsonToFile();

            return Ok(runner);

        }

        [HttpDelete("{id}")]

        public IActionResult DeleteRunner(int id)
        {
            var runner = _manager.GetAllRunners().FirstOrDefault(r => r.Id == id);

            if (runner == null)
            {
                return NotFound(new { message = $"Runner with ID {id} was not found." });
            }

            _manager.GetAllRunners().Remove(runner);
            _manager.SaveJsonToFile();

            return NoContent();
        }
    }
}
