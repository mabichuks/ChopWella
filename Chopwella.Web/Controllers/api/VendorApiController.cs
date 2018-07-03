using Chopwella.Core;
using Chopwella.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chopwella.Web.Controllers.api
{
    [RoutePrefix("api/chopwella")]

    public class VendorApiController : ApiController
    {
        private readonly IServices<Vendor> vendorservice;

        public VendorApiController(IServices<Vendor> vendorservice)
        {
            this.vendorservice = vendorservice;
        }

        [Route("vendors")]
        public HttpResponseMessage GetVendors()
        {
            try
            {
                var vendors = vendorservice.GetAll();
                return this.Request.CreateResponse<IEnumerable<Vendor>>(HttpStatusCode.Created, vendors);
            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [Route("addvendor")]
        [HttpPost]
        public HttpResponseMessage AddVendor([FromBody]Vendor v)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "your fields are not valid");
                }

                IEnumerable<Vendor> vendors = vendorservice.GetAll();
                var checkVendor = vendors.FirstOrDefault(m => m.Name == v.Name);

                if (checkVendor != null) return this.Request.CreateResponse(HttpStatusCode.Conflict, "Vendor Already Exist");

                vendorservice.Add(v);
                return this.Request.CreateResponse(HttpStatusCode.Created, "Added Successfully");
            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [Route("editVendor")]
        public HttpResponseMessage EditVendor([FromBody] Vendor v)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "your fields are not valid");
                }

                vendorservice.Edit(v);

                return this.Request.CreateResponse(HttpStatusCode.Created, "Updated Successfully");
            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("deleteVendor/{Id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteVendor(int Id)
        {
            try
            {
                var cat = vendorservice.GetSingle(Id);

                if (cat == null) return this.Request.CreateResponse(HttpStatusCode.Created, "Invalid VendorId");

                vendorservice.Delete(cat);
                return this.Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
