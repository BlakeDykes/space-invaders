using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneStateSelect : SceneState
    {
        SpriteBatchManager poSpriteBatchManager;
        TimerManager poTimerManager;

        public SceneStateSelect()
        {
            this.mStateName = StateName.Select;
        }

        public override void Draw()
        {
            SpriteBatchManager.RenderAll();
        }

        public override void Initialize(float systemTime)
        {
            this.poSpriteBatchManager = new SpriteBatchManager(new DLinkManager(), new DLinkManager(), 1, 6);
            SpriteBatchManager.SetActive(poSpriteBatchManager);

            this.poTimerManager = new TimerManager(new DLinkManager(), new DLinkManager(), 5, 10, 0.0f);
            TimerManager.SetActive(this.poTimerManager, systemTime);

            //---------------------------------------------------------------------------------------------------------
            // Sprite Batches
            //---------------------------------------------------------------------------------------------------------

            SpriteBatch textBatch = SpriteBatchManager.Add(SpriteBatch.Name.Text);
            SpriteBatch alienBatch = SpriteBatchManager.Add(SpriteBatch.Name.Aliens);
            SpriteBatch collisionBatch = SpriteBatchManager.Add(SpriteBatch.Name.CollisionBoxes);

            collisionBatch.SetDrawEnable(false);


            //---------------------------------------------------------------------------------------------------------
            // Textures
            //---------------------------------------------------------------------------------------------------------
            Texture pAlienTex = TextureManager.Find(Texture.Name.Aliens);

            //---------------------------------------------------------------------------------------------------------
            // Images
            //---------------------------------------------------------------------------------------------------------
            Image pISquid = ImageManager.Add(Image.Name.Squid1, pAlienTex, 61.0f, 3.0f, 8.0f, 7.0f);
            Image pICrab = ImageManager.Add(Image.Name.Crab1, pAlienTex, 33.0f, 3.0f, 11.0f, 7.0f);
            Image pIOcto = ImageManager.Add(Image.Name.Octo1, pAlienTex, 3.0f, 3.0f, 12.0f, 7.0f);
            Image pIUFO = ImageManager.Add(Image.Name.UFO, pAlienTex, 99.0f, 4.0f, 16.0f, 7.0f);

            //---------------------------------------------------------------------------------------------------------
            // Sprites
            //---------------------------------------------------------------------------------------------------------
            // Aliens
            SpriteManager.Add(Sprite.Name.AlienSquid, pISquid, null, Constants.SQUID_WIDTH, Constants.SQUID_HEIGHT);
            SpriteManager.Add(Sprite.Name.AlienCrab, pICrab, null, Constants.CRAB_WIDTH, Constants.CRAB_HEIGHT);
            SpriteManager.Add(Sprite.Name.AlienOcto, pIOcto, null, Constants.OCTO_WIDTH, Constants.OCTO_HEIGHT);

            // UFO
            SpriteManager.Add(Sprite.Name.UFO, pIUFO, Constants.RED, Constants.UFO_WIDTH, Constants.UFO_HEIGHT);

            //---------------------------------------------------------------------------------------------------------
            // Game Objects
            //---------------------------------------------------------------------------------------------------------
            // Aliens
            AlienFactory aFactory = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.CollisionBoxes);

            AlienGrid pAlienGrid = (AlienGrid)aFactory.CreateAlien(AlienBase.AlienType.AlienGrid, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);
            AlienColumn pCol1 = (AlienColumn)aFactory.CreateAlien(AlienBase.AlienType.AlienColumn, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);

            pCol1.Add(aFactory.CreateAlien(AlienBase.AlienType.Squid, Constants.SELECT_PLAY_X - 95.0f, Constants.SELECT_PLAY_Y - 370.0f, Constants.DEFAULT_SPRITE_COLOR));
            pCol1.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.SELECT_PLAY_X - 95.0f, Constants.SELECT_PLAY_Y - 435.0f, Constants.DEFAULT_SPRITE_COLOR));
            pCol1.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.SELECT_PLAY_X - 95.0f, Constants.SELECT_PLAY_Y - 500.0f, Constants.GREEN));

            pAlienGrid.Add(pCol1);
            GameObjectNodeManager.Attach(pAlienGrid);

            // UFO
            UFOGroup ufoGroup = new UFOGroup();
            GameObjectNodeManager.Attach(ufoGroup);
            UFOFactory uFactory = new UFOFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.CollisionBoxes);
            uFactory.CreateUFO(Constants.SELECT_PLAY_X - 95.0f, Constants.SELECT_PLAY_Y - 305.0f, 1, Constants.DEFAULT_SPRITE_COLOR, false);

            //---------------------------------------------------------------------------------------------------------
            // Load the Fonts
            //---------------------------------------------------------------------------------------------------------
            FontManager.LoadScreenFont(textBatch, FontManager.ScreenFont.GamePlay);
            FontManager.LoadScreenFont(textBatch, FontManager.ScreenFont.Attract);

            //---------------------------------------------------------------------------------------------------------
            // Input
            //---------------------------------------------------------------------------------------------------------
            InputSubject pEnter = InputManager.GetSubjectEnter();
            pEnter.Attach(new ObserverTransitionToPlayerSelect());

        }

        public override void Transition(float systemTime)
        {
            GameObjectNodeManager.Clear();

            Initialize(systemTime);
            SpriteBatchManager.SetActive(this.poSpriteBatchManager);
            TimerManager.SetActive(this.poTimerManager, systemTime);
            InputManager.SetState(InputState.State.Select);
        }

        public override void Update(float systemTime)
        {
            Simulation.Update(systemTime);

            if (Simulation.GetTimeStep() > 0.0f)
            {
                TimerManager.Update(Simulation.GetTotalTime());

                GameObjectNodeManager.UpdateAll();

                ColPairManager.Update();

                DelayedEventManager.Process();
            }
        }
    }
}
