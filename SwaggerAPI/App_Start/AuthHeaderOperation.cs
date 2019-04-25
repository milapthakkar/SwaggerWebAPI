using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Filters;

namespace SwaggerAPI.App_Start
{
    /// <summary>
    /// The class to add the authorization header.
    /// </summary>
    public class AuthHeaderOperation : IOperationFilter
    {

        /// <summary>
        /// Applies the operation filter.
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="schemaRegistry"></param>
        /// <param name="apiDescription"></param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation == null) return;

            if (operation.parameters == null)
            {
                operation.parameters = new List<Parameter>();
            }

            /*var parameter = new Parameter
            {
                description = "access token",
                @in = "header",
                name = "Authorization",
                required = true,
                type = "string"
            };

            if (apiDescription.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                parameter.required = false;
            }

            operation.parameters.Add(parameter);*/

            var filterPipeline = apiDescription.ActionDescriptor.GetFilterPipeline();
            var isAuthorized = filterPipeline.Select(filterInfo => filterInfo.Instance).Any(filter => filter is IAuthorizationFilter);
            var authorizationRequired = apiDescription.GetControllerAndActionAttributes<AuthorizeAttribute>().Any();

            if (isAuthorized && authorizationRequired)
            {
                operation.parameters.Add(new Parameter
                {
                    name = "Authorization Token",
                    @in = "header",
                    description = "access token",
                    required = true,
                    type = "string"
                });
            }


        }
    }
}