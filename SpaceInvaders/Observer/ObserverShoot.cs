using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObserverShoot : Observer
    {
        public override void Notify()
        {
             Ship pShip = ShipManager.GetShip();
            if(pShip != null)
            {
                pShip.ShootMissle();
            }
        }
    }
}
