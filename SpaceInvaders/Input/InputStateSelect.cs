using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class InputStateSelect : InputState
    {
        public InputStateSelect()
        {
            this.StateName = InputState.State.Select;
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
            pSubject.Notify();
        }

    }
}
