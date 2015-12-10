using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ApiTokenAuthentication.Controllers
{
    [RoutePrefix("test")]
    public class TestController : ApiController
    {
        [HttpGet]
        [Route("unauthenticated")]
        public HttpResponseMessage Unauthenticated()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = CreateContent();
            return response;
        }

        [HttpGet]
        [Authorize]
        [Route("authenticated")]
        public HttpResponseMessage Authenticated()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = CreateContent();
            return response;
        }

        StringContent CreateContent()
        {
            return new StringContent(string.Format("Hello, '{0}'!", User.Identity.Name));
        }
    }
}