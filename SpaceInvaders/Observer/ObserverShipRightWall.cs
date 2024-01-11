using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverShipRightWall : Observer
    {
        public Ship pShip;
        public WallBase pWall;

        public override void Notify()
        {
            ColSubject pColSubj = (ColSubject)this.pSubject;
            Debug.Assert(pColSubj != null);

            this.pShip = (Ship)pColSubj.pObjA;
            this.pWall = (WallBase)pColSubj.pObjB;

            if (this.pWall.wallType == WallBase.WallType.Right)
            {
                pShip.SetState(ShipManager.State.CollidingRight);

                // Gaurding for overlap
                if (pShip.poColObj.poColRect.maxX > pWall.poColObj.poColRect.minX)
                {
                    pShip.x = pWall.poColObj.poColRect.minX - (pShip.poColObj.poColRect.width * 0.5f);
                }

                pShip.Update();

            }
        }
    }
}
