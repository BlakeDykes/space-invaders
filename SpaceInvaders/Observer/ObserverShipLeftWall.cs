using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverShipLeftWall : Observer
    {
        WallBase pWall;
        Ship pShip;

        public override void Notify()
        {
            ColSubject pColSubj = (ColSubject)this.pSubject;
            Debug.Assert(pColSubj != null);

            this.pShip = (Ship)pColSubj.pObjA;
            this.pWall = (WallBase)pColSubj.pObjB;

            if(this.pWall.wallType == WallBase.WallType.Left)
            {
                pShip.SetState(ShipManager.State.CollidingLeft);

                // Gaurding for overlap
                if (pShip.poColObj.poColRect.minX < pWall.poColObj.poColRect.maxX)
                {
                    pShip.x = pWall.poColObj.poColRect.maxX + (pShip.poColObj.poColRect.width * 0.5f);
                }

                pShip.Update();
            }
        }
    }
}
