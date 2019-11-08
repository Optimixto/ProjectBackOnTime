using UnityEditor;

[CustomEditor(typeof(RotateTowardsAction))]
public class RotateTowardsActionEditor : ActionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Rotate Towards Action";
    }
}
