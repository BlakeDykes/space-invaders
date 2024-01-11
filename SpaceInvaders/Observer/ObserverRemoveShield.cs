using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverRemoveShield : Observer
    {
        private ShieldBase pShield;

        public ObserverRemoveShield()
        {
            pShield = null;
        }

        public ObserverRemoveShield(ShieldBase _pShield)
        {
            this.pShield = _pShield;
        }

        public override void Notify()
        {
            ColSubject pColSubject = (ColSubject)this.pSubject;
            Debug.Assert(pColSubject != null);

            this.pShield = (ShieldBase)pColSubject.pObjB;

            if(pColSubject.pObjA.GOName == GameObject.Name.Missle)
            {
                while(this.pShield.pNext != null)
                {
                    this.pShield = (ShieldBase)this.pShield.pNext;
                }
            }

            if(this.pShield.MarkForDeletion == false)
            {
                this.pShield.MarkForDeletion = true;

                ObserverRemoveShield pObserver = new ObserverRemoveShield(this.pShield);
                DelayedEventManager.Attach(pObserver);
            }
        }

        public override void Execute()
        {
            GameObject pColumn = (GameObject)pShield.GetParent();
            GameObject pGrid = (GameObject)pColumn.GetParent();

            this.pShield.Remove();

            if(pColumn.GetChild() == null)
            {
                pColumn.Remove();
            }

            if(pGrid.GetChild() == null)
            {
                pGrid.Remove();
            }

        }
    }
}
