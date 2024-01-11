using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CommandTransitionToSelect : Command
    {
        public override void Execute(float deltaTime)
        {
            SceneManager.SetStateName(SceneState.StateName.Select);
        }
    }
}
