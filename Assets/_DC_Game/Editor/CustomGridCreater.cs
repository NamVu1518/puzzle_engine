using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(GridCreator), true)]
[CanEditMultipleObjects]
public class CustomGridCreater : Editor
{
    public class Style
    {
        public static GUIStyle ToggleStyle()
        {
            GUIStyle toggleStyle = new GUIStyle(EditorStyles.miniButtonMid);
            toggleStyle.normal.background = Texture2D.grayTexture;
            toggleStyle.onNormal.background = Texture2D.whiteTexture;
            toggleStyle.fixedWidth = 15f;
            toggleStyle.fixedHeight = 15f;
            toggleStyle.alignment = TextAnchor.MiddleCenter;

            return toggleStyle;
        }

        public static GUIStyle HorizontalStyle()
        {
            GUIStyle rowStyle = new GUIStyle();
            rowStyle.fixedWidth = EditorGUIUtility.singleLineHeight;
            //rowStyle.alignment = TextAnchor.UpperLeft;

            return rowStyle;
        }

        public static GUIStyle VerticalStyle()
        {
            GUIStyle rowStyle = new GUIStyle();
            rowStyle.fixedHeight = EditorGUIUtility.singleLineHeight;
            //rowStyle.alignment = TextAnchor.UpperLeft;

            return rowStyle;
        }

        public static GUIStyle HeaderStyle()
        {
            GUIStyle headerStyle = new GUIStyle();
            headerStyle.fontStyle = FontStyle.Bold;
            headerStyle.normal.textColor = Color.white;

            return headerStyle;
        }
    }

    private GridCreator creator => target as GridCreator;
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUI.BeginChangeCheck(); // Begin change check

        DrawNewTable();

        EditorGUILayout.Space(20);
        EditorGUILayout.LabelField("Table", Style.HeaderStyle());
        EditorGUILayout.Space(5);

        DrawNewToggle();

        if (EditorGUI.EndChangeCheck()) // End change check
        {
            serializedObject.ApplyModifiedProperties(); // Apply changes to serialized object
            EditorUtility.SetDirty(creator);
        }

    }

    private void DrawNewTable()
    {
        int columnAmountTemp = creator.columnsAmount;
        int rowAmountTemp = creator.rowsAmount;

        creator.columnsAmount = EditorGUILayout.IntField("Collumn Amount", creator.columnsAmount);
        creator.rowsAmount = EditorGUILayout.IntField("Row Amount", creator.rowsAmount);

        if ((creator.columnsAmount != columnAmountTemp || creator.rowsAmount != rowAmountTemp) 
            && creator.columnsAmount > 0 
            && creator.rowsAmount > 0)
        {
            creator.CreateNewTable();
        }
    }

    private void DrawNewToggle()
    {
        if (creator.columnsAmount <= 0 || creator.rowsAmount <= 0) 
        {
            EditorGUILayout.HelpBox("Row or witdh can't be <= 0", MessageType.Error);
            return; 
        }

        for (int i = 0; i < creator.rows.Length; i++)
        {
            EditorGUILayout.BeginHorizontal(Style.HorizontalStyle());
            for (int j = 0; j < creator.rows[i].checkBoxArray.Length; j++)
            {
                creator.rows[i].checkBoxArray[j] = EditorGUILayout.Toggle(creator.rows[i].checkBoxArray[j], Style.ToggleStyle());
                EditorGUILayout.Space(1);
            }

            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(1);
        }
    }
}
