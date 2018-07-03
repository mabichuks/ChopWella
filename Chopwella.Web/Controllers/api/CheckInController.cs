using Chopwella.Core;
using Chopwella.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chopwella.Web.Controllers.api
{
    [RoutePrefix("api/chopwella")]
    public class CheckInController : ApiController
    {
        private readonly ChopWellaService<CheckIn> _checkinservice;
        public CheckInController(ChopWellaService<CheckIn> checkinservice)
        {
            _checkinservice = checkinservice;
        }
        [Route("CheckInDetails")]
        [HttpGet]
        public HttpResponseMessage GetCheckIn()
        {
            try
            {
                var check = _checkinservice.GetAll();
                return this.Request.CreateResponse<IEnumerable<CheckIn>>(HttpStatusCode.Created, check);
            }
            catch (Exception message)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, message.Message);
            }
        }
        [Route("AddCheckin")]
        [HttpPost]
        public HttpResponseMessage AddCheckin(CheckIn Id)
        {
            try
            {
               CheckIn check = _checkinservice.GetAll().FirstOrDefault(c => c.StaffId==Id.StaffId);
                if(check!=null && Id.IsChecked==true)
                {
                    _checkinservice.Add(Id);
                    return this.Request.CreateResponse(HttpStatusCode.Created, _checkinservice);
                }
                return Request.CreateResponse(HttpStatusCode.NoContent, "not checked");
              
            }
            catch (Exception message)
            {
                return this.Request.CreateResponse(HttpStatusCode.BadRequest, message.Message);
            }
        }
        [Route("CheckinbyId")]
        [HttpGet]
        public HttpResponseMessage GetCheckinbyDay(int Id)
        {
            try
            {
                IEnumerable<CheckIn> check = _checkinservice.GetAll();
                var checkinbyId = check.Where(m => m.StaffId == Id && m.IsChecked == true).ToList();
                if (checkinbyId == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse<IEnumerable<CheckIn>>(HttpStatusCode.OK, checkinbyId);
            }
            catch (Exception message)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, message.Message);
            }
        }
    }
}
