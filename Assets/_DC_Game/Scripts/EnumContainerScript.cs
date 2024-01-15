using System;

public class EnumContainerScript{ }

public enum EnumButton
{
    NONE = 0,
    START_NEW_GAME = 1,
    PAUSE = 2,
    RESUME = 3,
    SETTING = 4,
    EXIT = 5,
    BACK_TO_MAIN_MENU = 6,
    BUY_ITEM = 7,
    PLAY_AGAIN = 8,
    NEXT_LEVEL = 9,
    SHOP = 10,
    //...
}

//Enum define a command
public enum EnumGameCommand
{
    NONE = 0,
    INIT = 1,
    START_NEW_GAME = 2,
    PAUSE = 3,
    RESUME = 4,
    SETTING = 5,
    WIN = 6,
    LOSE = 7,
    LOAD = 8,
    EXIT = 9,
    BACK_TO_MAIN_MENU = 10,
    BUY_ITEM = 11,
    PLAY_AGAIN = 12,
    NEXT_LEVEL = 13,
    SHOP = 14,
    //...
}

public enum EnumAction
{
    NONE = 0,
    INIT = 1,
    START_NEW_GAME = 2,
    PAUSE = 3,
    RESUME = 4,
    SETTING = 5,
    WIN = 6,
    LOSE = 7,
    LOAD = 8,
    EXIT = 9,
    BACK_TO_MAIN_MENU = 10,
    BUY_ITEM = 11,
    PLAY_AGAIN = 12,
    NEXT_LEVEL = 13,
    SHOP = 14,
    //...
}


//Enum for define game state
public enum GameState
{
    NONE = 0,
    INIT = 1,
    PLAY = 2,
    PAUSE = 3,
    RESUME = 4,
    WIN = 5,
    LOSE = 6,
    LOAD = 7, //Loading state for new scene load or new game load or sonething
    EXIT = 8,   
}

public enum EnumMusic
{
    NONE = 0,
    MAINMENU_MUSIC = 1,
    GAMEMENU_MUSIC = 2,
    WINMENU_MUSIC = 3,
    LOSEMENU_MUSIC = 4,
    SHOPMENU_MUSIC = 5,
}

public enum EnumSFX
{
    NONE = 0,
    HIT_SFX = 1,
    PUNISHMENT_SFX = 2,
    REWARD_SFX = 3,
    BUTTON_CLICK_SFX = 4,
    BUY_SFX = 5,
}

public enum EnumPoolObject
{
    none = 0,
    arrow = 1,
    axe_0 = 2,
    axe_1 = 3,
    boomerang = 4,
    candy_0 = 5,
    candy_1 = 6,
    candy_2 = 7,
    candy_4 = 8,
    hammer = 9,
    knife = 10,
    uzi = 11,
    z = 12,
    enemy = 13,
    //...
}

