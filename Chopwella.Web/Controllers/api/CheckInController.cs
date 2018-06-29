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
            [Route("CheckIn")]
            [HttpPost]
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
            public HttpResponseMessage AddCheckin([FromBody]CheckIn cs)
            {
                try
                {

                    IEnumerable<CheckIn> check = _checkinservice.GetAll();
                    var checkday = check.FirstOrDefault(c => c.IsChecked == cs.IsChecked);
                    if (checkday != null)
                        return this.Request.CreateResponse(HttpStatusCode.NoContent, "not checked");
                    _checkinservice.Add(cs);
                    return this.Request.CreateResponse(HttpStatusCode.Created, "Added");

                }
                catch (Exception message)
                {
                    return this.Request.CreateResponse(HttpStatusCode.InternalServerError, message.Message);
                }
            }
            [Route("Checkin/{Id}")]
            public HttpResponseMessage GetCheckinbyDay([FromUri]DateTime Id)
            {
                try
                {
                    IEnumerable<CheckIn> check = _checkinservice.GetAll();
                    var checkinbyId = check.Where(m => m.Date.Date == Id).ToList();

                    return this.Request.CreateResponse<IEnumerable<CheckIn>>(HttpStatusCode.Created, checkinbyId);
                }
                catch (Exception message)
                {

                    return this.Request.CreateResponse(HttpStatusCode.InternalServerError, message.Message);
                }
            }

        }
    }
