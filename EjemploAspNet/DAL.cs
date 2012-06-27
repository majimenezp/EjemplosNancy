using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using EjemploAspNet.Entidades;
using NHibernate.Linq;
namespace EjemploAspNet
{
    public class DAL
    {
        private static readonly Lazy<DAL> instancia = new Lazy<DAL>(() => new DAL());
        ISessionFactory Sesion;
        public static DAL Instancia { get { return instancia.Value; } }
        private DAL()
        {
            Sesion = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.ConnectionString(x=>x.FromConnectionStringWithKey("conexion")))
               .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Entidades.Persona>())
               .ExposeConfiguration(BuildSchema)
               .BuildSessionFactory();
        }
        private static void BuildSchema(Configuration config)
        {
            new SchemaExport(config).Create(false, true);
        }

        internal Persona[] ObtenerPersonas()
        {
            Persona[] resultados = null;
            using (var sesion = Sesion.OpenSession())
            {
                resultados=sesion.Query<Persona>().ToArray();
            }
            return resultados;
        }

        internal bool Guardar(Persona nuevo)
        {
            bool resultado=false;
            using (var sesion = Sesion.OpenSession())
            {
                using (var trans = sesion.BeginTransaction())
                {
                    try
                    {
                        sesion.SaveOrUpdate(nuevo);
                        trans.Commit();
                        resultado = true;
                    }
                    catch
                    {
                        resultado = false;
                    }
                }
            }
            return resultado;
        }

        internal Persona TraerPersonaPorId(int id)
        {
            Persona entidad = null;
            using (var sesion = Sesion.OpenSession())
            {
                entidad=sesion.Get<Persona>(id);
            }
            return entidad;
        }
    }
}