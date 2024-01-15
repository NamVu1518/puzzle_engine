using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{

    //UI Variable
    //++++++++++++++++++++++++++++++++++++++++++++++//
    public Dictionary<System.Type, UICanvas> dicUI = new Dictionary<System.Type, UICanvas>();
    public Dictionary<System.Type, UICanvas> dicUIPefab = new Dictionary<System.Type, UICanvas>();
    private UICanvas[] arrCanvas;

    public Transform canvasParent;

    //Button Variable
    //*********************************************//
    [SerializeField] private Button[] buttonArray;

    private void Awake()
    {
        SetUpButtonArray();
    }

    //UI Funtion
    //********************************************//
    public T OpenUI<T>() where T : UICanvas
    {
        UICanvas canvas = GetUI<T>();

        //canvas.Setup();
        canvas.Open();

        return canvas as T;
    }



    public void CloseUI<T>() where T : UICanvas
    {
        if (IsOpening<T>())
        {
            GetUI<T>().Close();
        }
    }

    public void CloseAll()
    {
        foreach (var item in dicUI)
        {
            if (item.Value != null && item.Value.gameObject.activeInHierarchy)
            {
                item.Value.Close();
            }
        }
    }

    public T GetUI<T>() where T : UICanvas
    {
        if (!IsInitialized<T>())
        {
            UICanvas canvas = Instantiate(GetUIPrefab<T>(), canvasParent);
            dicUI[typeof(T)] = canvas;
        }

        return dicUI[typeof(T)] as T;
    }

    private T GetUIPrefab<T>() where T : UICanvas
    {
        if (!dicUIPefab.ContainsKey(typeof(T)))
        {
            if (arrCanvas == null)
            {
                arrCanvas = Resources.LoadAll<UICanvas>("");
            }

            for (int i = 0; i < arrCanvas.Length; i++)
            {
                if (arrCanvas[i] is T)
                {
                    dicUIPefab[typeof(T)] = arrCanvas[i];
                    break;
                }
            }
        }

        return dicUIPefab[typeof(T)] as T;
    }

    public bool IsInitialized<T>() where T : UICanvas
    {
        System.Type type = typeof(T);
        return dicUI.ContainsKey(type) && dicUI[type] != null;
    }

    public bool IsOpening<T>() where T : UICanvas
    {
        return IsInitialized<T>() && dicUI[typeof(T)].gameObject.activeInHierarchy;
    }


    //Button Funtion
    //************************************************//
    private void SetUpButtonArray()
    {
        int amount = Enum.GetValues(typeof(EnumButton)).Length;
        buttonArray = new Button[amount];
    }

    public void RegisterButton(EnumButton enumButton = EnumButton.NONE, EnumGameCommand enumGameCommand = EnumGameCommand.NONE, Button button = null)
    {
        if (enumButton == EnumButton.NONE || button == null)
        {
            Debug.LogError("Paramater is not valid");
            return;
        }

        buttonArray[(int)enumButton] = button;
        button.onClick.AddListener(() => CommandManager.Ins.CommandExcute(enumGameCommand));
    }

    public void UnregisterButton(EnumButton enumButton)
    {
        if (enumButton == EnumButton.NONE)
        {
            Debug.LogError("Paramater is not valid");
            return;
        }

        buttonArray[(int)enumButton] = null;
    }
}