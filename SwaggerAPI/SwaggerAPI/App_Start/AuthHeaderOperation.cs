using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;

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
            //var attrs = apiDescription.ActionDescriptor.GetCustomAttributes<AuthorizeAttribute>();
            //foreach (var attr in attrs)
            //{
            //    //if (attr.GetType() == typeof(AuthorizeAttribute))
            //    //{
            //        operation.parameters.Add(new Parameter
            //        {
            //            description = "access token",
            //            @in = "header",
            //            name = "Authorization",
            //            required = true,
            //            type = "string"
            //        });
            //    //}
            //}

            var parameter = new Parameter
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

            operation.parameters.Add(parameter);


        }
    }
}