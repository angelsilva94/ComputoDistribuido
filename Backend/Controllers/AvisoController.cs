using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route ("api/[controller]")]
    public class AvisoController : Controller
    {
        private readonly ProyectoContext context;
        public AvisoController (ProyectoContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get ()
        {
            List<Aviso> avisos = await this.context.Avisos.ToListAsync ();
            if (avisos.Count > 0 )
            {
                return Ok (avisos);
            }
            else
            {
                return NotFound ();
            }
        }

        // GET api/values/5
        [HttpGet ("{id}", Name = "GetAviso")]
        public async Task<IActionResult> Get (int id)
        {
            Aviso aviso = await this.context.Avisos.FindAsync (id);
            if (aviso != null)
            {
                return Ok (aviso);
            }
            else
            {
                return NotFound ();
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] Aviso aviso)
        {
            if (aviso == null || !ModelState.IsValid)
            {
                return BadRequest (ModelState);
            }
            else
            {
                try
                {

                    await this.context.Avisos.AddAsync (aviso);
                    await this.context.SaveChangesAsync ();
                    return CreatedAtRoute ("GetAviso", new { id = aviso.Id }, aviso);
                }
                catch (Exception ex)
                {
                    Console.WriteLine (ex);
                    return BadRequest (aviso);
                }
            }
        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public async Task<IActionResult> Put (int id, [FromBody] Aviso aviso)
        {
            if (aviso == null || !ModelState.IsValid || aviso.Id != id)
            {
                return BadRequest (ModelState);
            }
            else
            {
                Aviso viejo = await this.context.Avisos.FindAsync (id);
                if (viejo == null)
                {
                    return NotFound ();
                }
                else
                {
                    var actualizar = this.context.Entry(viejo);
                    actualizar.CurrentValues.SetValues(aviso);
                    actualizar.State = EntityState.Modified;
                    try
                    {
                        this.context.Avisos.Update (viejo);
                        await this.context.SaveChangesAsync ();
                        return NoContent ();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine (ex);
                        return BadRequest (aviso);
                    }
                }
            }

        }

        // Patch api/values/5
        [HttpPatch ("{id}")]
        public async Task<IActionResult> Patch ([FromBody] JsonPatchDocument<Aviso> avisoPatch, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest (avisoPatch);
            }
            try
            {
                Aviso viejo = await this.context.Avisos.FindAsync (id);
                if (viejo == null)
                {
                    return NotFound ();
                }
                else
                {
                    var actualizar = this.context.Entry(viejo);
                    actualizar.CurrentValues.SetValues(avisoPatch);
                    actualizar.State = EntityState.Modified;
                    avisoPatch.ApplyTo (viejo);
                    await this.context.SaveChangesAsync ();
                    return Ok (viejo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
                return BadRequest (avisoPatch);

            }

        }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            Aviso encontrado = await this.context.Avisos.FindAsync (id);
            if (encontrado == null)
            {
                return NotFound ();
            }
            else
            {
                try
                {

                    this.context.Avisos.Remove (encontrado);
                    await this.context.SaveChangesAsync ();
                    return NoContent ();
                }
                catch (Exception ex)
                {
                    Console.WriteLine (ex);
                    return BadRequest ();
                }
            }
        }
    }
}