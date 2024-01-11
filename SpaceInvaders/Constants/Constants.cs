using System;
using System.Diagnostics;

namespace SpaceInvaders
{
    public static class Constants
    {
        // Screen
        public static readonly int SCREEN_X = 896;
        public static readonly int SCREEN_Y = 1024;

        // Text
        public static readonly float GAMEPLAY_TOP_TEXT_Y = 990.0f;
        public static readonly float GAMEPLAY_TOP_TEXT_X = 45.0f;
        public static readonly float SELECT_PLAY_X = 380.0f;
        public static readonly float SELECT_PLAY_Y = 775.0f;
        public static readonly float GAMEPLAY_CREDIT_X = Constants.SCREEN_Y - 450.0f;
        public static readonly float GAMEPLAY_CREDIT_Y = 70.0f;
        public static readonly float SELECT_INSERT_TITLE_X = 275.0f;
        public static readonly float SELECT_INSERT_TITLE_Y = 600.0f;
        public static readonly float GAME_OVER_TEXT_X = 320.0f;
        public static readonly float GAME_OVER_TEXT_Y = 875.0f;
        public static readonly string GAMEPLAY_TOP = "SCORE<1>  HI-SCORE  SCORE<2>";
        public static readonly string GAMEPLAY_SCORE = "0000";
        public static readonly string SELECT_PLAY = "PLAY";
        public static readonly string SELECT_TITLE = "SPACE   INVADERS";
        public static readonly string SELECT_SCOREBREAKDOWN_TITLE = "*SCORE ADVANCE TABLE*";
        public static readonly string SELECT_SCOREBREAKDOWN_UFO = "=? MYSTERY";
        public static readonly string SELECT_SCOREBREAKDOWN_SQUID = "=30 POINTS";
        public static readonly string SELECT_SCOREBREAKDOWN_CRAB = "=20 POINTS";
        public static readonly string SELECT_SCOREBREAKDOWN_OCTO = "=10 POINTS";
        public static readonly string GAMEPLAY_CREDITS = "CREDIT 00";
        public static readonly string SELECT_INSERT_COIN = "INSERT   COIN";
        public static readonly string SELECT_1_OR_2_TITLE = "<1 OR 2 PLAYERS>";
        public static readonly string SELECT_1_PLAYER_COIN = "*1 PLAYER  1 COIN";
        public static readonly string SELECT_2_PLAYER_COIN = "*2 PLAYER  2 COINS";
        public static readonly string GAME_OVER_TEXT = "GAME OVER";


        //Colors
        public static readonly Azul.Color RED = new Azul.Color(1.0f, 0.0f, 0.0f);
        public static readonly Azul.Color GREEN = new Azul.Color(0.0f, 1.0f, 0.0f);
        public static readonly Azul.Color BLUE = new Azul.Color(0.0f, 0.0f, 1.0f);
        public static readonly Azul.Color DEFAULT_SPRITE_COLOR = new Azul.Color(1.0f, 1.0f, 1.0f);
        public static readonly Azul.Color TRANSPARENT = new Azul.Color(0.0f, 0.0f, 0.0f, 0.0f);

        // Player
        public static readonly int STARTING_LIFE_COUNT = 3;

        // ALiens
        public static readonly float SQUID_WIDTH = 33.0f;
        public static readonly float SQUID_HEIGHT = 33.0f;
        public static readonly float CRAB_WIDTH = 45.0f;
        public static readonly float CRAB_HEIGHT = 33.0f;
        public static readonly float OCTO_WIDTH = 49.0f;
        public static readonly float OCTO_HEIGHT = 33.0f;
        public static readonly float ALIEN_X_START = 125.0f;
        public static readonly float ALIEN_Y_START = 585.0f;
        public static readonly float ALIEN_Y_GAP = 66.0f;

        // UFO
        public static readonly float UFO_START_X = 80.0f;
        public static readonly float UFO_X_OFFSET = Constants.SCREEN_X - (UFO_START_X * 2);
        public static readonly float UFO_Y = 875.0f;
        public static readonly float UFO_WIDTH = 65.0f;
        public static readonly float UFO_HEIGHT = 33.0f;
        public static readonly float UFO_MOVE_SPEED = 2.0f;
        public static readonly float UFO_SOUND_LOOP_TIME = 0.163f;

        // Bomb
        public static readonly float BOMB_WIDTH = 13.0f;
        public static readonly float BOMB_HEIGHT = 30.0f;
        public static readonly float BOMB_SPEED = 5.0f;
        public static readonly float GREEN_ZONE = 335.0f;

        // Ship
        public static readonly float SHIP_WIDTH = 52.5f;
        public static readonly float SHIP_HEIGHT = 33.0f;
        public static readonly float SHIP_Y_POS = 175.0f;
        public static readonly float SHIP_STARTING_X_POS = 85.0f;
        public static readonly float SHIP_LIFE_Y_POS = 65.0f;
        public static readonly float SHIP_MOVE_SPEED = 5.0f;

        // Missle
        public static readonly float MISSLE_WIDTH = 5.0f;
        public static readonly float MISSLE_HEIGHT = 20.0f;
        public static readonly float MISSLE_SPEED = 15.0f;

        // Shields
        public static readonly float BRICK_WIDTH = 4.0f;
        public static readonly float BRICK_HEIGHT = 4.6875f;
        public static readonly float BOTTOM_BRICK_Y = 245.0f;

        // Walls
        public static readonly float WALL_BOTTOM_WIDTH = 890.0f;
        public static readonly float WALL_BOTTOM_HEIGHT = 2.0f;

        // Explosions
        public static readonly float EXPLOSION_SMALL_WIDTH = 24.5f;
        public static readonly float EXPLOSION_SMALL_HEIGHT = 33.0f;
        public static readonly float EXPLOSION_LARGE_WIDTH = 33.5f;
        public static readonly float EXPLOSION_LARGE_HEIGHT = 33.0f;
        public static readonly float EXPLOSION_ALIEN_WIDTH = 53.0f;
        public static readonly float EXPLOSION_ALIEN_HEIGHT = 33.0f;
        public static readonly float EXPLOSION_SHIP_WIDTH = Constants.SHIP_WIDTH;
        public static readonly float EXPLOSION_SHIP_HEIGHT = Constants.SHIP_HEIGHT;

    }
}
