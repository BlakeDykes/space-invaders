using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class ObserverSpawnExplosion : Observer
    {
        private ImageProxy pIShipEx1;
        private ImageProxy pIShipEx2;

        private SpriteBatch pSpriteBatch;
        private SpriteBatch pShipBatch;

        public ObserverSpawnExplosion()
        {
            this.pIShipEx1 = new ImageProxy(ImageManager.Find(Image.Name.Explosion_Ship1));
            this.pIShipEx2 = new ImageProxy(ImageManager.Find(Image.Name.Explosion_Ship2));

            // Set animation loop for ship explosion
            this.pIShipEx1.pNext = this.pIShipEx2;
            this.pIShipEx2.pNext = this.pIShipEx1;

            this.pSpriteBatch = SpriteBatchManager.Find(SpriteBatch.Name.Explosions);

            this.pShipBatch = SpriteBatchManager.Find(SpriteBatch.Name.Ships);
        }

        public override void Notify()
        {
            SpriteProxy pSprite = null;
            GameObject locationObject = null;
            bool shipExplosion = false;
            ColPair ColPair = ColPairManager.GetActivePair();
            Debug.Assert(ColPair != null);

            switch (ColPair.ColName)
            {
                case ColPair.Name.Missle_Wall:
                    locationObject = ColPair.GetGameObject(GameObject.Name.Missle);
                    pSprite = SpriteProxyManager.Add(Sprite.Name.Explosion_Large);
                    pSprite.SwapColor(Constants.RED);
                    break;
                case ColPair.Name.Missle_Shield:
                    locationObject = ColPair.GetGameObject(GameObject.Name.ShieldBrick);
                    pSprite = SpriteProxyManager.Add(Sprite.Name.Explosion_Small);
                    pSprite.SwapColor(Constants.GREEN);
                    break;
                case ColPair.Name.Missle_Bomb:
                    locationObject = ColPair.GetGameObject(GameObject.Name.Missle);
                    pSprite = SpriteProxyManager.Add(Sprite.Name.Explosion_Small);
                    if(locationObject.y <= Constants.GREEN_ZONE)
                    {
                        pSprite.SwapColor(Constants.GREEN);
                    }
                    break;
                case ColPair.Name.Missle_Alien:
                    locationObject = ColPair.GetAlienObject();
                    pSprite = SpriteProxyManager.Add(Sprite.Name.Explosion_Alien);
                    break;
                case ColPair.Name.Bomb_Ship:
                    locationObject = ColPair.GetGameObject(GameObject.Name.Ship);
                    pSprite = SpriteProxyManager.Add(Sprite.Name.Explosion_Ship);
                    pSprite.SwapColor(Constants.GREEN);
                    shipExplosion = true;
                    break;
                case ColPair.Name.Bomb_Shield:
                    locationObject = ColPair.GetGameObject(GameObject.Name.ShieldBrick);
                    pSprite = SpriteProxyManager.Add(Sprite.Name.Explosion_Small);
                    pSprite.SwapColor(Constants.GREEN);
                    break;
                case ColPair.Name.Bomb_Wall:
                    locationObject = ColPair.GetGameObject(GameObject.Name.Bomb);
                    //locationObject.y -= 5.0f;
                    pSprite = SpriteProxyManager.Add(Sprite.Name.Explosion_Small);
                    pSprite.SwapColor(Constants.GREEN);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            pSprite.UpdateLocal(locationObject.x, locationObject.y);

            if (shipExplosion == true) 
            {
                if(TimerManager.GetShipExploding() == false)
                {
                    this.pShipBatch.Attach(pSprite);
                    TimerManager.SetShipExploding(true);
                    GameObjectNodeManager.SetShipExploding(true);
                    TimerManager.Add(TimerEvent.Name.AnimateShipExplosion, 0.1f, new CommandAnimateShipExplosion(this.pIShipEx1, pSprite));
                }
            }
            else
            {
                this.pSpriteBatch.Attach(pSprite);
                TimerManager.Add(TimerEvent.Name.RemoveExplosion, .25f, new CommandRemoveExplosion(pSprite));

            }
        }
    }
}
