using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private GameState currentGameState = GameState.NONE;

    public GameState CurrentGameState
    {
        get => currentGameState;
        set => currentGameState = value;
    }

    private void Awake()
    {
        UIManager.Ins.OpenUI<UIMainmenu>();
    }

    private void Start()
    {
        CommandManager.Ins.CommandExcute(EnumGameCommand.INIT);
    }

    private void OnApplicationQuit()
    {
        CommandManager.Ins.CommandExcute(EnumGameCommand.EXIT);
    }
}
