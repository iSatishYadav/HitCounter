using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace HitCounter
{
    public class HitCounterHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }

        static int _hitCounter;

        public void Hit()
        {
            _hitCounter++;
            Clients.All.hit(_hitCounter);
        }
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            _hitCounter--;
            Clients.All.hit(_hitCounter);
            return base.OnDisconnected(stopCalled);
        }

    }
}