using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CommandSpawnUFO : Command
    {
        Random rnd = new Random();
        float lowerDeltaBound = 25.0f;
        float upperDeltaBound = 40.0f;

        public override void Execute(float deltaTime)
        {
            UFOManager.ActivateUFO();

            float random = (float)rnd.NextDouble();

            float nextDelta = random * (upperDeltaBound - lowerDeltaBound) + lowerDeltaBound;

            TimerManager.Add(TimerEvent.Name.SpawnUFO, nextDelta, this);
        }
    }
}
