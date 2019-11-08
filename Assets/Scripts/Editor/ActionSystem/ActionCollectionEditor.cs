using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(ActionCollection))]
public class ActionCollectionEditor : EditorWithSubEditors<ActionEditor, Action>
{
    private ActionCollection ActionCollection;
    private SerializedProperty ActionsProperty; //Used to add actions

    private Type[] ActionTypes;
    private string[] ActionTypeNames;
    private int selectedIndex;
    private const float dropAreaHeight = 50f;
    private const float controlSpacing = 5f;
    private const string actionsPropName = "actions";


    private readonly float verticalSpacing = EditorGUIUtility.standardVerticalSpacing;


    private void OnEnable()
    {
        ActionCollection = (ActionCollection)target;

        ActionsProperty = serializedObject.FindProperty(actionsPropName);

        CheckAndCreateSubEditors(ActionCollection.actions);

        SetActionNamesArray();
    }


    private void OnDisable()
    {
        CleanupEditors();
    }


    protected override void SubEditorSetup(ActionEditor editor)
    {
        editor.actionsProperty = ActionsProperty;
    }


    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        CheckAndCreateSubEditors(ActionCollection.actions);

        for (int i = 0; i < subEditors.Length; i++)
        {
            subEditors[i].OnInspectorGUI();
        }

        if (ActionCollection.actions.Length > 0)
        {
            EditorGUILayout.Space();
            EditorGUILayout.Space();
        }

        Rect fullWidthRect = GUILayoutUtility.GetRect(GUIContent.none, GUIStyle.none, GUILayout.Height(dropAreaHeight + verticalSpacing));

        Rect leftAreaRect = fullWidthRect;
        leftAreaRect.y += verticalSpacing * 0.5f;
        leftAreaRect.width *= 0.5f;
        leftAreaRect.width -= controlSpacing * 0.5f;
        leftAreaRect.height = dropAreaHeight;

        Rect rightAreaRect = leftAreaRect;
        rightAreaRect.x += rightAreaRect.width + controlSpacing;

        TypeSelectionGUI(leftAreaRect);
        DragAndDropAreaGUI(rightAreaRect);

        DraggingAndDropping(rightAreaRect, this);

        serializedObject.ApplyModifiedProperties();
    }


    private void TypeSelectionGUI(Rect containingRect)
    {
        Rect topHalf = containingRect;
        topHalf.height *= 0.5f;

        Rect bottomHalf = topHalf;
        bottomHalf.y += bottomHalf.height;

        selectedIndex = EditorGUI.Popup(topHalf, selectedIndex, ActionTypeNames);

        if (GUI.Button(bottomHalf, "Add Selected Action"))
        {
            Type actionType = ActionTypes[selectedIndex];
            Action newAction = ActionEditor.CreateAction(actionType);
            ActionsProperty.AddToObjectArray(newAction);
        }
    }


    private static void DragAndDropAreaGUI(Rect containingRect)
    {
        GUIStyle centredStyle = GUI.skin.box;
        centredStyle.alignment = TextAnchor.MiddleCenter;
        centredStyle.normal.textColor = GUI.skin.button.normal.textColor;

        GUI.Box(containingRect, "Drop new Actions here", centredStyle);
    }

    //The bare bones function used for DraggingAndDropping in Unity.
    private static void DraggingAndDropping(Rect dropArea, ActionCollectionEditor editor)
    {
        //Caching current event
        Event currentEvent = Event.current;

        //If it doesn't contain the mouse at its current position
        if (!dropArea.Contains(currentEvent.mousePosition))
            return;

        switch (currentEvent.type)
        {
            //Dragging something
            case EventType.DragUpdated:

                DragAndDrop.visualMode = IsDragValid() ? DragAndDropVisualMode.Link : DragAndDropVisualMode.Rejected;
                currentEvent.Use();

                break;
            //Release
            case EventType.DragPerform:

                DragAndDrop.AcceptDrag();

                for (int i = 0; i < DragAndDrop.objectReferences.Length; i++)
                {
                    MonoScript script = DragAndDrop.objectReferences[i] as MonoScript;

                    Type actionType = script.GetClass();

                    Action newAction = ActionEditor.CreateAction(actionType);
                    editor.ActionsProperty.AddToObjectArray(newAction);
                }

                currentEvent.Use();

                break;
        }
    }

    //Looks through all the objects being dragged and checks that they (all) inherit from Action
    private static bool IsDragValid()
    {
        for (int i = 0; i < DragAndDrop.objectReferences.Length; i++)
        {
            //not a script
            if (DragAndDrop.objectReferences[i].GetType() != typeof(MonoScript))
                return false;

            MonoScript script = DragAndDrop.objectReferences[i] as MonoScript;
            Type scriptType = script.GetClass();

            if (!scriptType.IsSubclassOf(typeof(Action)))
                return false;

            //Abstracts need their own check
            if (scriptType.IsAbstract)
                return false;
        }

        return true;
    }


    private void SetActionNamesArray()
    {
        Type actionType = typeof(Action);

        Type[] allTypes = actionType.Assembly.GetTypes();

        List<Type> actionSubTypeList = new List<Type>();

        for (int i = 0; i < allTypes.Length; i++)
        {
            if (allTypes[i].IsSubclassOf(actionType) && !allTypes[i].IsAbstract)
            {
                actionSubTypeList.Add(allTypes[i]);
            }
        }

        ActionTypes = actionSubTypeList.ToArray();

        List<string> actionTypeNameList = new List<string>();

        for (int i = 0; i < ActionTypes.Length; i++)
        {
            actionTypeNameList.Add(ActionTypes[i].Name);
        }

        ActionTypeNames = actionTypeNameList.ToArray();
    }
}
