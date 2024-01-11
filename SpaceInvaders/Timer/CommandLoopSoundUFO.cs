using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CommandLoopSoundUFO : Command
    {
        public override void Execute(float deltaTime)
        {
            SoundManager.PlaySound(Sound.Name.UFOHigh);

            TimerManager.Add(TimerEvent.Name.LoopSoundUFO, deltaTime, this);
        }
    }
}
