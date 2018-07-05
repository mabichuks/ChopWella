using Chopwella.Infrastructure;
using Chopwella.Infrastructure.Identity;
using Chopwella.Web.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using static Chopwella.Infrastructure.Identity.IdentityModel;

namespace Chopwella.Web.Controllers.api
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        private readonly IUserRepo repo;

        public UserController(IUserRepo repo)
        {
            this.repo = repo;
        }

        [Route("create")]
        [HttpPost]
        public async Task<HttpResponseMessage> CreateUser(UserViewModel model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                var result = await repo.CreateUser(model.UserName, model.Email, model.Password, model.RoleName);

                if (!result.Succeeded)
                {
                    this.Request.CreateResponse(HttpStatusCode.BadRequest, result.Errors.FirstOrDefault());
                }
                return this.Request.CreateResponse(HttpStatusCode.Created, "Successful");

            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
