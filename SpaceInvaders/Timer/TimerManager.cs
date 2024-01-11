using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class TimerManager : ManagerBase
    {
        private static TimerManager instance = null;
        private TimerManager pActiveTimerMan;
        private float CurTime;
        private TimerEvent pCompareEvent;
        private bool ShipExploding;

        public TimerManager(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved, float time)
            : base(active, reserved, deltaGrow, initialReserved)
        {
            CurTime = time;
            pCompareEvent = new TimerEvent();
            ShipExploding = false;
        }

        public static void Create(CollectionBase active, CollectionBase reserved, int deltaGrow, int initialReserved, float time)
        {
            Debug.Assert(active != null);
            Debug.Assert(reserved != null);
            Debug.Assert(deltaGrow != 0);

            Debug.Assert(instance == null);

            if (instance == null)
            {
                // LTN - the process
                instance = new TimerManager(active, reserved, deltaGrow, initialReserved, time);
            }
        }

        public static TimerEvent Add(TimerEvent.Name name, float deltaTime, Command _pCommand, bool deleteOnShipExplosion = false)
        {
            TimerManager inst = TimerManager.GetActiveInstance();
            Debug.Assert(inst != null);

            TimerEvent pEv = (TimerEvent)inst.BaseAdd(deltaTime);
            Debug.Assert(pEv != null);

            pEv.Set(name, deltaTime, _pCommand, deleteOnShipExplosion);

            return pEv;
        }

        public static void Update(float totalTime)
        {
            TimerManager inst = TimerManager.GetActiveInstance();
            Debug.Assert(inst != null);

            IteratorBase it = inst.BaseGetIterator();

            inst.CurTime = totalTime;

            TimerEvent pCur = (TimerEvent)it.First();
            TimerEvent pNext = null;

            while(it.IsDone() == false)
            {
               if(pCur.TriggerTime <= inst.CurTime)
                {
                    // pause all events but ship exploding
                    if (inst.ShipExploding)
                    {
                        if (pCur.EventName == TimerEvent.Name.AnimateShipExplosion)
                        {
                            // Get next before executing, just in case we add a new one before next
                            pNext = (TimerEvent)it.Next();
                            pCur.Execute(inst.CurTime);
                            TimerEvent pPrev = pCur;
                            pCur = pNext;
                            Remove(pPrev);
                        }
                        else
                        {
                            pCur = (TimerEvent)it.Next();
                        }
                    }
                    else
                    {
                        // Get next before executing, just in case we add a new one before next
                        pNext = (TimerEvent)it.Next();
                        pCur.Execute(inst.CurTime);
                        TimerEvent pPrev = pCur;
                        pCur = pNext;
                        Remove(pPrev);
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public static TimerEvent Remove(TimerEvent pEv)
        {
            TimerManager inst = TimerManager.GetActiveInstance();
            Debug.Assert(inst != null);

            return (TimerEvent)inst.BaseRemove(pEv);
        }

        public static TimerEvent Find(TimerEvent.Name name)
        {
            TimerManager inst = TimerManager.GetActiveInstance();
            Debug.Assert(inst != null);

            inst.pCompareEvent.EventName = name;

            return (TimerEvent)inst.BaseFind(inst.pCompareEvent);
        }

        public void AddTimeToEvents(float time)
        {
            IteratorBase it = this.BaseGetIterator();

            TimerEvent pCur = (TimerEvent)it.First();

            while(it.IsDone() == false)
            {
                pCur.TriggerTime += time;
                pCur = (TimerEvent)it.Next();
            }
        }

        public static void Clear()
        {
            TimerManager inst = TimerManager.GetActiveInstance();
            inst.BaseClear();
        }

        public static float GetCurTime()
        {
            TimerManager inst = TimerManager.GetActiveInstance();
            Debug.Assert(inst != null);

            return inst.CurTime;
        }

        protected override NodeBase DerivedCreateNode()
        {
            // LTN - TimerManager
            return new TimerEvent();
        }

        private static TimerManager GetInstance()
        {
            Debug.Assert(instance != null);

            return instance;
        }

        public static void SetActive(TimerManager spriteBatchManager, float systemTime)
        {
            TimerManager inst = TimerManager.GetInstance();

            Debug.Assert(spriteBatchManager != null);

            inst.pActiveTimerMan = spriteBatchManager;
            if (systemTime != 0.0f)
            {
                inst.pActiveTimerMan.AddTimeToEvents(systemTime - inst.pActiveTimerMan.CurTime);
                inst.pActiveTimerMan.CurTime = systemTime;
            }
        }

        private static TimerManager GetActiveInstance()
        {
            TimerManager inst = TimerManager.GetInstance();
            
            Debug.Assert(inst.pActiveTimerMan != null);
            return inst.pActiveTimerMan;
        }

        public static void SetShipExploding(bool isExploding)
        {
            TimerManager inst = TimerManager.GetActiveInstance();

            inst.ShipExploding = isExploding;
        }
        
        public static bool GetShipExploding()
        {
            TimerManager inst = TimerManager.GetActiveInstance();

            return inst.ShipExploding;
        }
    }
}
