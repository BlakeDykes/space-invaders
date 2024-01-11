using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class MissleManager
    {
        private static MissleManager instance = null;

        public MissleGroup pMissleGroup;
        private MissleState poHeadState;
        private MissleState poState;

        public enum State
        {
            Ready,
            MissleFlying,
        }

        private MissleManager()
        {
            this.poHeadState = null;
            this.poState = null;

            this.pMissleGroup = new MissleGroup();
            GameObjectNodeManager.Attach(pMissleGroup, true);
        }

        public static void Create()
        {
            if(instance == null)
            {
                instance = new MissleManager();

                AttachState(State.Ready);
                AttachState(State.MissleFlying);

                SetState(State.Ready);
            }
            else
            {
                MissleManager inst = MissleManager.GetInstance();
                inst.Reset();
            }
        }

        public static MissleState GetState(MissleManager.State inState)
        {
            MissleManager inst = MissleManager.GetInstance();

            inst.poState = inst.poHeadState;

            while (inst.poState != null && inst.poState.StateName != inState)
            {
                inst.poState = (MissleState)inst.poState.pNext;
            }

            return inst.poState;
        }

        public static void AttachState(MissleManager.State inState)
        {
            MissleManager inst = MissleManager.GetInstance();

            if(MissleManager.GetState(inState) == null)
            {
                MissleState pState = MissleStateFactory.CreateState(inState);
                pState.pNext = inst.poHeadState;
                inst.poHeadState = pState;
            }
        }

        public static void ShootMissle()
        {
            MissleManager inst = MissleManager.GetInstance();
            inst.poState.ShootMissle();
        }

        public static Missle ActivateMissle()
        {
            MissleManager inst = MissleManager.GetInstance();
            Ship pShip = ShipManager.GetShip();

            Missle pMissle = (Missle)MissleFactory.CreateMissle(pShip.x, pShip.y);

            return pMissle;
        }

        private static MissleManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }

        public static MissleGroup GetGroup()
        {
            MissleManager inst = MissleManager.GetInstance();
            return inst.pMissleGroup;
        }

        public static void Handle()
        {
            MissleManager inst = MissleManager.GetInstance();
            inst.poState.Handle();
        }

        public static void SetState(MissleManager.State inState)
        {
            MissleManager inst = MissleManager.GetInstance();
            MissleManager.GetState(inState);
        }

        public static MissleState GetState()
        {
            MissleManager inst = MissleManager.GetInstance();
            return inst.poState;
        }

        private void Reset()
        {
            this.pMissleGroup = new MissleGroup();
            GameObjectNodeManager.Attach(pMissleGroup, true);
        }
    }
}
