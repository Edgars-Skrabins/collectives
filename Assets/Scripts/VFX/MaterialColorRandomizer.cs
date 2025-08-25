using UnityEngine;

namespace Collectives
{
    public class MaterialColorRandomizer : MonoBehaviour
    {
        [SerializeField] private Renderer m_renderer;
        [SerializeField] private Color[] m_colors;
        [SerializeField] private int[] m_randomizedMaterialIndexes;

        private void OnEnable()
        {
            ApplyRandomColors();
        }

        private void ApplyRandomColors()
        {
            Material[] materials = m_renderer.materials;

            foreach (int index in m_randomizedMaterialIndexes)
            {
                if (index < 0 || index >= materials.Length)
                {
                    continue;
                }

                Color randomColor = m_colors[Random.Range(0, m_colors.Length)];
                materials[index].color = randomColor;
            }
        }
    }
}