using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObserverMoveRight : Observer
    {
        public override void Notify()
        {
            Ship pShip = ShipManager.GetShip();
            if(pShip != null)
            {
                pShip.MoveRight();
            }
        }
    }
}
