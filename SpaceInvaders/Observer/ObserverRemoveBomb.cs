using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverRemoveBomb : Observer
    {
        private BombBase pBomb;

        public ObserverRemoveBomb()
        {
            this.pBomb = null;
        }

        public ObserverRemoveBomb(BombBase _pBomb)
        {
            this.pBomb = _pBomb;
        }

        public override void Notify()
        {
            ColSubject pColSubj = (ColSubject)this.pSubject;
            Debug.Assert(pColSubj != null);

            if(pColSubj.pObjA.GOName == GameObject.Name.Bomb)
            {
                this.pBomb = (BombBase)pColSubj.pObjA;
            }
            else
            {
                this.pBomb = (BombBase)pColSubj.pObjB;
            }

            if (this.pBomb.MarkForDeletion == false)
            {
                pBomb.MarkForDeletion = true;

                ObserverRemoveBomb pObserver = new ObserverRemoveBomb(this.pBomb);
                DelayedEventManager.Attach(pObserver);
            }
        }

        public override void Execute()
        {
            this.pBomb.Remove();
        }
    }
}
