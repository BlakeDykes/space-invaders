using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public abstract class GameObject : Component
    {
        public GameObject.Name GOName;
        public float x;
        public float y;
        public SpriteProxy pSpriteProxy;
        public ColObject poColObj;
        public bool isGhost;
        public bool MarkForDeletion;

        public enum Name
        {
            AlienGrid,
            AlienColumn,

            Crab,
            Octo,
            Squid,

            UFOGroup,
            UFO,

            BombGroup,
            Bomb,

            Ship,
            ShipGroup,
            Missle,
            MissleGroup,

            WallGroup,
            WallTop,
            WallLeft,
            WallRight,
            WallBottom,

            ShieldGroup,
            ShieldGrid,
            ShieldColumn,
            ShieldBrick,

            Null_Object,
            Uninitialized
        }

        public GameObject(GameObject.Name _name, Sprite.Name _proxyName, Azul.Color pColor)
        {
            this.GOName = _name;
            this.x = 0.0f;
            this.y = 0.0f;
            this.pSpriteProxy = SpriteProxyManager.Add(_proxyName);
            this.poColObj = new ColObject(this.pSpriteProxy);
            this.MarkForDeletion = false;
            this.isGhost = false;
        }

        public GameObject(GameObject.Name _name, Sprite.Name _spriteName, float _x, float _y, Azul.Color pColor)
        {
            this.GOName = _name;
            this.x = _x;
            this.y = _y;
            this.pSpriteProxy = SpriteProxyManager.Add(_spriteName, _x, _y);
            this.pSpriteProxy.SwapColor(pColor);
            this.poColObj = new ColObject(this.pSpriteProxy);
            this.MarkForDeletion = false;
            this.isGhost = false;
        }

        public GameObject(GameObject.Name _name, Sprite.Name _spriteName, float _x, float _y, float _width, float _height, Azul.Color pColor)
        {
            this.GOName = _name;
            this.x = _x;
            this.y = _y;
            this.pSpriteProxy = SpriteProxyManager.Add(_spriteName, _x, _y);
            this.pSpriteProxy.SwapColor(pColor);
            this.poColObj = new ColObject(this.pSpriteProxy, _width, _height);
            this.MarkForDeletion = false;
            this.isGhost = false;
        }

        public override void Update()
        {
            Debug.Assert(this.pSpriteProxy != null);
            this.pSpriteProxy.UpdateLocal(this.x, this.y);

            Debug.Assert(this.poColObj != null);
            this.poColObj.UpdatePos(this.x, this.y);
        }

        public virtual void Remove()
        {
            // Remove from SpriteBatch
            Debug.Assert(this.pSpriteProxy != null);
            SpriteNode pSpriteNode = this.pSpriteProxy.GetParent();
            Debug.Assert(pSpriteNode != null);

            SpriteBatchManager.Remove(pSpriteNode);

            // Remove collision sprite from SpriteBatch
            Debug.Assert(poColObj != null);
            Debug.Assert(this.poColObj.pColSprite != null);
            pSpriteNode = this.poColObj.pColSprite.GetParent();

            SpriteBatchManager.Remove(pSpriteNode);

            // Remove from GameObjectManager
            GameObjectNodeManager.Remove(this);

            GhostManager.Attach(this);
        }

        public override void Recycle()
        {
            this.MarkForDeletion = false;
            Debug.Assert(this.pSpriteProxy != null);
            Debug.Assert(this.poColObj != null);

            this.isGhost = false;
            this.pSpriteProxy.UpdateLocal(this.x, this.y);

            this.poColObj.Recycle(this.pSpriteProxy);

            base.Recycle();
        }

        public void BaseUpdateColBox(Component pParent, out int count)
        {
            Debug.Assert(pParent != null);
            count = 0;

            GameObject pCur = (GameObject)pParent.GetChild();

            if(pCur != null)
            {
                // Update leaf count of parent
                if(pCur.ComponentType == Type.Composite)
                {
                    count += pCur.LeafCount;
                }
                else
                {
                    count++;
                }

                this.poColObj.poColRect.SetLocal(pCur.poColObj.poColRect);

                pCur = (GameObject)CompositeIterator.GetSibling(pCur);

                while (pCur != null)
                {

                    // Update leaf count of parent
                    if (pCur.ComponentType == Type.Composite)
                    {
                        count += pCur.LeafCount;
                    }
                    else
                    {
                        count++;
                    }

                    this.poColObj.poColRect.Union(pCur.poColObj.poColRect);
                    pCur = (GameObject)CompositeIterator.GetSibling(pCur);
                }

                this.poColObj.UpdateRec();

                this.x = this.poColObj.poColRect.x;
                this.y = this.poColObj.poColRect.y;
            }
            else
            {
                this.poColObj.poColRect.Clear();
            }
        }
    }
}
