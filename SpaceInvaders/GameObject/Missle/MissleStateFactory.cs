using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissleStateFactory
    {
        private static MissleStateFactory instance = null;

        private MissleStateFactory()
        {
        }

        public static MissleState CreateState(MissleManager.State stateName)
        {
            switch (stateName)
            {
                case MissleManager.State.Ready:
                    return new MissleStateMissleReady();
                case MissleManager.State.MissleFlying:
                    return new MissleStateFlying();
                default:
                    Debug.Assert(false);
                    return null;
            }
        }

        private static MissleStateFactory GetInstance()
        {
            if(instance != null)
            {
                return instance;
            }
            else
            {
                instance = new MissleStateFactory();
                return instance;
            }
        }
    }
}
