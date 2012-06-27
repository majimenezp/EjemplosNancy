using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
namespace EjemploKayak.Entidades
{
    public class Persona
    {
        public virtual int Id { get; set; }
        public virtual string Nombres { get; set; }
        public virtual string Apellidos { get; set; }
        public virtual DateTime  FechaNacimiento { get; set; }
        public Persona()
        {
            FechaNacimiento = DateTime.Now.AddYears(-20);
        }
    }

    public class PersonaMapping:ClassMap<Persona>
    {
        public PersonaMapping()
        {
         Table("Personas");
            Id(x=>x.Id).GeneratedBy.Identity();
            Map(x=>x.Nombres).Length(100).Not.Nullable();
            Map(x=>x.Apellidos).Length(100).Not.Nullable();
            Map(x => x.FechaNacimiento).Not.Nullable();
        }
    }
}