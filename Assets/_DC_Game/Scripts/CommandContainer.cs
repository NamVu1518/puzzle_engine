using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandContainer{ }

//Command control game state
#region Game Control Command 
public class InItGameCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.INIT);
        SoundManager.Ins.PlaySound(EnumMusic.MAINMENU_MUSIC);
    }

    public override void Undo()
    {

    }
}

public class StartNewGameCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.START_NEW_GAME);
        SoundManager.Ins.PlaySound(EnumMusic.GAMEMENU_MUSIC);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UIGamemenu>();
    }

    public override void Undo()
    {

    }
}

public class ResumeCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.RESUME);
        SoundManager.Ins.PlaySound(EnumMusic.GAMEMENU_MUSIC);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UIGamemenu>();
    }

    public override void Undo()
    {

    }
}

public class PauseGameCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.PAUSE);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UIPause>();
    }

    public override void Undo()
    {

    }
}

public class SettingGameCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.SETTING);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UISetting>();
    }

    public override void Undo()
    {

    }
}

public class BackToMainMenuCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.BACK_TO_MAIN_MENU);
        SoundManager.Ins.PlaySound(EnumMusic.MAINMENU_MUSIC);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UIMainmenu>();
    }

    public override void Undo()
    {
       
    }
}

public class PlayAgainCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.PLAY_AGAIN);
        SoundManager.Ins.PlaySound(EnumMusic.GAMEMENU_MUSIC);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UIGamemenu>();
    }

    public override void Undo()
    {
       
    }
}

public class NextLevelCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.NEXT_LEVEL);
        SoundManager.Ins.PlaySound(EnumMusic.GAMEMENU_MUSIC);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UIGamemenu>();
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }
}

public class ShopCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.SHOP);
        SoundManager.Ins.PlaySound(EnumMusic.SHOPMENU_MUSIC);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UIShop>();
    }

    public override void Undo()
    {
        throw new System.NotImplementedException();
    }
}

public class WinGameCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.WIN);
        SoundManager.Ins.PlaySound(EnumMusic.WINMENU_MUSIC);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UIWin>();
    }

    public override void Undo()
    {

    }
}

public class LoseGameCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.LOSE);
        SoundManager.Ins.PlaySound(EnumMusic.LOSEMENU_MUSIC);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UILose>();
    }

    public override void Undo()
    {

    }
}

public class LoadGameCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.LOAD);
        UIManager.Ins.CloseAll();
        UIManager.Ins.OpenUI<UILoadGame>();
    }

    public override void Undo()
    {

    }
}

public class ExitGameCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.EXIT);
    }

    public override void Undo()
    {

    }
}

public class BuyItemCommand : ACommand
{
    public override void Execute()
    {
        ActionManager.Ins.InvokeAction(EnumAction.BUY_ITEM);
    }

    public override void Undo()
    {

    }
}
#endregion