using UnityEditor;

[CustomEditor(typeof(WaitHereAction))]
public class WaitHereActionEditor : ActionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Wait Here Action";
    }
}