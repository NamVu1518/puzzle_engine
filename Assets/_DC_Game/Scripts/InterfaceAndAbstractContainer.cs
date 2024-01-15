using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterfaceContainer{ }

public interface IStateMachine
{
    public void OnInIt();
    public void OnExcute();
    public void OnOutIt();
}

public interface IGameUnitProcess
{   
    public void Instantiate();
    public void OnInIt();
    public void OnPause();
    public void OnResume();
    public void OnDespawn();
}

public abstract class ACommand
{
    public object data; 

    public abstract void Execute();
    public abstract void Undo();
}