using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObserverMoveLeft : Observer
    {
        public override void Notify()
        {
            Ship pShip = ShipManager.GetShip();
            if(pShip != null)
            {
                pShip.MoveLeft();
            }
        }
    }
}
