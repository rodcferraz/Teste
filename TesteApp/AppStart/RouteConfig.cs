using System.Web.Routing;
using System.Web.Mvc;

namespace TesteApp.AppStart
{
    public static class RouteConfig
    {
        public static void MapView(this RouteCollection routes, string path, string template)
        {
            routes.MapRoute(path, path, new
            {
                controller = "App",
                action = "AppView",
                view = template
            });
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                name: "API",
                url: "{controller}/{action}",
                defaults: null
                );

            routes.MapRoute(
                name: "Index",
                url: "{controller}",
                defaults: new
                {
                    action = "Index"
                },
                constraints: new
                {
                    httpMethod = new HttpMethodConstraint("Get"),
                                
                });


            //routes.MapRoute(
            //    name: "Consultar",
            //    url: "{controller}",
            //    defaults: new
            //    {
            //        action = "Consultar"
            //    },
            //    constraints: new
            //    {
            //        httpMethod = new HttpMethodConstraint("Post"),
                                
            //    });

        }
    }
}