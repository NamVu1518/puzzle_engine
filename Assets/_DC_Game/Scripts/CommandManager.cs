using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : Singleton<CommandManager>
{
    [SerializeField] private int maxUndoStep = 10;

    private Type[] commandArray;

    public Type[] CommandArray
    {
        get { return commandArray; }
    }

    private void Awake()
    {
        SetUpCommandArray();

        CommandRegister(EnumGameCommand.INIT, typeof(InItGameCommand));
        CommandRegister(EnumGameCommand.START_NEW_GAME, typeof(StartNewGameCommand));
        CommandRegister(EnumGameCommand.BACK_TO_MAIN_MENU, typeof(BackToMainMenuCommand));
        CommandRegister(EnumGameCommand.PAUSE, typeof(PauseGameCommand));
        CommandRegister(EnumGameCommand.WIN, typeof(WinGameCommand));
        CommandRegister(EnumGameCommand.LOSE, typeof(LoseGameCommand));
        CommandRegister(EnumGameCommand.SETTING, typeof(SettingGameCommand));
        CommandRegister(EnumGameCommand.RESUME, typeof(ResumeCommand));
        CommandRegister(EnumGameCommand.LOAD, typeof(LoadGameCommand));
        CommandRegister(EnumGameCommand.EXIT, typeof(ExitGameCommand));
        CommandRegister(EnumGameCommand.BUY_ITEM, typeof(BuyItemCommand));
        CommandRegister(EnumGameCommand.PLAY_AGAIN, typeof(PlayAgainCommand));
        CommandRegister(EnumGameCommand.NEXT_LEVEL, typeof(NextLevelCommand));
        CommandRegister(EnumGameCommand.SHOP, typeof(ShopCommand));
    }

    private void SetUpCommandArray()
    {
        int amount = Enum.GetValues(typeof(EnumAction)).Length;
        commandArray = new Type[amount];
    } 

    public void CommandRegister(EnumGameCommand commandEnum = EnumGameCommand.NONE, Type command = null)
    {
        if (command != null)
        {
            commandArray[(int)commandEnum] = command;
        }
    }

    public void CommandUnregister(EnumGameCommand commandEnum = EnumGameCommand.NONE)
    {
        if (commandEnum == EnumGameCommand.NONE)
        {
            Debug.LogWarning("NONE is not a command");
            return;
        }

        commandArray[(int)commandEnum] = null;
    }

    public void CommandExcute(EnumGameCommand commandEnum = EnumGameCommand.NONE, object data = null)
    {
        if (commandEnum == EnumGameCommand.NONE)
        {
            Debug.LogWarning("NONE is not a command");
            return;
        }

        ACommand newCommand = (ACommand)Activator.CreateInstance(commandArray[(int)commandEnum]);

        if (data != null) newCommand.data = data;

        newCommand.Execute();
    }
}
