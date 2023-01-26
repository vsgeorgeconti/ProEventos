using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Data;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventosController : ControllerBase
{
    
    private readonly DataContext _context;
    
    public EventosController(DataContext context)
    {
            this._context = context; 
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _context.Eventos; 
    }

    [HttpGet("{id}")]
    public Evento GetById(int id)
    {
        return _context.Eventos.FirstOrDefault(x => x.EventoId == id); 
    }

    [HttpPost]
    public string Post()
    {
        return "EXEMPLO DE POST";
    }

    [HttpPut]
    public string Put(int id)
    {
        return $"EXEMPLO DE PUT COM ID = {id}";
    }

    [HttpDelete]
    public string Delete(int id)
    {
        return $"EXEMPLO DE DELETE COM ID = {id}";
    }

}
