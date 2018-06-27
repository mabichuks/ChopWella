using Chopwella.Core;
using Chopwella.ServiceInterface;
using System.Web.Http;

namespace Chopwella.Web.Controllers.api
{
    [RoutePrefix("api/chopwella")]
    public class ChopwellaController : ApiController
    {
        //[Authorize(Roles ="ADMIN")]
        private readonly IServices<Staff> _context;
        public ChopwellaController(IServices<Staff> context)
        {
            _context = context;
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {

            var staff = _context.GetSingle(id);
            staff.IsDeleted = true;
            _context.Save();
            return Ok();
        }

        // Code for Inplementing Logical delete----Should be attached with the Index View---
        //        @section scripts
        //        {
        //    <script>
        //        $(document).ready(function () {
        //            $(".js-delete").click(function(e) {
        //                var link = $(e.target);
        //                if (confirm("are you sure"))
        //                {
        //                    $.ajax({

        //                    })
        //                    $.ajax({
        //                        url: "/api//" + link.attr("data-staff-id"),
        //                        method: "DELETE"
        //                    })
        //                        .done(function() {
        //                        link.parents("tr").fadeOut(function() {
        //                                $(this).remove();
        //                        });
        //                    })
        //                        .fail(function() {
        //                        alert("something failed");
        //                    });
        //                }

        //            });

        //        });
        //    </script>


        //}



    }
}
