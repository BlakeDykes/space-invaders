using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverRemoveUFO : Observer
    {
        private UFO pUFO;

        public ObserverRemoveUFO()
        {
            this.pUFO = UFOManager.GetUFO();
        }

        public ObserverRemoveUFO(UFO ufo)
        {
            this.pUFO = ufo;
        }

        public override void Notify()
        {
            ColPair pColPair = ColPairManager.GetActivePair();

            this.pUFO = (UFO)pColPair.GetGameObject(GameObject.Name.UFO);

            if(this.pUFO.MarkForDeletion == false)
            {
                this.pUFO.MarkForDeletion = true;

                ObserverRemoveUFO pObserver = new ObserverRemoveUFO(this.pUFO);
                DelayedEventManager.Attach(pObserver);
            }
        }

        public override void Execute()
        {
            this.pUFO.Remove();
        }
    }
}
