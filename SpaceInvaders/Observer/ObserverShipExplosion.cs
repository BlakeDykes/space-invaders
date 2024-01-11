using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverShipExplosion : Observer
    {
        public override void Notify()
        {
            TimerManager.SetShipExploding(true);
            GameObjectNodeManager.SetShipExploding(true);
        }
    }
}
