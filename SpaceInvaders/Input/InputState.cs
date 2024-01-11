using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class InputState : SLink
    {
        public InputState.State StateName;
        public enum State
        {
            Select,
            Play,
            GameOver
        }
        public abstract void NotifyLeft(InputSubject pSubject);
        public abstract void NotifyRight(InputSubject pSubject);
        public abstract void NotifyShoot(InputSubject pSubject);
        public abstract void NotifyEnter(InputSubject pSubject);
    }
}
