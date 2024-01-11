using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverMissleReady : Observer
    {
        public override void Notify()
        {
            MissleManager.Handle();
        }
    }
}
