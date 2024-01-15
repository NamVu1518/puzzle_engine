using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Tooltip("This class is father of object can pooling")]
public class GameUnit : MonoBehaviour
{
    [Header("Game Units Option")]
    public EnumPoolObject poolType;
    public Transform tf;
}