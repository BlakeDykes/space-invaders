using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipStateFactory
    {
        public static ShipStateFactory instance = null;

        private ShipStateFactory()
        {
        }

        public static ShipState CreateState(ShipManager.State stateName)
        {
            switch (stateName) 
            {
                case ShipManager.State.Ready:
                    return new ShipStateReady();
                case ShipManager.State.Dead:
                    return new ShipStateDead();
                case ShipManager.State.CollidingLeft:
                    return new ShipStateCollidingLeft();
                case ShipManager.State.CollidingRight:
                    return new ShipStateCollidingRight();
                default:
                    Debug.Assert(false);
                    return null;
            }
        }

        private static ShipStateFactory GetInstance()
        {
            if(instance != null)
            {
                return instance;
            }
            else
            {
                instance = new ShipStateFactory();
                return instance;
            }
        }
    }
}
