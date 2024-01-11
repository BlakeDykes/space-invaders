using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ColPair : DLink
    {
        public ColPair.Name ColName;
        public GameObject TreeA;
        public GameObject TreeB;
        public ColSubject pSubject;

        public enum Name
        {
            Missle_Alien,
            Missle_Wall,
            Missle_Shield,
            Missle_Bomb,
            Missle_UFO,

            Bomb_Shield,
            Bomb_Ship,
            Bomb_Wall,

            Alien_Wall,
            Ship_Wall,
            UFO_Wall,


            Uninitialized
        }

        public ColPair()
        {
            this.ColName = Name.Uninitialized;
            this.TreeA = null;
            this.TreeB = null;
            this.pSubject = new ColSubject();
        }

        public ColPair(ColPair.Name name, GameObject treeA, GameObject treeB)
        {
            this.ColName = name;
            this.TreeA = treeA;
            this.TreeB = treeB;
            this.pSubject = new ColSubject();
        }

        public void Set(ColPair.Name name, GameObject treeA, GameObject treeB)
        {
            this.ColName = name;
            this.TreeA = treeA;
            this.TreeB = treeB;
            this.pSubject = new ColSubject();
        }

        public void Process()
        {
            Collide(this.TreeA, this.TreeB);
        }

        public static void Collide(GameObject treeA, GameObject treeB)
        {
            GameObject pNodeA = treeA;
            GameObject pNodeB = treeB;

            while(pNodeA != null)
            {
                pNodeB = treeB;

                while(pNodeB != null)
                {
                    if (pNodeA.poColObj.poColRect.Intersect(pNodeB.poColObj.poColRect))
                    {
                        pNodeA.Accept(pNodeB);
                        break;
                    }

                    pNodeB = (GameObject)CompositeIterator.GetSibling(pNodeB);
                }
                pNodeA = (GameObject)CompositeIterator.GetSibling(pNodeA);
            }
        }

        public void AttachObserver(Observer pObserver)
        {
            Debug.Assert(this.pSubject != null);
            Debug.Assert(pObserver != null);

            this.pSubject.Attach(pObserver);
        }

        public void SetCollision(GameObject _pObjA, GameObject _pObjB)
        {
            this.pSubject.SetCollision(_pObjA, _pObjB);
        }

        public void Notify()
        {
            Debug.Assert(this.pSubject != null);
            this.pSubject.Notify();
        }

        public override bool Compare(NodeBase pNode)
        {
            ColPair pCompNode = (ColPair)pNode;
            return (this.ColName == pCompNode.ColName);
        }

        public GameObject GetGameObject(GameObject.Name name)
        {
            return this.pSubject.GetGameObject(name);
        }

        public GameObject GetAlienObject()
        {
            return this.pSubject.GetAlienObject();
        }
    }
}
