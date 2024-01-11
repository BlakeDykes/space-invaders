using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverRemoveSoundLoopUFO : Observer
    {
        public ObserverRemoveSoundLoopUFO()
        {
        }
        public override void Notify()
        {
            TimerEvent pEvent = TimerManager.Find(TimerEvent.Name.LoopSoundUFO);
            if(pEvent != null)
            {
                TimerManager.Remove(pEvent);
            }
        }
    }
}
