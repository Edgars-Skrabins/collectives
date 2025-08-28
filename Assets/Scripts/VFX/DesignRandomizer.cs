using System;
using Collectives.GlobalConstants;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;
using Random = UnityEngine.Random;

namespace Collectives
{
    public class DesignRandomizer : MonoBehaviour
    {
        [Serializable]
        public class DesignPreset
        {
            public Color color;
            public Texture? decalTexture;
        }

        [SerializeField] private Renderer m_renderer;
        [SerializeField] private DesignPreset[] m_designPresets;
        [SerializeField] private DecalProjector m_decalProjector;

        private void OnEnable()
        {
            ApplyRandomDesign();
        }

        private void ApplyRandomDesign()
        {
            DesignPreset designPreset = m_designPresets[Random.Range(0, m_designPresets.Length)];
            ApplyRandomColor(designPreset);
            ApplyRandomDecal(designPreset);
        }

        private void ApplyRandomColor(DesignPreset designPreset)
        {
            m_renderer.materials[0].color = designPreset.color;
        }

        private void ApplyRandomDecal(DesignPreset designPreset)
        {
            if (designPreset.decalTexture == null)
            {
                Destroy(m_decalProjector.gameObject);
                return;
            }
            m_decalProjector.material.SetTexture(UnityShaderPropertyNames.MainTexture, designPreset.decalTexture);
        }
    }
}