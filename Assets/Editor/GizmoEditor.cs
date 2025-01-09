using Collectives.Utilities;
using UnityEditor;
using UnityEngine;

namespace Collectives.Editor
{
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

            var layers = GizmosUtility.GetLayerToggles();
            for (int i = 0; i < layers.Length; i++)
            {
                string layerName = LayerMask.LayerToName(i);
                if (!string.IsNullOrEmpty(layerName))
                {
                    bool currentState = GizmosUtility.IsLayerGizmoEnabled(i);
                    bool newState = EditorGUILayout.Toggle($"Layer {i}: {layerName}", currentState);
                    if (newState != currentState)
                    {
                        GizmosUtility.SetLayerGizmo(i, newState);
                    }
                }
            }

            EditorGUILayout.EndScrollView();
        }
    }
}