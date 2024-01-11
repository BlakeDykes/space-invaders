using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class CommandMoveAnimateAliensLoop : Command
    {
        public AlienGrid pGrid;
        private CompositeIterator poCompIt;
        private float MoveDistance = 10.0f;
        private int DirectionModifier;
        private Sprite pSquid;
        private Sprite pCrab;
        private Sprite pOcto;
        public float OriginalDeltaTime = 0.0f;

        private Sound pSound;

        private ImageProxy pCurSquid;
        private ImageProxy pCurCrab;
        private ImageProxy pCurOcto;

        private ImageProxy sqProxy2;
        private ImageProxy crProxy2;
        private ImageProxy ocProxy2;

        private int LevelModifier;

        public CommandMoveAnimateAliensLoop(AlienGrid _pGrid, Image _squidImage1,  Image _squidImage2, 
                                                              Image _crabImage1,   Image _crabImage2, 
                                                              Image _octoImage1,   Image _octoImage2)
        {
            this.pGrid = _pGrid;
            this.DirectionModifier = 1;

            // LTN - CommandMoveAnimateAliensLoop
            poCompIt = new CompositeIterator();

            pSquid = SpriteManager.Find(Sprite.Name.AlienSquid);
            pCrab = SpriteManager.Find(Sprite.Name.AlienCrab);
            pOcto = SpriteManager.Find(Sprite.Name.AlienOcto);

            // Create proxies for each image
            // LTN - CommandMoveAnimateAliensLoop
            sqProxy2 = new ImageProxy(_squidImage1);

            // LTN - CommandMoveAnimateAliensLoop
            pCurSquid = new ImageProxy(_squidImage2);

            // LTN - CommandMoveAnimateAliensLoop
            crProxy2 = new ImageProxy(_crabImage1);

            // LTN - CommandMoveAnimateAliensLoop
            pCurCrab = new ImageProxy(_crabImage2);

            // LTN - CommandMoveAnimateAliensLoop
            ocProxy2 = new ImageProxy(_octoImage1);

            // LTN - CommandMoveAnimateAliensLoop
            pCurOcto = new ImageProxy(_octoImage2);

            // Set animation loop
            sqProxy2.pNext = pCurSquid;
            pCurSquid.pNext = sqProxy2;
            crProxy2.pNext = pCurCrab;
            pCurCrab.pNext = crProxy2;
            ocProxy2.pNext = pCurOcto;
            pCurOcto.pNext = ocProxy2;


            // Set initial sound
            pSound = SoundManager.Find(Sound.Name.AlienStep1);

            LevelModifier = SceneManager.GetLevel();
        }

        public override void Execute(float deltaTime)
        {
            if(this.OriginalDeltaTime == 0.0f)
            {
                OriginalDeltaTime = deltaTime - ((float)LevelModifier * .1f);
            }
            // Switch direction at edges of screen
            float xDistance = pGrid.DirectionModifier * MoveDistance;
            
            // Move down on switch
            float yDistance = 0.0f;
            if(this.DirectionModifier != pGrid.DirectionModifier)
            {
                yDistance = -33.0f;
                this.DirectionModifier = pGrid.DirectionModifier;
            }

            pSquid.SwapImage(pCurSquid.pImage);
            pCrab.SwapImage(pCurCrab.pImage);
            pOcto.SwapImage(pCurOcto.pImage);

            pCurSquid = (ImageProxy)pCurSquid.pNext;
            pCurCrab = (ImageProxy)pCurCrab.pNext;
            pCurOcto = (ImageProxy)pCurOcto.pNext;

            poCompIt.Reset(pGrid);
            GameObject pCur = (GameObject)poCompIt.Current();
            while (poCompIt.IsDone() == false)
            {
                pCur.y += yDistance;
                pCur.x += xDistance;

                pCur = (GameObject)poCompIt.Next();
            }

            SoundManager.PlaySound(pSound.SoundName);
            pSound = pSound.GetNextSound();

            pGrid.DirectionSwitched = false;

            int alienCount = pGrid.GetLeafCount();
            float alienCountModifier = 0;

            if(alienCount < 50)
            {
                alienCountModifier = .05f;
            }
            else if(alienCount < 40)
            {
                alienCountModifier = .1f;
            }
            else if(alienCount < 30)
            {
                alienCountModifier = .15f;
            }
            else if(alienCount < 20)
            {
                alienCountModifier = .2f;
            }
            else if(alienCount < 10)
            {
                alienCountModifier = .3f;
            }
            else if(alienCount < 5)
            {
                alienCountModifier = .325f;
            }
            else if(alienCount < 1)
            {
                alienCountModifier = .375f;
            }

            float newDeltaTime = this.OriginalDeltaTime - alienCountModifier;

            TimerManager.Add(TimerEvent.Name.AlienAnimationMoveLoop, newDeltaTime, this);
        }
    }
}
