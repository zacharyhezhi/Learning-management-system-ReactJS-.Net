using BL.Managers;
using Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http.Filters;

namespace LMS.Filters
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                // Gets header parameters  

                try
                {
                    string authenticationString = actionContext.Request.Headers.Authorization.Parameter;

                    string originalString = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationString));

                    // Gets username and password  
                    string usrename = originalString.Split(':')[0];
                    string password = originalString.Split(':')[1];

                    var userRepository = new AuthManager();
                    User user = userRepository.FindUser(usrename, password);

                    // Validate username and password  
                    if (user == null)
                    {
                        // returns unauthorized error  
                        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                    }
                }
                catch (Exception)
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }

            base.OnAuthorization(actionContext);
        }
    }
}