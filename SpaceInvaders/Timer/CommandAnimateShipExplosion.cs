using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CommandAnimateShipExplosion : Command
    {
        private ImageProxy pCurImage;
        private SpriteProxy pSpriteProxy;
        private float DeletionTime;
        private float TotalDelta;

        public CommandAnimateShipExplosion(ImageProxy image, SpriteProxy sprite)
        {
            this.pCurImage = image;
            this.pSpriteProxy = sprite;
            this.DeletionTime = 1.0f;
            this.TotalDelta = 0.0f;
        }

        public override void Execute(float deltaTime)
        {
            pCurImage = (ImageProxy)pCurImage.pNext;
            this.pSpriteProxy.SwapImage(pCurImage);

            if(this.TotalDelta >= this.DeletionTime)
            {
                TimerManager.SetShipExploding(false);
                GameObjectNodeManager.SetShipExploding(false);
                this.pSpriteProxy.Remove();

                // Check for Game Over
                if (PlayerManager.GetLivesLeft() == 0) 
                {
                    SceneManager.SetStateName(SceneState.StateName.GameOver);
                }
                else
                {
                    ShipManager.ActivateShip();
                }
            }
            else
            {
                this.TotalDelta += deltaTime;
                TimerManager.Add(TimerEvent.Name.AnimateShipExplosion, deltaTime, this);
            }

        }
    }
}
