using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class DelayedEventManager
    {
        private static DelayedEventManager instance = null;
        private SLinkManager poEventList;

        private DelayedEventManager()
        {
            this.poEventList = new SLinkManager();
        }

        public static void Create()
        {
            Debug.Assert(instance == null);
            if (instance == null)
            {
                instance = new DelayedEventManager();
            }
        }

        public static void Process()
        {
            DelayedEventManager inst = DelayedEventManager.GetInstance();
            IteratorBase pIt = inst.poEventList.GetIterator();

            Observer pCur = (Observer)pIt.First();
            Observer pTemp = null;

            // walk - execute - remove
            while(pCur != null)
            {
                pTemp = pCur;
                pCur.Execute();
                pCur = (Observer)pIt.Next();
                inst.poEventList.Remove(pTemp);
            }
        }

        public static void Attach(Observer pObserver)
        {
            DelayedEventManager inst = DelayedEventManager.GetInstance();

            inst.poEventList.Add(pObserver);
        }


        private static DelayedEventManager GetInstance()
        {
            Debug.Assert(instance != null);
            return instance;
        }
    }
}
