using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class InputStatePlay : InputState
    {
        public InputStatePlay()
        {
            this.StateName = InputState.State.Play;
        }
        public override void NotifyLeft(InputSubject pSubject)
        {
            pSubject.Notify();
        }

        public override void NotifyRight(InputSubject pSubject)
        {
            pSubject.Notify();
        }

        public override void NotifyShoot(InputSubject pSubject)
        {
            pSubject.Notify();
        }

        public override void NotifyEnter(InputSubject pSubject)
        {

        }
    }
}
