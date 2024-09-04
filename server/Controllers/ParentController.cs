using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

namespace server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParentController : Controller
    {
        private  ILogger<ParentController> _logger;
        private MediContext _context;
        public IActionResult Index()
        {
            return View();
        }

        public ParentController(ILogger<ParentController> logger, MediContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "Titles")]
        public IEnumerable<Title> Get(int? pageNumber=null, int? pageSize=null)
        {
            /* Use AsNoTracking for read-only Operation.
             This helps improve performance for read only operations by skipping the change tracking process.
             */
            var titles = _context.Titles.AsNoTracking().Include(t => t.Name).OrderBy(p =>p.Name).ToArray();
            // Order by a unique column to ensure consistent results.
            /*Use Include to eagerly load related entities only when necessary to avoid unnecessary data retrieval,
             *in a single query, preventing the N+1 query problem.*/
            if ((pageNumber != null) && (pageSize != null)) {
                // Skip previous pages and take the current page.
                titles = titles.Skip((pageNumber.Value - 1) * pageSize.Value).Take(pageSize.Value).ToArray();
                
            }
            return titles;
        }
    }
}
