using UnityEngine;
using System.Collections;

public class PlayerGroundCheck : MonoBehaviour
{
    [SerializeField] private Transform m_groundCheckTF;
    [SerializeField] private float m_groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask m_groundLayer;

    public bool IsGrounded()
    {
        Collider[] hits = Physics.OverlapSphere(m_groundCheckTF.position, m_groundCheckRadius, m_groundLayer);

        if (hits.Length > 0)
        {
            return true;
        }

        return false;
    }
}
