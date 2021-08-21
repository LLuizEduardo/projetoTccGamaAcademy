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
    public class VagasController : ControllerBase
    {
        private readonly DbContexto _context;

        public VagasController(DbContexto context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("/vagas")]
        public async Task<IActionResult> Index()
        {
            var dbContexto = _context.Vagas;
            return StatusCode(200, await _context.Vagas.ToListAsync());
        }

        [HttpPost]
        [Route("/vagas")]        
        public async Task<IActionResult> Create([Bind("Id,Nome_vaga,Descricao,Empresa,Segmento,Site,Logradouro,Numero,Bairro,Cidade,Estado")] Vaga vaga)
        {
            _context.Add(vaga);
            await _context.SaveChangesAsync();
            return StatusCode(201, vaga);
        }

        [HttpPut]       
        [Route("/vagas/{id}")] 
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome_vaga,Descricao,Empresa,Segmento,Site,Logradouro,Numero,Bairro,Cidade,Estado")] Vaga vaga)
        {
            if (id != vaga.Id)
            {
                return NotFound();
            }
           
            try
            {
                _context.Update(vaga);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VagaExists(vaga.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return StatusCode(200, vaga);                      
        }

        [HttpGet]
        [Route("/vagas/{id}")]        
        public async Task<Vaga> Get(int id)
        {
            return await _context.Vagas.FindAsync(id);                     
        }


        [HttpDelete]
        [Route("/vagas/{id}")]        
        public async Task<IActionResult> Delete(int id)
        {
            var vaga = await _context.Vagas.FindAsync(id);
            _context.Vagas.Remove(vaga);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool VagaExists(int id)
        {
            return _context.Vagas.Any(e => e.Id == id);
        }
    }
}
