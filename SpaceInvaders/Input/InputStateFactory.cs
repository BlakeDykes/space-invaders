using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class InputStateFactory
    {
        public static InputStateFactory instance = null;

        private InputStateFactory()
        {

        }

        public static InputState CreateState(InputState.State stateName)
        {
            switch (stateName)
            {
                case InputState.State.Play:
                    return new InputStatePlay();
                case InputState.State.Select:
                    return new InputStateSelect();
                case InputState.State.GameOver:
                    return new InputStateGameOver();
                default:
                    Debug.Assert(false);
                    return null;
            }
        }

        private static InputStateFactory GetInstance()
        {
            if(instance != null)
            {
                return instance;
            }
            else
            {
                instance = new InputStateFactory();
                return instance;
            }
        }
    }
}
