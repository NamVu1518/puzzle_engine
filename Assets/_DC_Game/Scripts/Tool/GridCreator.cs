using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu]
public class GridCreator : ScriptableObject
{
    [Serializable]
    public class Row
    {
        public bool[] checkBoxArray;
        public int columnAmount = 0; 

        public Row(int column) 
        {
            this.columnAmount = column;
            checkBoxArray = new bool[columnAmount];
        }
    }

    public Row[] rows;
    public int rowsAmount = 0;
    public int columnsAmount = 0;
    public bool test;

    public GridCreator(int rowAmount = 0, int columnAmount = 0)
    {
        this.rowsAmount = rowAmount;
        this.columnsAmount = columnAmount;

        CreateNewTable();
    }

    public void CreateNewTable()
    {
        rows = new Row[rowsAmount];

        for (int i = 0; i < rows.Length; i++)
        {
            rows[i] = new Row(columnsAmount);
        }
    }
}
