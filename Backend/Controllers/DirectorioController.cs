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
    public class DirectorioController : Controller
    {
        private readonly ProyectoContext context;
        public DirectorioController (ProyectoContext context)
        {
            this.context = context;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get ()
        {
            List<Directorio> Directorio = await this.context.Directorio.ToListAsync ();
            if (Directorio.Count > 0)
            {
                return Ok (Directorio);
            }
            else
            {
                return NotFound ();
            }
        }

        // GET api/values/5
        [HttpGet ("{id}", Name = "GetDirectorio")]
        public async Task<IActionResult> Get (int id)
        {
            Directorio Directorio = await this.context.Directorio.FindAsync (id);
            if (Directorio != null)
            {
                return Ok (Directorio);
            }
            else
            {
                return NotFound ();
            }
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post ([FromBody] Directorio Directorio)
        {
            if (Directorio == null || !ModelState.IsValid)
            {
                return BadRequest (ModelState);
            }
            else
            {
                try
                {

                    await this.context.Directorio.AddAsync (Directorio);
                    await this.context.SaveChangesAsync ();
                    return CreatedAtRoute ("GetDirectorio", new { id = Directorio.Id }, Directorio);
                }
                catch (Exception ex)
                {
                    Console.WriteLine (ex);
                    return BadRequest (Directorio);
                }
            }
        }

        // PUT api/values/5
        [HttpPut ("{id}")]
        public async Task<IActionResult> Put (int id, [FromBody] Directorio Directorio)
        {
            if (Directorio == null || !ModelState.IsValid || Directorio.Id != id)
            {
                return BadRequest (ModelState);
            }
            else
            {
                Directorio viejo = await this.context.Directorio.FindAsync (id);
                
                if (viejo == null)
                {
                    return NotFound ();
                }
                else
                {
                    var actualizar = this.context.Entry(viejo);
                    actualizar.CurrentValues.SetValues(Directorio);
                    actualizar.State = EntityState.Modified;
                    try
                    {
                        this.context.Directorio.Update (viejo);
                        await this.context.SaveChangesAsync ();
                        return NoContent ();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine (ex);
                        return BadRequest (Directorio);
                    }
                }
            }

        }

        // Patch api/values/5
        [HttpPatch ("{id}")]
        public async Task<IActionResult> Patch ([FromBody] JsonPatchDocument<Directorio> DirectorioPatch, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest (DirectorioPatch);
            }
            try
            {
                Directorio viejo = await this.context.Directorio.FindAsync (id);
                if (viejo == null)
                {
                    return NotFound ();
                }
                else
                {
                    DirectorioPatch.ApplyTo (viejo);
                    await this.context.SaveChangesAsync ();
                    return Ok (viejo);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
                return BadRequest (DirectorioPatch);

            }

        }

        // DELETE api/values/5
        [HttpDelete ("{id}")]
        public async Task<IActionResult> Delete (int id)
        {
            Directorio encontrado = await this.context.Directorio.FindAsync (id);
            if (encontrado == null)
            {
                return NotFound ();
            }
            else
            {
                try
                {

                    this.context.Directorio.Remove (encontrado);
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