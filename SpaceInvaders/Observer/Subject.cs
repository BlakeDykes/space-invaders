using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class Subject
    {
        protected SLinkManager poObservers;

        public Subject()
        {
            this.poObservers = new SLinkManager();
        }

        public virtual void Attach(Observer pObserver)
        {
            Debug.Assert(pObserver != null);

            pObserver.pSubject = this;

            this.poObservers.Add(pObserver);
        }

        public virtual void Detach(Observer pObserver)
        {
            Debug.Assert(pObserver != null);

            poObservers.Remove(pObserver);
        }

        public virtual void Notify()
        {
            SLinkIterator pIt = (SLinkIterator)poObservers.GetIterator();

            Observer pCur = (Observer)pIt.First();
            Observer pTemp = null;
            while (pCur != null)
            {
                pTemp = pCur;
                pCur = (Observer)pIt.Next();
                pTemp.Notify();
            }
        }
    }
}
