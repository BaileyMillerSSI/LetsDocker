using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoService.Entity;

namespace ToDoService.Controllers
{
    [Produces("application/json")]
    [Route("api/Agenda")]
    public class AgendaController : Controller
    {
        private readonly ToDoContext Context;

        public AgendaController(ToDoContext context)
        {
            Context = context;
        }

        // GET: api/Agenda
        [HttpGet]
        public IActionResult GetItems()
        {
            try
            {
                Context.Database.Migrate();
                var nonNulls = Context.Items.Where(x=>x.DueBy != null).OrderBy(x=>x.DueBy);
                var nulls = Context.Items.Where(x => x.DueBy == null).OrderBy(x => x.PriorityOrder);
                return Ok(nonNulls.Concat(nulls));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // GET: api/Agenda/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAgendaItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agendaItem = await Context.Items.SingleOrDefaultAsync(m => m.AgendaItemId == id);

            if (agendaItem == null)
            {
                return NotFound();
            }

            return Ok(agendaItem);
        }

        // PUT: api/Agenda/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgendaItem([FromRoute] int id, [FromBody] AgendaItem agendaItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agendaItem.AgendaItemId)
            {
                return BadRequest();
            }

            Context.Entry(agendaItem).State = EntityState.Modified;

            try
            {
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendaItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Agenda
        [HttpPost]
        public async Task<IActionResult> PostAgendaItem([FromBody] AgendaItem agendaItem)
        {
            var AlreadyExists = Context.Items.Where(x => x.AgendaItemId == agendaItem.AgendaItemId).Count();
            if (!ModelState.IsValid || AlreadyExists != 0)
            {
                return BadRequest(ModelState);
            }

            Context.Items.Add(agendaItem);
            await Context.SaveChangesAsync();

            return CreatedAtAction("GetAgendaItem", new { id = agendaItem.AgendaItemId }, agendaItem);
        }

        // DELETE: api/Agenda/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgendaItem([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var agendaItem = await Context.Items.SingleOrDefaultAsync(m => m.AgendaItemId == id);
            if (agendaItem == null)
            {
                return NotFound();
            }

            Context.Items.Remove(agendaItem);
            await Context.SaveChangesAsync();

            return Ok(agendaItem);
        }

        private bool AgendaItemExists(int id)
        {
            return Context.Items.Any(e => e.AgendaItemId == id);
        }
    }
}