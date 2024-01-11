using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ShieldFactory
    {
        private SpriteBatch pSpriteBatch;
        private SpriteBatch pCollisionBatch;
        private ShieldGroup poGroup;
        private GameObject pTree;
        private float BrickHeight;
        private float BrickWidth;

        public ShieldFactory(SpriteBatch.Name sbName, SpriteBatch.Name collisionBoxBatch, float brickWidth, float brickHeight)
        {
            this.pSpriteBatch = SpriteBatchManager.Find(sbName);
            Debug.Assert(this.pSpriteBatch != null);

            this.pCollisionBatch = SpriteBatchManager.Find(collisionBoxBatch);
            Debug.Assert(this.pCollisionBatch != null);

            this.poGroup = new ShieldGroup(GameObject.Name.ShieldGroup, 0.0f, 0.0f);
            this.pTree = poGroup;

            this.BrickHeight = brickHeight;
            this.BrickWidth = brickWidth;

            GameObjectNodeManager.Attach(this.pTree);
        }

        public void SetTree(GameObject tree)
        {
            this.pTree = tree;
        }

        private GameObject CreateBrick(ShieldBase.ShieldType shieldType, GameObject.Name goName, float x, float y)
        {
            GameObject pGO = null;

            switch (shieldType)
            {
                case ShieldBase.ShieldType.Grid:
                    pGO = new ShieldGrid(goName, x, y);
                    break;
                case ShieldBase.ShieldType.Column:
                    pGO = new ShieldColumn(goName, x, y);
                    break;
                case ShieldBase.ShieldType.Group:
                    pGO = new ShieldGroup(goName, x, y);
                    break;
                case ShieldBase.ShieldType.Brick_2_2:
                    pGO = new ShieldBrick(goName, Sprite.Name.Brick_2_2, x, y, ShieldBase.ShieldType.Brick_2_2, Constants.GREEN);
                    break;
                case ShieldBase.ShieldType.Brick_2_4:
                    pGO = new ShieldBrick(goName, Sprite.Name.Brick_2_4, x, y, ShieldBase.ShieldType.Brick_2_4, Constants.GREEN);
                    break;
                case ShieldBase.ShieldType.Brick_2_3:
                    pGO = new ShieldBrick(goName, Sprite.Name.Brick_2_3, x, y, ShieldBase.ShieldType.Brick_2_3, Constants.GREEN);
                    break;
                case ShieldBase.ShieldType.Brick_3_4:
                    pGO = new ShieldBrick(goName, Sprite.Name.Brick_3_4, x, y, ShieldBase.ShieldType.Brick_3_4, Constants.GREEN);
                    break;
                case ShieldBase.ShieldType.Brick_3_3:
                    pGO = new ShieldBrick(goName, Sprite.Name.Brick_3_3, x, y, ShieldBase.ShieldType.Brick_3_3, Constants.GREEN);
                    break;
                case ShieldBase.ShieldType.Brick_3_2:
                    pGO = new ShieldBrick(goName, Sprite.Name.Brick_3_2, x, y, ShieldBase.ShieldType.Brick_3_2, Constants.GREEN);
                    break;
                case ShieldBase.ShieldType.LeftTop0:
                    pGO = new ShieldBrick(goName, Sprite.Name.Brick_LeftTop0, x, y, ShieldBase.ShieldType.LeftTop0, Constants.GREEN);
                    break;
                case ShieldBase.ShieldType.LeftTop1:
                    pGO = new ShieldBrick(goName, Sprite.Name.Brick_LeftTop1, x, y, ShieldBase.ShieldType.LeftTop1, Constants.GREEN);
                    break;
                case ShieldBase.ShieldType.LeftBottom:
                    pGO = new ShieldBrick(goName, Sprite.Name.Brick_LeftBottom, x, y, ShieldBase.ShieldType.LeftBottom, Constants.GREEN);
                    break;
                case ShieldBase.ShieldType.RightTop0:
                    pGO = new ShieldBrick(goName, Sprite.Name.Brick_RightTop0, x, y, ShieldBase.ShieldType.RightTop0, Constants.GREEN);
                    break;
                case ShieldBase.ShieldType.RightTop1:
                    pGO = new ShieldBrick(goName, Sprite.Name.Brick_RightTop1, x, y, ShieldBase.ShieldType.RightTop1, Constants.GREEN);
                    break;
                case ShieldBase.ShieldType.RightBottom:
                    pGO = new ShieldBrick(goName, Sprite.Name.Brick_RightBottom, x, y, ShieldBase.ShieldType.RightBottom, Constants.GREEN);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            this.pTree.Add(pGO);

            this.pSpriteBatch.Attach(pGO);
            this.pCollisionBatch.Attach(pGO.poColObj.pColSprite);
            return pGO;
        }

        public ShieldGrid CreateShield(float _x, float _y)
        {

            this.SetTree(this.poGroup);

            GameObject pShieldGrid1 = this.CreateBrick(ShieldBase.ShieldType.Grid, GameObject.Name.ShieldGrid, 0.0f, 0.0f);

            this.SetTree(pShieldGrid1);

            GameObject pShieldColumn1 = this.CreateBrick(ShieldBase.ShieldType.Column, GameObject.Name.ShieldColumn, 0.0f, 0.0f);

            this.SetTree(pShieldColumn1);

            float xShieldLocation = _x;
            float yShieldLocation = _y;

            this.CreateBrick(ShieldBase.ShieldType.Brick_2_2, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.0f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_2_4, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += (this.BrickHeight * 3.5f);
            this.CreateBrick(ShieldBase.ShieldType.Brick_2_3, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += (this.BrickHeight * 3.5f);
            this.CreateBrick(ShieldBase.ShieldType.LeftTop0, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);

            this.SetTree(pShieldGrid1);

            GameObject pShieldColumn2 = this.CreateBrick(ShieldBase.ShieldType.Column, GameObject.Name.ShieldColumn, 0.0f, 0.0f);

            this.SetTree(pShieldColumn2);
            xShieldLocation += this.BrickWidth * 2.5f;
            yShieldLocation = _y;

            this.CreateBrick(ShieldBase.ShieldType.Brick_3_2, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.0f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_4, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_3, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_4, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.LeftTop1, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);


            this.SetTree(pShieldGrid1);

            GameObject pShieldColumn3 = this.CreateBrick(ShieldBase.ShieldType.Column, GameObject.Name.ShieldColumn, 0.0f, 0.0f);

            this.SetTree(pShieldColumn3);
            xShieldLocation += this.BrickWidth * 3;
            // Add .5f for correct pixel alignment
            yShieldLocation = _y + this.BrickHeight * 3 + .5f;
            this.CreateBrick(ShieldBase.ShieldType.LeftBottom, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_3, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_4, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_3, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);

            this.SetTree(pShieldGrid1);

            GameObject pShieldColumn4 = this.CreateBrick(ShieldBase.ShieldType.Column, GameObject.Name.ShieldColumn, 0.0f, 0.0f);

            this.SetTree(pShieldColumn4);
            xShieldLocation += this.BrickWidth * 3;
            // Add .5f for correct pixel alignment
            yShieldLocation = _y + this.BrickHeight * 4 + .5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_2, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 2.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_3, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_4, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_3, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);

            this.SetTree(pShieldGrid1);

            GameObject pShieldColumn5 = this.CreateBrick(ShieldBase.ShieldType.Column, GameObject.Name.ShieldColumn, 0.0f, 0.0f);

            this.SetTree(pShieldColumn5);
            xShieldLocation += this.BrickWidth * 3;
            // Add .5f for correct pixel alignment
            yShieldLocation = _y + this.BrickHeight * 4 + .5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_2, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 2.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_3, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_4, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_3, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);

            this.SetTree(pShieldGrid1);

            GameObject pShieldColumn6 = this.CreateBrick(ShieldBase.ShieldType.Column, GameObject.Name.ShieldColumn, 0.0f, 0.0f);

            this.SetTree(pShieldColumn6);
            xShieldLocation += this.BrickWidth * 3;
            // Add .5f for correct pixel alignment
            yShieldLocation = _y + this.BrickHeight * 3 + .5f;
            this.CreateBrick(ShieldBase.ShieldType.RightBottom, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_3, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_4, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_3, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);

            this.SetTree(pShieldGrid1);

            GameObject pShieldColumn7 = this.CreateBrick(ShieldBase.ShieldType.Column, GameObject.Name.ShieldColumn, 0.0f, 0.0f);

            this.SetTree(pShieldColumn7);
            xShieldLocation += this.BrickWidth * 3;
            yShieldLocation = _y;

            this.CreateBrick(ShieldBase.ShieldType.Brick_3_2, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.0f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_4, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_3, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_3_4, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.RightTop1, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);

            this.SetTree(pShieldGrid1);

            GameObject pShieldColumn8 = this.CreateBrick(ShieldBase.ShieldType.Column, GameObject.Name.ShieldColumn, 0.0f, 0.0f);

            this.SetTree(pShieldColumn8);

            xShieldLocation += this.BrickWidth * 2.5f;
            yShieldLocation = _y;

            this.CreateBrick(ShieldBase.ShieldType.Brick_2_2, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.0f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_2_4, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.Brick_2_3, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);
            yShieldLocation += this.BrickHeight * 3.5f;
            this.CreateBrick(ShieldBase.ShieldType.RightTop0, GameObject.Name.ShieldBrick, xShieldLocation, yShieldLocation);

            return (ShieldGrid)pShieldGrid1;
        }
    }
}
