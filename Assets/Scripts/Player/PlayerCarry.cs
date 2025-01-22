using System.Collections;
using System.Collections.Generic;
using Collectives.Valuable;
using UnityEngine;

namespace Collectives.PlayerSystems
{
    public class PlayerCarry : MonoBehaviour
    {
        [SerializeField] private Player m_player;
        [SerializeField] private Transform m_carryTransform;
        [SerializeField] private float m_throwForce;

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

            Vector3 throwDirection = m_player.GetCameraSystem().GetMainCamera().transform.forward;
            Vector3 throwVector = throwDirection * m_throwForce;

            valuableBody.isKinematic = false;
            valuableBody.AddForce(throwVector, ForceMode.Impulse);
            valuableBody.transform.parent = null;
            valuableBody.useGravity = true;
            SetCurrentValuable(null);
        }

        public void SetCurrentValuable(Valuable.Valuable _newValuable)
        {
            if (_newValuable != null)
            {
                m_currentValuable = _newValuable;
                PickUp();
            }
            else
            {
                Drop();
            }
        }

        private void Drop()
        {
            m_currentValuable.gameObject.layer = 0; // Default Layer
            m_currentValuable.transform.SetParent(null);
            m_currentValuable = null;
            m_player.GetPlayerMovement().SetMoveSpeedMultiplier(1f);
        }

        private void PickUp()
        {
            m_currentValuable.GetComponent<Rigidbody>().isKinematic = true;
            m_currentValuable.gameObject.layer = gameObject.layer;
            m_currentValuable.transform.SetParent(m_carryTransform);
            m_currentValuable.transform.localPosition = Vector3.zero;
            m_currentValuable.transform.localEulerAngles = Vector3.zero;
            m_player.GetPlayerMovement().SetMoveSpeedMultiplier(GetWeightToSpeedMultiplier(m_currentValuable.GetWeightClass()));
        }

        private float GetWeightToSpeedMultiplier(EWeightClasses _weightClass)
        {
            return 1f - (float)_weightClass / 100; // Based on description given in weight class.
        }
    }
}
