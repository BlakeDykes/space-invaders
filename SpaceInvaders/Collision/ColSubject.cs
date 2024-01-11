using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ColSubject : Subject
    {
        public GameObject pObjA;
        public GameObject pObjB;

        public ColSubject()
            :base()
        {
        }

        public void SetCollision(GameObject _pObjA, GameObject _pObjB)
        {
            this.pObjA = _pObjA;
            this.pObjB = _pObjB;
        }

        public GameObject GetGameObject(GameObject.Name name)
        {
            if (this.pObjA.GOName == name)
            {
                return this.pObjA;
            }
            else if (this.pObjB.GOName == name)
            {
                return this.pObjB;
            }
            else
            {
                return null;
            }
        }

        public GameObject GetAlienObject()
        {
            if (this.pObjA.GOName == GameObject.Name.Crab
                || this.pObjA.GOName == GameObject.Name.Octo
                || this.pObjA.GOName == GameObject.Name.Squid
                || this.pObjA.GOName == GameObject.Name.UFO)
            {
                return this.pObjA;
            }
            else if (this.pObjB.GOName == GameObject.Name.Crab
                        || this.pObjB.GOName == GameObject.Name.Octo
                        || this.pObjB.GOName == GameObject.Name.Squid
                        || this.pObjB.GOName == GameObject.Name.UFO)
            {
                return this.pObjB;
            }
            else
            {
                Debug.Assert(false);
                return null;
            }
        }
    }
}
