using System;
using System.Net;
using Kayak;
using Nancy;
using Nancy.Conventions;
namespace EjemploKayak
{
    public class KayakStarter : ISchedulerDelegate
    {
        public static void Start(int port, bool debug)
        {
            NuestroBootstrapper bootstrapper = new NuestroBootstrapper();
            Gate.Hosts.Kayak.KayakGate.Start(
                new KayakStarter(),
                new IPEndPoint(IPAddress.Any, port),
                Gate.Adapters.Nancy.NancyAdapter.App(bootstrapper));
        }

        public void OnException(IScheduler scheduler, Exception e)
        {
        }

        public void OnStop(IScheduler scheduler)
        {
        }
    }

    public class NuestroBootstrapper : DefaultNancyBootstrapper
    {
        protected override Nancy.Diagnostics.DiagnosticsConfiguration DiagnosticsConfiguration
        {
            get
            {
                return new Nancy.Diagnostics.DiagnosticsConfiguration { Password = "alt.net" };
            }
        }

        //protected override void ConfigureConventions(Nancy.Conventions.NancyConventions nancyConventions)
        //{
        //    base.ConfigureConventions(nancyConventions);

        //    Conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("assets", @"carpeta\contenido"));
        //}
    }
}
