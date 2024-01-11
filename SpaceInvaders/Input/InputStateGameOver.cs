using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class InputStateGameOver : InputState
    {
        public InputStateGameOver()
        {
            this.StateName = InputState.State.GameOver;
        }
        public override void NotifyLeft(InputSubject pSubject)
        {
        }
        public override void NotifyRight(InputSubject pSubject)
        {
        }
        public override void NotifyShoot(InputSubject pSubject)
        {
        }
        public override void NotifyEnter(InputSubject pSubject)
        {
        }
    }
}
