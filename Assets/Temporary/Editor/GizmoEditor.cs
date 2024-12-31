using UnityEditor;
using UnityEngine;

public class GizmoEditor : EditorWindow
{
    private Vector2 m_scrollPosition;

    [MenuItem("Tools/Gizmo Layer Toggles")]
    public static void ShowWindow()
    {
        GetWindow<GizmoEditor>("Gizmo Layer Toggles");
    }

    private void OnGUI()
    {
        EditorGUILayout.LabelField("Gizmo Layer Toggles", EditorStyles.boldLabel);
        EditorGUILayout.Space();

        m_scrollPosition = EditorGUILayout.BeginScrollView(m_scrollPosition);

        var layers = GizmoUtility.GetLayerToggles();
        for (int i = 0; i < layers.Length; i++)
        {
            string layerName = LayerMask.LayerToName(i);
            if (!string.IsNullOrEmpty(layerName))
            {
                bool currentState = GizmoUtility.IsLayerGizmoEnabled(i);
                bool newState = EditorGUILayout.Toggle($"Layer {i}: {layerName}", currentState);
                if (newState != currentState)
                {
                    GizmoUtility.SetLayerGizmo(i, newState);
                }
            }
        }

        EditorGUILayout.EndScrollView();
    }
}
