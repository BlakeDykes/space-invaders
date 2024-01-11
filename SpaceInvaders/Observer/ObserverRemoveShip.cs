using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverRemoveShip : Observer
    {
        private Ship pShip;

        public ObserverRemoveShip()
        {
            this.pShip = null;
        }

        public ObserverRemoveShip(Ship _pShip)
        {
            this.pShip = _pShip;
        }

        public override void Notify()
        {
            ColSubject pColSubj = (ColSubject)this.pSubject;
            Debug.Assert(pColSubj != null);

            if (pColSubj.pObjA.GOName == GameObject.Name.Ship)
            {
                this.pShip = (Ship)pColSubj.pObjA;
            }
            else
            {
                this.pShip = (Ship)pColSubj.pObjB;
            }

            this.pShip.SetState(ShipManager.State.Dead);

            if (this.pShip.MarkForDeletion == false)
            {
                pShip.MarkForDeletion = true;

                ObserverRemoveShip pObserver = new ObserverRemoveShip(this.pShip);
                DelayedEventManager.Attach(pObserver);
            }
        }

        public override void Execute()
        {
            this.pShip.Remove();
            SoundManager.PlaySound(Sound.Name.Explosion);
        }
    }
}
