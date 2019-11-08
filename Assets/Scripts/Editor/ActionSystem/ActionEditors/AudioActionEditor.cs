using UnityEditor;

[CustomEditor(typeof(AudioPlayAction))]
public class AudioPlayActionEditor : ActionEditor
{
    protected override string GetFoldoutLabel()
    {
        return "Audio Play Action";
    }
}