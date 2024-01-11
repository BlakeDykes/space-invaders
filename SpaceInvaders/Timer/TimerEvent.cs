using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TimerEvent : DLink
    {
        public float DeltaTime;
        public TimerEvent.Name EventName;
        public float TriggerTime;
        public Command pCommand;

        bool DeleteOnShipExplosion;

        public enum Name 
        {
            DropBomb,

            MoveShipLeft,
            MoveShipRight,
            ShootMissle,

            SpawnUFO,
            LoopSoundUFO,

            RemoveExplosion,
            AnimateShipExplosion,

            AlienAnimationMoveLoop,

            TransitionToSelect,

            Uninitialized
        }

        public TimerEvent()
        {
            this.DeltaTime = 0.0f;
            this.EventName = Name.Uninitialized;
            this.TriggerTime = 0.0f;
            this.pCommand = null;
        }
        public void Set(TimerEvent.Name name, float deltaTime, Command _pCommand, bool deleteOnShipExplosion)
        {
            this.DeltaTime = deltaTime;
            this.EventName = name;
            this.TriggerTime = TimerManager.GetCurTime() + deltaTime;
            this.pCommand = _pCommand;
            this.DeleteOnShipExplosion = deleteOnShipExplosion;
        }

        public void Execute(float curTime)
        {
            Debug.Assert(this.pCommand != null);
            this.pCommand.Execute(DeltaTime);
        }

        public override PriorityCompResult ComparePriority(float priority)
        {
            return this.DeltaTime > priority ? PriorityCompResult.GREATER_THAN : PriorityCompResult.LESS_THAN;
        }

        public override void Wash()
        {
            base.Wash();
            this.DeltaTime = 0.0f;
            this.EventName = Name.Uninitialized;
            this.TriggerTime = 0.0f;
            this.pCommand = null;
        }

        public override bool Compare(NodeBase pNode)
        {
            TimerEvent pComp = (TimerEvent)pNode;

            return this.EventName == pComp.EventName;
        }

    }
}
