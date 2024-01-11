using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class ObserverRemoveAlien : Observer
    {
        private AlienBase pAlien;

        public ObserverRemoveAlien()
        {
            this.pAlien = null;
        }

        public ObserverRemoveAlien(AlienBase _pAlien)
        {
            this.pAlien = _pAlien;
        }

        public override void Notify()
        {
            ColSubject pColSubj = (ColSubject)this.pSubject;
            Debug.Assert(pColSubj != null);

            this.pAlien = (AlienBase)pColSubj.pObjB;

            if(this.pAlien.MarkForDeletion == false)
            {
                this.pAlien.MarkForDeletion = true;

                ObserverRemoveAlien pObserver = new ObserverRemoveAlien(this.pAlien);
                DelayedEventManager.Attach(pObserver);
            }
        }

        public override void Execute()
        {
            GameObject pColumn = (GameObject)pAlien.GetParent();

            this.pAlien.Remove();
            SoundManager.PlaySound(Sound.Name.AlienKilled);

            if (pColumn.GetChild() == null)
            {
                pColumn.Remove();
            }
        }
    }
}
