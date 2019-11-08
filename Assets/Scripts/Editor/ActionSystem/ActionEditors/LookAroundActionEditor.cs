using UnityEditor;

[CustomEditor(typeof(LookAroundAction))]
public class LookAroundActionEditor : ActionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Look Around Action";
    }
}