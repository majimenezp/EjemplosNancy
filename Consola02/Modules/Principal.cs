// -----------------------------------------------------------------------
// <copyright file="Principal.cs" company="Microsoft">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace Consola02.Modules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Nancy;
    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class Principal:NancyModule
    {
        public Principal()
        {
            Get["/"] = x =>
                {
                    return "Prueba de app de consola";
                };
            Get["/list/{id}"] = x =>
                {
                    return Respuesta(x);
                };
            Get["/list/"] = x =>
                {
                    return Respuesta(x);

                };
        }

        public Response Respuesta(dynamic parametros)
        {
            if (((string)parametros.id).Length > 0)
            {
                return "devuelvo un listado paginado";
            }
            else
            {
                return "devuelvo otra cosa";
            }
        }

    }
}
