using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
using System.Text;
namespace EjemploAspNet.Modules
{
    public class principal:NancyModule
    {
        private string DbPath = @"C:\Users\majimenezp\Documents\Visual Studio 2010\Projects\Presentaciones\Nancy\EjemploAspNet\BasedeDatos.s3db";
        public principal()
        {
            //Before += contexto =>
            //{
            //    //if (contexto.Request.UserHostAddress.Contains("127.0.0.1"))
            //    //{
            //    //    return "la aplicacion no puede correr desde el localhost";
            //    //}
            //    return null;
            //};

            //After += contexto =>
            //{
            //    if (contexto.Response.StatusCode == HttpStatusCode.OK)
            //    {
            //        var respuesta = new Nancy.Response();

            //        contexto.Response.Contents = stream =>
            //        {
            //            var texto = Encoding.Unicode.GetBytes("No se encontro nada");
            //            stream.Write(texto, 0, texto.Length);
            //        };
            //    }
            //};


            Get["/"] = x => {

                return View["principal", new { titulo = "Pagina principal ejemplo alt.net",Mensaje="ejemplo de presentacion alt.net" }];
                //return View["principal", new { titulo = "Pagina Principal" }];
            };

            Get["/Persona"] = x =>
            {
                var datos=DAL.Instancia.ObtenerPersonas();
                return View["persona/index",new{titulo="Listado de persona",registros=datos}];
            };

            Get["/Persona/nuevo"] = x =>
            {
                Entidades.Persona nuevo=new Entidades.Persona();
                return View["persona/nuevo",new{titulo="Nueva persona",Registro=nuevo,Action="/persona/nuevo"}];
            };
            Post["/Persona/nuevo"] = x =>
            {
                Entidades.Persona nuevo = this.Bind<Entidades.Persona>();
                bool resultado=DAL.Instancia.Guardar(nuevo);
                if (resultado)
                {
                    return Response.AsRedirect("/Persona");
                }
                else
                {
                    return View["persona/nuevo", new { titulo = "Nueva persona", Registro = nuevo, Action = "/persona/nuevo" }];
                }
            };

            Get["/Persona/{id}/editar"] = x =>
            {
                Entidades.Persona editar = DAL.Instancia.TraerPersonaPorId((int)x.Id);
                return View["persona/nuevo", new {titulo="Editar persona",Registro=editar,Action="/persona/editar",Method="PUT"}];
            };

            Put["/Persona/editar"] = x => 
            {
                Entidades.Persona editar = this.Bind<Entidades.Persona>();
                bool resultado = DAL.Instancia.Guardar(editar);
                if (resultado)
                {
                    return Response.AsRedirect("/Persona");
                }
                else
                {
                    return View["persona/nuevo", new { titulo = "Editar persona", Registro = editar, Action = "/persona/editar", Method = "PUT" }];
                }
            };
        }
    }
}