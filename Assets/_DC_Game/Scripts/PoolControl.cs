using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PoolControl : MonoBehaviour
{
    [SerializeField] PoolAmout[] listPool;
    void Awake()
    {
        for (int i = 1; i < listPool.Length; i++)
        {
            PoolSimple.PreLoad(listPool[i].unit, listPool[i].parent, listPool[i].amout);
        }
    }
}

[System.Serializable]
public class PoolAmout
{
    public GameUnit unit;
    public Transform parent;
    public int amout;
}