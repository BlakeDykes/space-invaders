using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    class SpaceInvaders : Azul.Game
    {

        //-----------------------------------------------------------------------------
        // Game::Initialize()
        //		Allows the engine to perform any initialization it needs to before 
        //      starting to run.  This is where it can query for any required services 
        //      and load any non-graphic related content. 
        //-----------------------------------------------------------------------------
        public override void Initialize()
        {
            // Game Window Device setup
            this.SetWindowName("Space Invaders");
            this.SetWidthHeight(Constants.SCREEN_X, Constants.SCREEN_Y);
            this.SetClearColor(0.0f, 0.0f, 0.0f, 1.0f);
        }

        //-----------------------------------------------------------------------------
        // Game::LoadContent()
        //		Allows you to load all content needed for your engine,
        //	    such as objects, graphics, etc.
        //-----------------------------------------------------------------------------
        public override void LoadContent()
        {
            //---------------------------------------------------------------------------------------------------------
            // Create Managers
            //---------------------------------------------------------------------------------------------------------
            SpriteBatchManager.Create(new DLinkManager(), new DLinkManager(), 3, 3);

            TextureManager.Create(new DLinkManager(), new DLinkManager(), 1, 3);
            ImageManager.Create(new DLinkManager(), new DLinkManager(), 1, 1);
            SpriteManager.Create(new DLinkManager(), new DLinkManager(), 11, 11);
            SpriteBoxManager.Create(new DLinkManager(), new DLinkManager(), 2, 2);
            SpriteProxyManager.Create(new DLinkManager(), new DLinkManager(), 3, 3);
            SpriteBoxProxyManager.Create(new DLinkManager(), new DLinkManager(), 3, 3);
            GameObjectNodeManager.Create(new DLinkManager(), new DLinkManager(), 3, 134);

            TimerManager.Create(new DLinkManager(), new DLinkManager(), 2, 2, this.GetTime());
            ColPairManager.Create(new DLinkManager(), new DLinkManager(), 1, 1);

            InputManager.Create();
            Simulation.Create();
            DelayedEventManager.Create();

            GlyphManager.Create(new DLinkManager(), new DLinkManager(), 32, 32);
            FontManager.Create(new DLinkManager(), new DLinkManager(), 1, 1);
            GlyphManager.AddXml(Glyph.Name.Consolas36pt, "Consolas36pt.xml", Texture.Name.Consolas);

            ScoreManager.Create(new SLinkManager(), new SLinkManager(), 1, 3);
            SoundManager.Create(new SLinkManager(), new SLinkManager(), 10, 1, 0.25f);


            //---------------------------------------------------------------------------------------------------------
            // ScoreManager
            //---------------------------------------------------------------------------------------------------------
            ScoreManager.Add(Score.Name.HiScore);
            ScoreManager.Add(Score.Name.Player1);


            GhostManager.Create(new DLinkManager(), new DLinkManager(), 5, 10);
            //---------------------------------------------------------------------------------------------------------
            // Initialize Scene
            //---------------------------------------------------------------------------------------------------------
            SceneManager.Create();

            //---------------------------------------------------------------------------------------------------------
            // Print Init Stats
            //---------------------------------------------------------------------------------------------------------
            Debug.WriteLine("(Width,Height): {0}, {1}", this.GetScreenWidth(), this.GetScreenHeight());
            Debug.WriteLine("");
        }

        //-----------------------------------------------------------------------------
        // Game::Update()
        //      Called once per frame, update data, tranformations, etc
        //      Use this function to control process order
        //      Input, AI, Physics, Animation, and Graphics
        //-----------------------------------------------------------------------------
        public override void Update()
        {
            InputManager.Update();

            SoundManager.Update();

            if (Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_P) == true)
            {
                SceneManager.SetState(SceneState.StateName.Play, this.GetTime());
            }
            if(Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_U) == true)
            {
                SceneManager.SetState(SceneState.StateName.Select, this.GetTime());
            }
            if(Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_I) == true)
            {
                SceneManager.SetState(SceneState.StateName.GameOver, this.GetTime());
            }

            if(SceneManager.GetStateName() == SceneState.StateName.GameOver 
                && SceneManager.GetState().GetStateName() != SceneState.StateName.GameOver)
            {
                SceneManager.SetState(SceneState.StateName.GameOver, this.GetTime());
            }

            if (SceneManager.GetStateName() == SceneState.StateName.Select
                && SceneManager.GetState().GetStateName() != SceneState.StateName.Select)
            {
                SceneManager.SetState(SceneState.StateName.Select, this.GetTime());
            }

            SceneManager.GetState().Update(this.GetTime());
        }

        //-----------------------------------------------------------------------------
        // Game::Draw()
        //		This function is called once per frame
        //	    Use this for draw graphics to the screen.
        //      Only do rendering here
        //-----------------------------------------------------------------------------
        public override void Draw()
        {
            SceneManager.GetState().Draw();
        }

        //-----------------------------------------------------------------------------
        // Game::UnLoadContent()
        //       unload content (resources loaded above)
        //       unload all content that was loaded before the Engine Loop started
        //-----------------------------------------------------------------------------
        public override void UnLoadContent()
        {
            SpriteBatchManager.DumpStats();
            SpriteManager.DumpStats();
            SpriteBoxManager.DumpStats();
            ImageManager.DumpStats();
            TextureManager.DumpStats();
        }

    }
}

