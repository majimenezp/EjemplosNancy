using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
namespace EjemploAspNet.Modules
{
    public class Informacion:NancyModule
    {
        public Informacion():base("/informacion")
        {
            Before += contexto =>
            {
                if (contexto.Request.UserHostAddress.Contains("127.0.0.1"))
                {
                    return "la aplicacion no puede correr desde el localhost";
                }
                return null;
            };
            Get["/"] = x =>
            {
                var cuerpo = Request.Body;
                var url = Request.Query;
                return "hola mundo";
            };
            
        }
    }
}