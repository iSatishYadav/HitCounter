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

        static int _current;
        static int _total;
        public void Hit()
        {
            _current++;
            _total++;
            Clients.All.hit(_current, _total);
        }
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            _current--;
            Clients.All.hit(_current, _total);
            return base.OnDisconnected(stopCalled);
        }

    }
}