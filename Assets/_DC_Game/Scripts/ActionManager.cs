using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActionManager : Singleton<ActionManager>
{
    private Action[] actionGameArray;

    private void Awake()
    {
        SetUpActionGameStateArray();
    }

    private void SetUpActionGameStateArray()
    {
        int amount = Enum.GetValues(typeof(EnumAction)).Length;
        actionGameArray = new Action[amount];
    }
    
    /// <summary>
    /// Dont call this function in Awake
    /// </summary>
    /// <param name="actionEnum"></param>
    /// <param name="action"></param>
    public void AddAction(EnumAction actionEnum = EnumAction.NONE, Action action = null)
    {
        if (actionEnum == EnumAction.NONE || action == null) return;

        actionGameArray[(int)actionEnum] += action;
    }

    public void RemoveAction(GameState gameState = GameState.NONE, Action action = null)
    {
        if (gameState == GameState.NONE || action == null) return;

        Action tempAction = (Action)Delegate.Remove(actionGameArray[(int)gameState], action);

        if (tempAction == null) Debug.LogWarning(String.Format("Not exist {action} in {gameState} action"));
    }

    public void InvokeAction(EnumAction actionEnum = EnumAction.NONE)
    {
        if (actionEnum == EnumAction.NONE) return;

        actionGameArray[(int)actionEnum]?.Invoke();
    }
}
