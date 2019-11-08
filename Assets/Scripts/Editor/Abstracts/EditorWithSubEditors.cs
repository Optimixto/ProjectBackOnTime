using UnityEngine;
using UnityEditor;

public abstract class EditorWithSubEditors<TEditor, TTarget> : Editor //We'll need to give it a target and its subeditors. e.g. target = conditions
    where TEditor : Editor
    where TTarget : Object //Unity editors can only target unity objects
{
    protected TEditor[] subEditors;


    protected void CheckAndCreateSubEditors(TTarget[] subEditorTargets)
    {
        if (subEditors != null && subEditors.Length == subEditorTargets.Length) //if not null and already have the right number, do nothing
            return;

        CleanupEditors();

        subEditors = new TEditor[subEditorTargets.Length];

        for (int i = 0; i < subEditors.Length; i++)
        {
            subEditors[i] = CreateEditor(subEditorTargets[i]) as TEditor;
            SubEditorSetup(subEditors[i]);
        }
    }


    protected void CleanupEditors()
    {
        if (subEditors == null)
            return;

        for (int i = 0; i < subEditors.Length; i++)
        {
            DestroyImmediate(subEditors[i]); //DestroyImmediate is called on the editor. Destroy is just for Scene Objects.
        }

        subEditors = null;
    }


    protected abstract void SubEditorSetup(TEditor editor); //Needs to be created by the inheriting classes (forced anyways)
}
