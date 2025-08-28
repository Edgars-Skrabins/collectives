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
        [SerializeField] private DecalProjector[] m_decalProjectors;

        private void OnEnable()
        {
            ApplyRandomDesign();
        }

        private void ApplyRandomDesign()
        {
            DesignPreset designPreset = m_designPresets[Random.Range(0, m_designPresets.Length)];
            ApplyColor(designPreset);
            AttemptApplyDecals(designPreset);
        }

        private void ApplyColor(DesignPreset designPreset)
        {
            m_renderer.materials[0].color = designPreset.color;
        }

        private void AttemptApplyDecals(DesignPreset designPreset)
        {
            if (designPreset.decalTexture == null)
            {
                DestroyAllDecalProjectors();
            }

            ApplyDecals(designPreset);
        }

        private void DestroyAllDecalProjectors()
        {
            foreach (DecalProjector decalProjector in m_decalProjectors)
            {
                Destroy(decalProjector.gameObject);
            }
        }

        private void ApplyDecals(DesignPreset designPreset)
        {
            foreach (DecalProjector decalProjector in m_decalProjectors)
            {
                decalProjector.material.SetTexture(UnityShaderPropertyNames.MainTexture, designPreset.decalTexture);
            }
        }
    }
}