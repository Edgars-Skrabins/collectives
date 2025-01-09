using UnityEditor;
using UnityEngine;

namespace Collectives.Utilities
{
    public static class GizmosUtility
    {
        private static bool[] m_layerGizmoToggles;
        private const string m_EDITOR_PREF_KEY = "GizmoUtility_LayerToggle_";

        static GizmosUtility()
        {
            m_layerGizmoToggles = new bool[32];
            LoadToggles();
        }

        private static void LoadToggles()
        {
            for (int i = 0; i < m_layerGizmoToggles.Length; i++)
            {
                m_layerGizmoToggles[i] = EditorPrefs.GetBool(m_EDITOR_PREF_KEY + i, true); // Default to true
            }
        }

        private static void SaveToggles()
        {
            for (int i = 0; i < m_layerGizmoToggles.Length; i++)
            {
                EditorPrefs.SetBool(m_EDITOR_PREF_KEY + i, m_layerGizmoToggles[i]);
            }
        }

        public static bool IsLayerGizmoEnabled(int layer)
        {
            return layer >= 0 && layer < m_layerGizmoToggles.Length && m_layerGizmoToggles[layer];
        }

        public static void SetLayerGizmo(int layer, bool enabled)
        {
            if (layer >= 0 && layer < m_layerGizmoToggles.Length)
            {
                m_layerGizmoToggles[layer] = enabled;
                SaveToggles();
            }
        }

        public static void DrawWireSphere(Vector3 center, float radius, int layer, Color? color = null)
        {
            if (IsLayerGizmoEnabled(layer))
            {
                Gizmos.color = color ?? Color.white;
                Gizmos.DrawWireSphere(center, radius);
            }
        }

        public static bool[] GetLayerToggles()
        {
            return m_layerGizmoToggles;
        }
    }
}