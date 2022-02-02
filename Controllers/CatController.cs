using webapp.Models;
using webapp.Services;
using Microsoft.AspNetCore.Mvc;

namespace webapp.Controllers;

[ApiController]
[Route("[controller]")]
public class CatController : ControllerBase {
    public CatController() {
        // Add services to the container.
    }

    // GET all action
    [HttpGet]
    public ActionResult<List<Cat>> GetAll() => CatService.GetAll;
    
    // GET by id action
    [HttpGet("{id}")]
    public ActionResult<Cat> Get(int id) {
        var cat = CatService.Get(id);
        if (cat is null) return NotFound();
        return cat;
    }


    // POST action
    public ActionResult<Cat> Create(Cat cat) {
        CatService.Add(cat);
        return CreatedAtAction(nameof(Create), new { id = cat.Id }, cat);
    }

    // PUT action
    [HttpPut("{id}")]
    public IActionResult Update(int id, Cat cat) {
        if (id != cat.Id) return BadRequest();

        var catToUpdate = CatService.Get(id);
        if (catToUpdate is null) return NotFound();

        CatService.Update(cat);
        return NoContent();
    }


    // DELETE action
    [HttpDelete("{id}")]
    public IActionResult Delete(int id) {
        var cat = CatService.Get(id);
        if (cat is null) return NotFound();

        CatService.Delete(id);
        return NoContent();
    }
    
}