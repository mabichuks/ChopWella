using Chopwella.Core;
using Chopwella.ServiceInterface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace Chopwella.Web.Controllers.api
{
    [RoutePrefix("api/chopwella")]
    public class ChopwellaController : ApiController
    {
        private readonly IServices<Staff> _context;
        public ChopwellaController(IServices<Staff> context)
        {
            _context = context;
        }
        
        public IHttpActionResult GetStaffs()
        {
            var staff = _context.GetAll();
            staff.ToList();
            _context.Save();
            return Ok(staff);
        }
       [HttpPost]
        public IHttpActionResult PostStaffs(Staff staff)
        {
            
            
            try
            {
                _context.Edit(staff);
            }
            catch (System.Exception)
            {

                throw;
            }
            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
