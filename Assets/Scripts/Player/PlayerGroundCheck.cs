using UnityEngine;
using System.Collections;

public class PlayerGroundCheck : MonoBehaviour
{
    [SerializeField] private Transform m_groundCheckTF;
    [SerializeField] private float m_groundCheckRadius;
    [SerializeField] private LayerMask m_groundLayer;

    public bool IsGrounded()
    {
        Collider[] hits = new Collider[5];
        Physics.OverlapSphereNonAlloc(m_groundCheckTF.position, m_groundCheckRadius, hits, m_groundLayer);

        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] != null)
                return true;
        }

        return false;
    }

    private void OnDrawGizmos()
    {
        DebugUtility.DrawGizmo(() =>
        {
            Gizmos.color = IsGrounded() ? Color.blue : Color.green;
            Gizmos.DrawWireSphere(m_groundCheckTF.position, m_groundCheckRadius);
        });
    }
}
