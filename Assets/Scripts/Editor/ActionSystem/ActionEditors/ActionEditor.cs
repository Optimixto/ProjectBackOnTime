using System;
using UnityEditor;
using UnityEngine;

public abstract class ActionEditor : Editor
{
    public bool showAction;
    public SerializedProperty actionsProperty;


    private Action action;


    private const float buttonWidth = 30f;


    private void OnEnable()
    {
        action = (Action)target;
        Init();
    }


    protected virtual void Init() { }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.BeginVertical(GUI.skin.box);
        EditorGUI.indentLevel++;

        EditorGUILayout.BeginHorizontal();

        showAction = EditorGUILayout.Foldout(showAction, GetFoldoutLabel());

        if (GUILayout.Button("-", GUILayout.Width(buttonWidth)))
        {
            actionsProperty.RemoveFromObjectArray(action);
        }
        EditorGUILayout.EndHorizontal();

        if (showAction)
        {
            DrawAction();
        }

        EditorGUI.indentLevel--;
        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }


    public static Action CreateAction(Type actionType)
    {
        return (Action)CreateInstance(actionType);
    }


    protected virtual void DrawAction()
    {
        DrawDefaultInspector();
    }


    protected abstract string GetFoldoutLabel();
}
