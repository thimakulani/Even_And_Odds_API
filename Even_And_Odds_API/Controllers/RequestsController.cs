using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Even_And_Odds_API.Data;
using Even_And_Odds_API.Models;

namespace Even_And_Odds_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RequestsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Requests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requests>>> GetRequests()
        {
            return await _context.Requests.ToListAsync();
        }

        // GET: api/Requests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Requests>> GetRequests(string id)
        {
            var requests = await _context.Requests.FindAsync(id);

            if (requests == null)
            {
                return NotFound();
            }

            return requests;
        }

        [HttpGet("driver/{id}")]
        public async Task<ActionResult<Requests>> GetDriverRequests(string id)
        {
            var requests = await _context.Requests.Where(x => x.DriverId == id).ToListAsync();

            if (requests == null)
            {
                return NotFound();
            }

            return Ok(requests);
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<Requests>> GetUserRequests(string id)
        {
            var requests = await _context.Requests.Where(x => x.UserId == id).ToListAsync();

            if (requests == null)
            {
                return NotFound();
            }

            return Ok(requests);
        }

        // PUT: api/Requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequests(string id, Requests requests)
        {
            if (id != requests.Id)
            {
                return BadRequest();
            }

            _context.Entry(requests).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestsExists(id))
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
        // PUT: api/Requests/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UodateRequest(string id, string status)
        {
            var request = await _context.Requests.FindAsync(id);
            request.Status = status;
            _context.Entry(request).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequestsExists(id))
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
        // POST: api/Requests
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Requests>> PostRequests(Requests requests)
        {
            _context.Requests.Add(requests);
            await _context.SaveChangesAsync();
            var response = new Response()
            {
                Content = "REQUEST HAS BEEN SUCCESSFULLY MADE",
                Id = requests.Id
            };
            return Ok(response);
        }

        // DELETE: api/Requests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequests(string id)
        {
            var requests = await _context.Requests.FindAsync(id);
            if (requests == null)
            {
                return NotFound();
            }

            _context.Requests.Remove(requests);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequestsExists(string id)
        {
            return _context.Requests.Any(e => e.Id == id);
        }
    }
}
