using UnityEditor;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Waypoint myWaypoint = (Waypoint)target;
        
        EditorGUILayout.LabelField("Actions: " + myWaypoint.defaultActionCollection.actions.Length);
    }
}
