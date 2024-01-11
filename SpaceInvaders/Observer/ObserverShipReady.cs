using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverShipReady : Observer
    {
        public override void Notify()
        {
            Ship pShip = ShipManager.GetShip();

            pShip.Handle();
        }
    }
}
