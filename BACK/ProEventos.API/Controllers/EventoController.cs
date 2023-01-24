using Microsoft.AspNetCore.Mvc;
using ProEventos.API.Models;

namespace ProEventos.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EventoController : ControllerBase
{
    public IEnumerable<Evento> _evento = new Evento[]{
            new Evento(){
                EventoId = 1,
                Tema = "Angular 11 e .NET 5",
                Local = "Belo Horizonte",
                Lote = "1 Lote",
                QtdPessoas = 25,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                ImagemUrl = "imagem.png"
            },
            new Evento(){
                EventoId = 2,
                Tema = "Angular 11 e .NET 5",
                Local = "Belo Horizonte",
                Lote = "2 Lote",
                QtdPessoas = 23,
                DataEvento = DateTime.Now.AddDays(2).ToString(),
                ImagemUrl = "imagem.png"
            }
        };
    public EventoController()
    {
        
    }

    [HttpGet]
    public IEnumerable<Evento> Get()
    {
        return _evento; 
    }

    [HttpGet("{id}")]
    public IEnumerable<Evento> GetById(int id)
    {
        return _evento.Where(x => x.EventoId == id); 
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
