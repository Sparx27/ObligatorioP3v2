namespace MVC.Utils
{
    public static class ManejoSession
    {
        public static int? GetIdLogueado(HttpContext httpContext)
        {
            return httpContext.Session.GetInt32("idLogueado");
        }

        public static string? GetRolLogueado(HttpContext httpContext)
        {
            return httpContext.Session.GetString("rolLogueado");
        }

        public static string? GetToken(HttpContext httpContext)
        {
            return httpContext.Session.GetString("token");
        }
    }
}
