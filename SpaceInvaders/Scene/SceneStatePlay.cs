using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public class SceneStatePlay : SceneState
    {
        SpriteBatchManager poSpriteBatchManager;
        TimerManager poTimerManager;
        public int Level;
        public AlienGrid pAlienGrid;

        SpriteBatch colBoxes;
        bool LastBoxesPressed;
        bool DrawBoxes;


        public SceneStatePlay()
        {
            this.mStateName = StateName.Play;
            this.Level = 0;
            LastBoxesPressed = false;
            DrawBoxes = false;
        }

        public override void Draw()
        {
            SpriteBatchManager.RenderAll();
        }

        public override void Initialize(float systemTime)
        {
            // Increment Level
            Level++;
            //---------------------------------------------------------------------------------------------------------
            // Setup Managers
            //---------------------------------------------------------------------------------------------------------

            this.poSpriteBatchManager = new SpriteBatchManager(new DLinkManager(), new DLinkManager(), 1, 6);
            SpriteBatchManager.SetActive(poSpriteBatchManager);

            this.poTimerManager = new TimerManager(new DLinkManager(), new DLinkManager(), 5, 10, 0.0f);
            TimerManager.SetActive(this.poTimerManager, systemTime);

            //---------------------------------------------------------------------------------------------------------
            // Create Images
            //---------------------------------------------------------------------------------------------------------

            Texture pAlienTex = TextureManager.Find(Texture.Name.Aliens);

            Image pISquid1 = ImageManager.Add(Image.Name.Squid1, pAlienTex, 61.0f, 3.0f, 8.0f, 7.0f);
            Image pISquid2 = ImageManager.Add(Image.Name.Squid2, pAlienTex, 72.0f, 3.0f, 8.0f, 7.0f);

            Image pICrab1 = ImageManager.Add(Image.Name.Crab1, pAlienTex, 33.0f, 3.0f, 11.0f, 7.0f);
            Image pICrab2 = ImageManager.Add(Image.Name.Crab2, pAlienTex, 47.0f, 3.0f, 11.0f, 7.0f);

            Image pIOcto1 = ImageManager.Add(Image.Name.Octo1, pAlienTex, 3.0f, 3.0f, 12.0f, 7.0f);
            Image pIOcto2 = ImageManager.Add(Image.Name.Octo2, pAlienTex, 18.0f, 3.0f, 12.0f, 7.0f);

            Image pIUFO = ImageManager.Add(Image.Name.UFO, pAlienTex, 99.0f, 4.0f, 16.0f, 7.0f);

            Image pIShip = ImageManager.Add(Image.Name.Ship, pAlienTex, 3.0f, 14.0f, 13.0f, 8.0f);
            Image pIMissle = ImageManager.Add(Image.Name.Missle, pAlienTex, 3.0f, 29.0f, 1.0f, 4.0f);

            Image pIShieldBrick = ImageManager.Add(Image.Name.Shield_Brick, pAlienTex, 116.0f, 34.0f, 3.0f, 2.0f);
            Image pIShieldLeftTop0 = ImageManager.Add(Image.Name.Shield_Brick_LeftTop0, pAlienTex, 114.0f, 34.0f, 2.0f, 4.0f);
            Image pIShieldLeftTop1 = ImageManager.Add(Image.Name.Shield_Brick_LeftTop1, pAlienTex, 116.0f, 31.0f, 3.0f, 3.0f);
            Image pIShieldLeftBottom = ImageManager.Add(Image.Name.Shield_Brick_LeftBottom, pAlienTex, 119.0f, 41.0f, 3.0f, 4.0f);
            Image pIShieldRightTop0 = ImageManager.Add(Image.Name.Shield_Brick_RightTop0, pAlienTex, 134.0f, 34.0f, 2.0f, 4.0f);
            Image pIShieldRightTop1 = ImageManager.Add(Image.Name.Shield_Brick_RightTop1, pAlienTex, 131.0f, 31.0f, 3.0f, 3.0f);
            Image pIShieldRightBottom = ImageManager.Add(Image.Name.Shield_Brick_RightBottom, pAlienTex, 128.0f, 41.0f, 3.0f, 4.0f);

            Image pIBombStraight1 = ImageManager.Add(Image.Name.Bomb_Straight1, pAlienTex, 65.0f, 26.0f, 3.0f, 7.0f);
            Image pIBombStraight2 = ImageManager.Add(Image.Name.Bomb_Straight2, pAlienTex, 70.0f, 26.0f, 3.0f, 7.0f);
            Image pIBombStraight3 = ImageManager.Add(Image.Name.Bomb_Straight3, pAlienTex, 80.0f, 26.0f, 3.0f, 7.0f);
            Image pIBombDagger1 = ImageManager.Add(Image.Name.Bomb_Dagger1, pAlienTex, 60.0f, 27.0f, 3.0f, 6.0f);
            Image pIBombDagger2 = ImageManager.Add(Image.Name.Bomb_Dagger2, pAlienTex, 54.0f, 27.0f, 3.0f, 6.0f);
            Image pIBombDagger3 = ImageManager.Add(Image.Name.Bomb_Dagger3, pAlienTex, 48.0f, 27.0f, 3.0f, 6.0f);
            Image pIBombDagger4 = ImageManager.Add(Image.Name.Bomb_Dagger4, pAlienTex, 42.0f, 27.0f, 3.0f, 6.0f);
            Image pIBombZigZag1 = ImageManager.Add(Image.Name.Bomb_ZigZag1, pAlienTex, 18.0f, 26.0f, 3.0f, 7.0f);
            Image pIBombZigZag2 = ImageManager.Add(Image.Name.Bomb_ZigZag2, pAlienTex, 24.0f, 26.0f, 3.0f, 7.0f);
            Image pIBombZigZag3 = ImageManager.Add(Image.Name.Bomb_ZigZag3, pAlienTex, 30.0f, 26.0f, 3.0f, 7.0f);
            Image pIBombZigZag4 = ImageManager.Add(Image.Name.Bomb_ZigZag4, pAlienTex, 36.0f, 26.0f, 3.0f, 7.0f);

            Image pIExplosionSmall = ImageManager.Add(Image.Name.Explosion_Small, pAlienTex, 86.0f, 25.0f, 6.0f, 8.0f);
            Image pIExplosionLarge = ImageManager.Add(Image.Name.Explosion_Small, pAlienTex, 7.0f, 25.0f, 8.0f, 8.0f);
            Image pIExplosionAlien = ImageManager.Add(Image.Name.Explosion_Alien, pAlienTex, 83.0f, 3.0f, 13.0f, 8.0f);
            Image pIExplosionShip1 = ImageManager.Add(Image.Name.Explosion_Ship1, pAlienTex, 20.0f, 14.0f, 15.0f, 8.0f);
            Image pIExplosionShip2 = ImageManager.Add(Image.Name.Explosion_Ship2, pAlienTex, 38.0f, 14.0f, 16.0f, 8.0f);


            //---------------------------------------------------------------------------------------------------------
            // Sprite Batches
            //---------------------------------------------------------------------------------------------------------

            SpriteBatch textBatch = SpriteBatchManager.Add(SpriteBatch.Name.Text);
            SpriteBatch wallsBatch = SpriteBatchManager.Add(SpriteBatch.Name.Walls);
            SpriteBatch aliensBatch = SpriteBatchManager.Add(SpriteBatch.Name.Aliens);
            SpriteBatch shipBatch = SpriteBatchManager.Add(SpriteBatch.Name.Ships);
            SpriteBatch bombBatch = SpriteBatchManager.Add(SpriteBatch.Name.Bombs);
            SpriteBatch shieldBatch = SpriteBatchManager.Add(SpriteBatch.Name.Shields);
            this.colBoxes = SpriteBatchManager.Add(SpriteBatch.Name.CollisionBoxes);
            SpriteBatch explosionBatch = SpriteBatchManager.Add(SpriteBatch.Name.Explosions);
            SpriteBatch lifeMarkers = SpriteBatchManager.Add(SpriteBatch.Name.LifeMarkers_Player_1);

            this.colBoxes.SetDrawEnable(DrawBoxes);

            //---------------------------------------------------------------------------------------------------------
            // Create Sprites
            //---------------------------------------------------------------------------------------------------------

            // Alien
            SpriteManager.Add(Sprite.Name.AlienSquid, pISquid1, null, Constants.SQUID_WIDTH, Constants.SQUID_HEIGHT);
            SpriteManager.Add(Sprite.Name.AlienCrab, pICrab1, null, Constants.CRAB_WIDTH, Constants.CRAB_HEIGHT);
            SpriteManager.Add(Sprite.Name.AlienOcto, pIOcto1, null, Constants.OCTO_WIDTH, Constants.OCTO_HEIGHT);

            // UFO
            SpriteManager.Add(Sprite.Name.UFO, pIUFO, Constants.RED, Constants.UFO_WIDTH, Constants.UFO_HEIGHT);

            // Bombs
            SpriteManager.Add(Sprite.Name.BombStraight, pIBombStraight1, null, Constants.BOMB_WIDTH, Constants.BOMB_HEIGHT);
            SpriteManager.Add(Sprite.Name.BombDagger, pIBombDagger1, null, Constants.BOMB_WIDTH, Constants.BOMB_HEIGHT);
            SpriteManager.Add(Sprite.Name.BombZigZag, pIBombZigZag1, null, Constants.BOMB_WIDTH, Constants.BOMB_HEIGHT);


            // Ship and Missle
            SpriteManager.Add(Sprite.Name.Missle, pIMissle, Constants.GREEN, Constants.MISSLE_WIDTH, Constants.MISSLE_HEIGHT);
            SpriteManager.Add(Sprite.Name.Ship, pIShip, Constants.GREEN, Constants.SHIP_WIDTH, Constants.SHIP_HEIGHT);

            // Shields
            SpriteManager.Add(Sprite.Name.Brick_2_2, pIShieldBrick, Constants.GREEN, Constants.BRICK_WIDTH * 2, Constants.BRICK_HEIGHT * 2);
            SpriteManager.Add(Sprite.Name.Brick_2_4, pIShieldBrick, Constants.GREEN, Constants.BRICK_WIDTH * 2, Constants.BRICK_HEIGHT * 4);
            SpriteManager.Add(Sprite.Name.Brick_2_3, pIShieldBrick, Constants.GREEN, Constants.BRICK_WIDTH * 2, Constants.BRICK_HEIGHT * 3);
            SpriteManager.Add(Sprite.Name.Brick_3_4, pIShieldBrick, Constants.GREEN, Constants.BRICK_WIDTH * 3, Constants.BRICK_HEIGHT * 4);
            SpriteManager.Add(Sprite.Name.Brick_3_3, pIShieldBrick, Constants.GREEN, Constants.BRICK_WIDTH * 3, Constants.BRICK_HEIGHT * 3);
            SpriteManager.Add(Sprite.Name.Brick_3_2, pIShieldBrick, Constants.GREEN, Constants.BRICK_WIDTH * 3, Constants.BRICK_HEIGHT * 2);
            SpriteManager.Add(Sprite.Name.Brick_LeftTop0, pIShieldLeftTop0, Constants.GREEN, Constants.BRICK_WIDTH * 2, Constants.BRICK_HEIGHT * 4);
            SpriteManager.Add(Sprite.Name.Brick_LeftTop1, pIShieldLeftTop1, Constants.GREEN, Constants.BRICK_WIDTH * 3, Constants.BRICK_HEIGHT * 3);
            SpriteManager.Add(Sprite.Name.Brick_LeftBottom, pIShieldLeftBottom, Constants.GREEN, Constants.BRICK_WIDTH * 3, Constants.BRICK_HEIGHT * 4);
            SpriteManager.Add(Sprite.Name.Brick_RightTop0, pIShieldRightTop0, Constants.GREEN, Constants.BRICK_WIDTH * 2, Constants.BRICK_HEIGHT * 4);
            SpriteManager.Add(Sprite.Name.Brick_RightTop1, pIShieldRightTop1, Constants.GREEN, Constants.BRICK_WIDTH * 3, Constants.BRICK_HEIGHT * 3);
            SpriteManager.Add(Sprite.Name.Brick_RightBottom, pIShieldRightBottom, Constants.GREEN, Constants.BRICK_WIDTH * 3, Constants.BRICK_HEIGHT * 4);

            // Walls
            SpriteManager.Add(Sprite.Name.Wall_Bottom, pIShieldBrick, Constants.GREEN, Constants.WALL_BOTTOM_WIDTH, Constants.WALL_BOTTOM_HEIGHT);

            // Explosions
            SpriteManager.Add(Sprite.Name.Explosion_Small, pIExplosionSmall, Constants.RED, Constants.EXPLOSION_SMALL_WIDTH, Constants.EXPLOSION_SMALL_HEIGHT);
            SpriteManager.Add(Sprite.Name.Explosion_Large, pIExplosionLarge, Constants.RED, Constants.EXPLOSION_LARGE_WIDTH, Constants.EXPLOSION_LARGE_HEIGHT);
            SpriteManager.Add(Sprite.Name.Explosion_Alien, pIExplosionAlien, Constants.DEFAULT_SPRITE_COLOR, Constants.EXPLOSION_ALIEN_WIDTH, Constants.EXPLOSION_ALIEN_HEIGHT);
            SpriteManager.Add(Sprite.Name.Explosion_Ship, pIExplosionShip1, Constants.GREEN, Constants.EXPLOSION_SHIP_WIDTH, Constants.EXPLOSION_SHIP_HEIGHT);




            //---------------------------------------------------------------------------------------------------------
            // Game Objects
            //---------------------------------------------------------------------------------------------------------
            // Aliens
            AlienFactory aFactory = new AlienFactory(SpriteBatch.Name.Aliens, SpriteBatch.Name.CollisionBoxes);

            this.pAlienGrid = (AlienGrid)aFactory.CreateAlien(AlienBase.AlienType.AlienGrid, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);
            AlienColumn pCol1 = (AlienColumn)aFactory.CreateAlien(AlienBase.AlienType.AlienColumn, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);
            AlienColumn pCol2 = (AlienColumn)aFactory.CreateAlien(AlienBase.AlienType.AlienColumn, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);
            AlienColumn pCol3 = (AlienColumn)aFactory.CreateAlien(AlienBase.AlienType.AlienColumn, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);
            AlienColumn pCol4 = (AlienColumn)aFactory.CreateAlien(AlienBase.AlienType.AlienColumn, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);
            AlienColumn pCol5 = (AlienColumn)aFactory.CreateAlien(AlienBase.AlienType.AlienColumn, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);
            AlienColumn pCol6 = (AlienColumn)aFactory.CreateAlien(AlienBase.AlienType.AlienColumn, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);
            AlienColumn pCol7 = (AlienColumn)aFactory.CreateAlien(AlienBase.AlienType.AlienColumn, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);
            AlienColumn pCol8 = (AlienColumn)aFactory.CreateAlien(AlienBase.AlienType.AlienColumn, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);
            AlienColumn pCol9 = (AlienColumn)aFactory.CreateAlien(AlienBase.AlienType.AlienColumn, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);
            AlienColumn pCol10 = (AlienColumn)aFactory.CreateAlien(AlienBase.AlienType.AlienColumn, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);
            AlienColumn pCol11 = (AlienColumn)aFactory.CreateAlien(AlienBase.AlienType.AlienColumn, 0.0f, 0.0f, Constants.DEFAULT_SPRITE_COLOR);

            int columns = 0;
            int rows = 4;

            pCol1.Add(aFactory.CreateAlien(AlienBase.AlienType.Squid, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol1.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab,  Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol1.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab,  Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol1.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo,  Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol1.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo,  Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));

            columns++;
            rows = 4;

            pCol2.Add(aFactory.CreateAlien(AlienBase.AlienType.Squid, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol2.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol2.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol2.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol2.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));

            columns++;
            rows = 4;

            pCol3.Add(aFactory.CreateAlien(AlienBase.AlienType.Squid, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol3.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol3.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol3.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol3.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            
            columns++;
            rows = 4;

            pCol4.Add(aFactory.CreateAlien(AlienBase.AlienType.Squid, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol4.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol4.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol4.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol4.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));

            columns++;
            rows = 4;

            pCol5.Add(aFactory.CreateAlien(AlienBase.AlienType.Squid, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol5.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol5.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol5.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol5.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));

            columns++;
            rows = 4;

            pCol6.Add(aFactory.CreateAlien(AlienBase.AlienType.Squid, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol6.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol6.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol6.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol6.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));

            columns++;
            rows = 4;

            pCol7.Add(aFactory.CreateAlien(AlienBase.AlienType.Squid, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol7.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol7.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol7.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol7.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));

            columns++;
            rows = 4;

            pCol8.Add(aFactory.CreateAlien(AlienBase.AlienType.Squid, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol8.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol8.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol8.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol8.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));

            columns++;
            rows = 4;

            pCol9.Add(aFactory.CreateAlien(AlienBase.AlienType.Squid, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol9.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol9.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol9.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol9.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));

            columns++;
            rows = 4;

            pCol10.Add(aFactory.CreateAlien(AlienBase.AlienType.Squid, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol10.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol10.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol10.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol10.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));

            columns++;
            rows = 4;

            pCol11.Add(aFactory.CreateAlien(AlienBase.AlienType.Squid, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol11.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol11.Add(aFactory.CreateAlien(AlienBase.AlienType.Crab, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol11.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));
            pCol11.Add(aFactory.CreateAlien(AlienBase.AlienType.Octo, Constants.ALIEN_X_START + Constants.ALIEN_Y_GAP * columns, Constants.ALIEN_Y_START + (66.0f * rows--), Constants.DEFAULT_SPRITE_COLOR));

            this.pAlienGrid.Add(pCol1);
            this.pAlienGrid.Add(pCol2);
            this.pAlienGrid.Add(pCol3);
            this.pAlienGrid.Add(pCol4);
            this.pAlienGrid.Add(pCol5);
            this.pAlienGrid.Add(pCol6);
            this.pAlienGrid.Add(pCol7);
            this.pAlienGrid.Add(pCol8);
            this.pAlienGrid.Add(pCol9);
            this.pAlienGrid.Add(pCol10);
            this.pAlienGrid.Add(pCol11);


            aliensBatch.Attach(this.pAlienGrid);
            aliensBatch.Attach(pCol1);
            aliensBatch.Attach(pCol2);
            aliensBatch.Attach(pCol3);
            aliensBatch.Attach(pCol4);
            aliensBatch.Attach(pCol5);
            aliensBatch.Attach(pCol6);
            aliensBatch.Attach(pCol7);
            aliensBatch.Attach(pCol8);
            aliensBatch.Attach(pCol9);
            aliensBatch.Attach(pCol10);
            aliensBatch.Attach(pCol11);

            GameObjectNodeManager.Attach(this.pAlienGrid);

            // Setup Player
            PlayerManager.Create();
            PlayerManager.Attach(new Player(Player.PlayerName.Player_1));

            // UFO
            UFOManager.Create();

            // Bombs
            BombManager.Create();
            BombFactory.Create(SpriteBatch.Name.Bombs, SpriteBatch.Name.CollisionBoxes);

            // Missle
            MissleManager.Create();
            MissleFactory.Create(SpriteBatch.Name.Aliens, SpriteBatch.Name.CollisionBoxes);

            // Ship
            ShipManager.Create();
            ShipFactory.Create(SpriteBatch.Name.Ships, SpriteBatch.Name.CollisionBoxes);


            // Walls
            WallFactory wallFactory = new WallFactory(SpriteBatch.Name.Walls, SpriteBatch.Name.CollisionBoxes);

            GameObject pWallGroup = wallFactory.CreateWalls(WallBase.WallType.Group);
            pWallGroup.Add(wallFactory.CreateWalls(WallBase.WallType.Top));
            pWallGroup.Add(wallFactory.CreateWalls(WallBase.WallType.Bottom));
            pWallGroup.Add(wallFactory.CreateWalls(WallBase.WallType.Left));
            pWallGroup.Add(wallFactory.CreateWalls(WallBase.WallType.Right));

            // Shields
            ShieldFactory pShieldFactory = new ShieldFactory(SpriteBatch.Name.Shields, SpriteBatch.Name.CollisionBoxes, Constants.BRICK_WIDTH, Constants.BRICK_HEIGHT);

            pShieldFactory.CreateShield(130.0f, Constants.BOTTOM_BRICK_Y);
            pShieldFactory.CreateShield(310.0f, Constants.BOTTOM_BRICK_Y);
            pShieldFactory.CreateShield(490.0f, Constants.BOTTOM_BRICK_Y);
            pShieldFactory.CreateShield(670.0f, Constants.BOTTOM_BRICK_Y);

            //---------------------------------------------------------------------------------------------------------
            // Timer Manager
            //---------------------------------------------------------------------------------------------------------
            Command pAlienMoveAnimate = new CommandMoveAnimateAliensLoop(pAlienGrid, pISquid1, pISquid2, pICrab1, pICrab2, pIOcto1, pIOcto2);
            TimerManager.Add(TimerEvent.Name.AlienAnimationMoveLoop, 0.5f, pAlienMoveAnimate);
            TimerManager.Add(TimerEvent.Name.SpawnUFO, 20.0f, new CommandSpawnUFO());
            TimerManager.Add(TimerEvent.Name.DropBomb, BombManager.GetNextDrop(), new CommandDropBomb());

            //---------------------------------------------------------------------------------------------------------
            // Collisions
            //---------------------------------------------------------------------------------------------------------

            // Missle vs. Wall
            ColPairManager.Add(ColPair.Name.Missle_Wall, MissleManager.GetGroup(), pWallGroup);
            ColPairManager.AttachObserver(ColPair.Name.Missle_Wall, new ObserverMissleReady());
            ColPairManager.AttachObserver(ColPair.Name.Missle_Wall, new ObserverRemoveMissle());
            ColPairManager.AttachObserver(ColPair.Name.Missle_Wall, new ObserverSpawnExplosion());

            // Missle vs. Alien
            ColPairManager.Add(ColPair.Name.Missle_Alien, MissleManager.GetGroup(), pAlienGrid);
            ColPairManager.AttachObserver(ColPair.Name.Missle_Alien, new ObserverMissleReady());
            ColPairManager.AttachObserver(ColPair.Name.Missle_Alien, new ObserverRemoveAlien());
            ColPairManager.AttachObserver(ColPair.Name.Missle_Alien, new ObserverRemoveMissle());
            ColPairManager.AttachObserver(ColPair.Name.Missle_Alien, new ObserverUpdateScore());
            ColPairManager.AttachObserver(ColPair.Name.Missle_Alien, new ObserverSpawnExplosion());

            // Missle vs. Bomb
            ColPairManager.Add(ColPair.Name.Missle_Bomb, MissleManager.GetGroup(), BombManager.GetGroup());
            ColPairManager.AttachObserver(ColPair.Name.Missle_Bomb, new ObserverMissleReady());
            ColPairManager.AttachObserver(ColPair.Name.Missle_Bomb, new ObserverRemoveMissle());
            ColPairManager.AttachObserver(ColPair.Name.Missle_Bomb, new ObserverRemoveBomb());
            ColPairManager.AttachObserver(ColPair.Name.Missle_Bomb, new ObserverSpawnExplosion());

            // Ship vs. Wall
            ColPairManager.Add(ColPair.Name.Ship_Wall, ShipManager.GetGroup(), pWallGroup);
            ColPairManager.AttachObserver(ColPair.Name.Ship_Wall, new ObserverShipLeftWall());
            ColPairManager.AttachObserver(ColPair.Name.Ship_Wall, new ObserverShipRightWall());

            // Alien vs. Wall
            ColPairManager.Add(ColPair.Name.Alien_Wall, pAlienGrid, pWallGroup);
            ColPairManager.AttachObserver(ColPair.Name.Alien_Wall, new ObserverAlienWall());

            // UFO vs. Wall
            ColPairManager.Add(ColPair.Name.UFO_Wall, UFOManager.GetGroup(), pWallGroup);
            ColPairManager.AttachObserver(ColPair.Name.UFO_Wall, new ObserverRemoveUFO());
            ColPairManager.AttachObserver(ColPair.Name.UFO_Wall, new ObserverRemoveSoundLoopUFO());

            // Missle vs. Shield
            ColPairManager.Add(ColPair.Name.Missle_Shield, MissleManager.GetGroup(), GameObjectNodeManager.Find(GameObject.Name.ShieldGroup));
            ColPairManager.AttachObserver(ColPair.Name.Missle_Shield, new ObserverMissleReady());
            ColPairManager.AttachObserver(ColPair.Name.Missle_Shield, new ObserverRemoveMissle());
            ColPairManager.AttachObserver(ColPair.Name.Missle_Shield, new ObserverRemoveShield());
            ColPairManager.AttachObserver(ColPair.Name.Missle_Shield, new ObserverSpawnExplosion());

            // Missle vs. UFO
            ColPairManager.Add(ColPair.Name.Missle_UFO, MissleManager.GetGroup(), UFOManager.GetGroup());
            ColPairManager.AttachObserver(ColPair.Name.Missle_UFO, new ObserverRemoveUFO());
            ColPairManager.AttachObserver(ColPair.Name.Missle_UFO, new ObserverRemoveSoundLoopUFO());
            ColPairManager.AttachObserver(ColPair.Name.Missle_UFO, new ObserverUpdateScore());

            // Bomb vs. Shield
            ColPairManager.Add(ColPair.Name.Bomb_Shield, BombManager.GetGroup(), GameObjectNodeManager.Find(GameObject.Name.ShieldGroup));
            ColPairManager.AttachObserver(ColPair.Name.Bomb_Shield, new ObserverRemoveShield());
            ColPairManager.AttachObserver(ColPair.Name.Bomb_Shield, new ObserverRemoveBomb());
            ColPairManager.AttachObserver(ColPair.Name.Bomb_Shield, new ObserverSpawnExplosion());

            // Bomb vs. Ship
            ColPairManager.Add(ColPair.Name.Bomb_Ship, BombManager.GetGroup(), ShipManager.GetGroup());
            ColPairManager.AttachObserver(ColPair.Name.Bomb_Ship, new ObserverRemoveBomb());
            ColPairManager.AttachObserver(ColPair.Name.Bomb_Ship, new ObserverRemoveShip());
            ColPairManager.AttachObserver(ColPair.Name.Bomb_Ship, new ObserverSpawnExplosion());
            ColPairManager.AttachObserver(ColPair.Name.UFO_Wall, new ObserverRemoveSoundLoopUFO());

            // Bomb vs. Wall
            ColPairManager.Add(ColPair.Name.Bomb_Wall, BombManager.GetGroup(), pWallGroup);
            ColPairManager.AttachObserver(ColPair.Name.Bomb_Wall, new ObserverRemoveBomb());
            ColPairManager.AttachObserver(ColPair.Name.Bomb_Wall, new ObserverSpawnExplosion());

            //---------------------------------------------------------------------------------------------------------
            // Input
            //---------------------------------------------------------------------------------------------------------
            InputSubject pLeft = InputManager.GetSubjectArrowLeft();
            pLeft.Attach(new ObserverMoveLeft());

            InputSubject pRight = InputManager.GetSubjectArrowRight();
            pRight.Attach(new ObserverMoveRight());

            InputSubject pSpace = InputManager.GetSubjectSpace();
            pSpace.Attach(new ObserverShoot());

            //---------------------------------------------------------------------------------------------------------
            // Load the Scene Text
            //---------------------------------------------------------------------------------------------------------
            FontManager.LoadScreenFont(textBatch, FontManager.ScreenFont.GamePlay);
        }

        public override void Transition(float systemTime)
        {
            GameObjectNodeManager.Clear();

            this.Initialize(systemTime);

            InputManager.SetState(InputState.State.Play);

            ScoreManager.ResetScore(Score.Name.Player1);

            ShipManager.ActivateShip();
        }

        public override void Update(float systemTime)
        {
            Simulation.Update(systemTime);

            if (Simulation.GetTimeStep() > 0.0f)
            {
                // ColBoxes
                bool BoxesPressed = Azul.Input.GetKeyState(Azul.AZUL_KEY.KEY_B);
                if (BoxesPressed == true && this.LastBoxesPressed == false)
                {
                    this.colBoxes.SetDrawEnable(DrawBoxes);
                    DrawBoxes = !DrawBoxes;
                }
                this.LastBoxesPressed = BoxesPressed;


                TimerManager.Update(Simulation.GetTotalTime());

                GameObjectNodeManager.UpdateAll();

                ColPairManager.Update();

                DelayedEventManager.Process();

                if(this.pAlienGrid.GetLeafCount() == 0)
                {
                    SceneManager.AdvanceLevel(systemTime);
                }
            }

        }
    }
}
