using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using Nancy.ModelBinding;
namespace EjemploKayak.Modules
{
    public class principal:NancyModule
    {
        private string DbPath = @"C:\Users\majimenezp\Documents\Visual Studio 2010\Projects\Presentaciones\Nancy\EjemploAspNet\BasedeDatos.s3db";
        public principal()
        {
            Get["/"] = x => {
                return View["principal", new { titulo = "Pagina Principal" }];
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