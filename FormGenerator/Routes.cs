using System.Collections.Generic;
using System.Web.Mvc;
using Orchard.Mvc.Routes;
using System.Web.Routing;

namespace FormGenerator
{
    public class Routes : IRouteProvider
    {
        public void GetRoutes(ICollection<RouteDescriptor> routes)
        {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes()
        {
            return new[] {
                new RouteDescriptor {
                    Priority = 5,
                    Route = new Route(
                        "Form/Create",
                        new RouteValueDictionary {
                            {"area", "FormGenerator"},
                            {"controller", "Form"},
                            {"action", "Create"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "FormGenerator"}
                        },
                        new MvcRouteHandler())
                }
                ,  new RouteDescriptor {
                    Priority = 5,
                    Route = new Route(
                        "Form/CreatePOST",
                        new RouteValueDictionary {
                            {"area", "FormGenerator"},
                            {"controller", "Form"},
                            {"action", "CreatePOST"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "FormGenerator"}
                        },
                        new MvcRouteHandler())
                }
            };

        }
    }
}