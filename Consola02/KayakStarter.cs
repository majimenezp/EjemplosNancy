using System;
using System.Net;
using Kayak;
using Nancy;

namespace Consola02
{
    public class KayakStarter : ISchedulerDelegate
    {
        public static void Start(int port, bool debug)
        {
            Gate.Hosts.Kayak.KayakGate.Start(
                new KayakStarter(),
                new IPEndPoint(IPAddress.Any, port),
                Gate.Adapters.Nancy.NancyAdapter.App());
        }

        public void OnException(IScheduler scheduler, Exception e)
        {
        }

        public void OnStop(IScheduler scheduler)
        {
        }
    }
}
