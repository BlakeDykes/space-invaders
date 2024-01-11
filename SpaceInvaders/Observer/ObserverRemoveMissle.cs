using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObserverRemoveMissle : Observer
    {
        private Missle pMissle;
        
        public ObserverRemoveMissle()
        {
            this.pMissle = null;
        }

        public ObserverRemoveMissle(Missle _pMissle)
        {
            this.pMissle = _pMissle;
        }

        public override void Notify()
        {
            ColSubject pColSubj = (ColSubject)this.pSubject;
            Debug.Assert(pColSubj != null);

            if (pColSubj.pObjA.GOName == GameObject.Name.Missle)
            {
                this.pMissle = (Missle)pColSubj.pObjA;
            }
            else
            {
                this.pMissle = (Missle)pColSubj.pObjB;
            }

            if (this.pMissle.MarkForDeletion == false)
            {
                pMissle.MarkForDeletion = true;

                ObserverRemoveMissle pObserver = new ObserverRemoveMissle(this.pMissle);
                DelayedEventManager.Attach(pObserver);
            }
        }

        public override void Execute()
        {
            this.pMissle.Remove();
        }
    }
}
