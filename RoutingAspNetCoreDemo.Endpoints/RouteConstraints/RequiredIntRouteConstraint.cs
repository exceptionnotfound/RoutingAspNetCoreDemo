using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoutingAspNetCoreDemo.Endpoints.RouteConstraints
{
    public class RequiredPositiveIntRouteConstraint : IRouteConstraint
    {
        public bool Match(HttpContext httpContext, 
                            IRouter router, 
                            string parameterName, 
                            RouteValueDictionary values, 
                            RouteDirection routeDirection)
        {
            return new IntRouteConstraint().Match(httpContext, router, parameterName, values, routeDirection)
                && new RequiredRouteConstraint().Match(httpContext, router, parameterName, values, routeDirection)
                && new MinRouteConstraint(1).Match(httpContext, router, parameterName, values, routeDirection);
        }
    }
}
