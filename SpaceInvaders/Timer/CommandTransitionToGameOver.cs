using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CommandTransitionToGameOver : Command
    {
        public override void Execute(float deltaTime)
        {
            SceneManager.SetStateName(SceneState.StateName.GameOver);
        }
    }
}
