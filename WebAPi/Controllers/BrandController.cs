using Microsoft.AspNetCore.Mvc;
using WebAPi.Data.Entities;
using WebAPi.Interfaces.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BrandController(IBrandService brandService) : ControllerBase
{
    private readonly IBrandService _brandService = brandService;

    // GET: api/<BrandController>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        return Ok(await _brandService.GetAll());
    }

    // GET api/<BrandController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        return Ok(await _brandService.GetById(id));
    }

    // POST api/<BrandController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Brand dto)
    {
        return Ok(await _brandService.Create(dto));
    }

    // PUT api/<BrandController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Brand dto)
    {
        if (dto.Id != id)
        {
            throw new Exception("Invalid Id");
        }

        return Ok(await _brandService.Edit(dto));
    }

    // DELETE api/<BrandController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        Brand brand = await _brandService.GetById(id);
        if (brand.Id != id)
        {
            throw new Exception("Invalid Id");
        }

        await _brandService.Delete(id);
        return Ok();
    }
}