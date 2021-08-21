using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using projetoGamaAcademy.Models;
using projetoGamaAcademy.Servicos;

namespace projetoGamaAcademy.Controllers
{
    [ApiController]
    //[Route("[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly DbContexto _context;

        public CandidatosController(DbContexto context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/candidatos")]
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.Candidatos;
            return StatusCode(200, await _context.Candidatos.ToListAsync());
        }

        [HttpPost]
        [Route("/candidatos")]        
        public async Task<IActionResult> Create([Bind("Id,Nome,CPF,Nascimento,Telefone,Email,Logradouro,Numero,Bairro,Cidade,Estado,VagaId")] Candidato candidato)
        {
            _context.Add(candidato);
            await _context.SaveChangesAsync();
            return StatusCode(201, candidato);
        }

        [HttpPut]       
        [Route("/candidatos/{id}")] 
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,CPF,Nascimento,Telefone,Email,Logradouro,Numero,Bairro,Cidade,Estado,VagaId")] Candidato candidato)
        {
            if (id != candidato.Id)
            {
                return NotFound();
            }
           
            try
            {
                _context.Update(candidato);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CandidatoExists(candidato.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return StatusCode(200, candidato);                      
        }

        [HttpGet]
        [Route("/candidatos/{id}")]        
        public async Task<Candidato> Get(int id)
        {
            return await _context.Candidatos.FindAsync(id);                     
        }



        [HttpDelete]
        [Route("/candidatos/{id}")]        
        public async Task<IActionResult> Delete(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidatos.Any(e => e.Id == id);
        }
    }
}
