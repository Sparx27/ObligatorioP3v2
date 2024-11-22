using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using MVC.Models.Usuario;
using System.Security.Cryptography;
using System.Security.Policy;

namespace MVC.Utils
{
    public static class ConexionServidor
    {
        public static async Task<(string, HttpResponseMessage)> ClientSinBody(string url, string method)
        {
            HttpClient cliente = new HttpClient();

            HttpResponseMessage respuesta;

            switch (method)
            {
                case "GET":
                    respuesta = await cliente.GetAsync(url);
                    break;

                case "DELETE":
                    respuesta = await cliente.DeleteAsync(url);
                    break;

                default:
                    throw new Exception("Method incorrecto");
            }

            string resBody = await respuesta.Content.ReadAsStringAsync();
            return (resBody, respuesta);
        }

        public static async Task<(string, HttpResponseMessage)> ClientConBody<T>(string url, string method, T VM)
        {
            HttpClient cliente = new HttpClient();

            HttpResponseMessage respuesta;

            switch (method)
            {
                case "POST":
                    respuesta = await cliente.PostAsJsonAsync(url, VM);
                    break;
                case "PUT":
                    respuesta = await cliente.PutAsJsonAsync(url, VM);
                    break;
                case "PATCH":
                    respuesta = await cliente.PatchAsJsonAsync(url, VM);
                    break;

                default:
                    throw new Exception("Method incorrecto");
            }

            string resBody = await respuesta.Content.ReadAsStringAsync();
            return (resBody, respuesta);
        }
    }
}
