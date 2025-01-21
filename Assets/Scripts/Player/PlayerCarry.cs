using System.Collections;
using System.Collections.Generic;
using Collectives.Valuable;
using UnityEngine;

namespace Collectives.PlayerSystems
{
    public class PlayerCarry : MonoBehaviour
    {
        [SerializeField] private Player m_player;
        [SerializeField] private float m_throwForce;
        [SerializeField] private LayerMask m_valuableLayer;

        private Valuable.Valuable m_currentValuable;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.G) && m_currentValuable != null)
            {
                ThrowValuable();
            }
        }

        private void ThrowValuable()
        {
            Rigidbody valuableBody = m_currentValuable.GetComponent<Rigidbody>();
            Vector3 throwVector = transform.up + transform.forward * m_throwForce;

            valuableBody.isKinematic = false;
            valuableBody.AddForce(throwVector);
            valuableBody.transform.parent = null;
            SetCurrentValuable(null);
        }

        public void SetCurrentValuable(Valuable.Valuable _newValuable)
        {
            if (_newValuable != null)
            {
                m_currentValuable = _newValuable;
                m_currentValuable.GetComponent<Rigidbody>().isKinematic = true;
                m_currentValuable.gameObject.layer = gameObject.layer;
                m_player.GetPlayerMovement().SetMoveSpeedMultiplier(GetWeightToSpeedMultiplier(m_currentValuable.GetWeightClass()));
            }
            else
            {
                m_currentValuable = null;
                m_currentValuable.gameObject.layer = m_valuableLayer;
                m_player.GetPlayerMovement().SetMoveSpeedMultiplier(1f);
            }
        }

        private float GetWeightToSpeedMultiplier(EWeightClasses _weightClass)
        {
            return 1f - (float)_weightClass / 100; // Based on description given in weight class.
        }
    }
}
