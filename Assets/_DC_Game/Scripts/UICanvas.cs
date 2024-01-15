using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICanvas : MonoBehaviour
{
    public void Setup()
    {

    }

    public void Open()
    {
        this.gameObject.SetActive(true);
    }

    public void OpenDelay(float timeDelay)
    {
        Invoke(nameof(Open), timeDelay);
    }

    public void Close()
    {
        this.gameObject.SetActive(false);
    }

    public void CloseDelay(float timeDelay)
    {
        Invoke(nameof(Close), timeDelay);
    }
}