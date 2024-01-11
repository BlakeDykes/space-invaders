using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShipManager
    {
        private static ShipManager instance = null;

        public Ship pShip;
        public Missle pMissle;

        private ShipGroup pShipGroup;
        private ShipState poHeadState;
        private ShipState poState;

        public enum State
        {
            Ready,
            CollidingRight,
            CollidingLeft,
            Dead
        }

        private ShipManager()
        {
            this.pMissle = null ;
            this.poHeadState = null;
            this.poState = null;

            this.pShipGroup = new ShipGroup();
            GameObjectNodeManager.Attach(pShipGroup);
        }

        public static void Create()
        {
            if(instance == null)
            {
                instance = new ShipManager();

                AttachState(State.Dead);
                AttachState(State.Ready);
                AttachState(State.CollidingRight);
                AttachState(State.CollidingLeft);
            }
            else
            {
                ShipManager inst = ShipManager.GetInstance();
                inst.Reset();
            }
        }

        public static ShipState GetState(ShipManager.State inState)
        {
            ShipManager inst = ShipManager.GetInstance();
            Debug.Assert(inst != null);

            inst.poState = inst.poHeadState;

            while(inst.poState != null && inst.poState.StateName != inState)
            {
                inst.poState = (ShipState)inst.poState.pNext;
            }

            return inst.poState;
        }

        public static void AttachState(ShipManager.State inState)
        {
            ShipManager inst = ShipManager.GetInstance();
            Debug.Assert(inst != null);

            if(ShipManager.GetState(inState) == null)
            {
                ShipState pState = ShipStateFactory.CreateState(inState);
                pState.pNext = inst.poHeadState;
                inst.poHeadState = pState;
            }
        }

        public static Ship GetShip()
        {
            ShipManager inst = ShipManager.GetInstance();
            Debug.Assert(inst != null);

            return inst.pShip;
        }

        public static Ship ActivateShip()
        {
            ShipManager inst = ShipManager.GetInstance();
            Debug.Assert(inst != null);

            if (inst.pShip != null)
            {
                return null;
            }

            // Create ship
            inst.pShip = (Ship)ShipFactory.CreateShip();
            inst.pShip.SetState(State.Ready);
            return inst.pShip;
        }

        public static void RemoveShip()
        {
            ShipManager inst = ShipManager.GetInstance();

            inst.pShip = null;
        }

        public static ShipGroup GetGroup()
        {
            ShipManager inst = ShipManager.GetInstance();

            return inst.pShipGroup;
        }

        private void Reset()
        {
            this.pShip = null;
            this.pMissle = null;


            this.pShipGroup = new ShipGroup();
            GameObjectNodeManager.Attach(pShipGroup);
        }

        private static ShipManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }
    }
}
