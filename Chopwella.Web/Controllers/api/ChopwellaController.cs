using Chopwella.Core;
using Chopwella.ServiceInterface;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chopwella.Web.Controllers.api
{
    [RoutePrefix("api/chopwella")]
    public class ChopwellaController : ApiController
    {
        //[Authorize(Roles ="ADMIN")]



        private readonly IServices<Staff> _service;
        public ChopwellaController(IServices<Staff> service)
        {
            _service = service;
        }




        [Route("delete/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var staff = _service.GetSingle(id);
                _service.Delete(staff);
                _service.Save();
                return Request.CreateResponse(HttpStatusCode.OK, "Record has been successfully deleted");
            }

            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
       


        // Code for Inplementing delete----Should be attached with the Index View---
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
