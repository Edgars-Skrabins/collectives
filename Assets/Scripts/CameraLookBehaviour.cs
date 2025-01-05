using System.Collections;
using UnityEngine;

public class CameraLookBehaviour : MonoBehaviour
{
    private enum LookActionTypes
    {
        Turn, Wait
    }

    [System.Serializable]
    private class LookAction
    {
        public LookActionTypes actionType;

        public Vector3 targetPosition;
        public float timeDuration;
    }

    [SerializeField] private LookAction[] m_lookActions;
    [SerializeField] private Transform m_objectToRotate;

    private IEnumerator Start()
    {
        yield return StartActions();
    }

    private IEnumerator StartActions()
    {
        while (true)
        {
            foreach (LookAction _action in m_lookActions)
            {
                switch (_action.actionType)
                {
                    case LookActionTypes.Turn:
                        yield return CO_ExecuteTurnBehaviourAction(m_objectToRotate, _action.targetPosition, _action.timeDuration);
                        break;
                    case LookActionTypes.Wait:
                        yield return CO_ExecuteWaitBehaviourAction(_action.timeDuration);
                        break;
                }
            }
        }
    }

    private IEnumerator CO_ExecuteTurnBehaviourAction(Transform _transform, Vector3 _targetPosition, float _timeDuration)
    {
        float elapsedTime = 0f;
        Quaternion initialRotation = _transform.rotation;
        Quaternion targetRotation = Quaternion.LookRotation(_targetPosition - _transform.position);

        while (elapsedTime < _timeDuration)
        {
            _transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / _timeDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        _transform.rotation = targetRotation;
    }

    private IEnumerator CO_ExecuteWaitBehaviourAction(float _timeDuration)
    {
        yield return new WaitForSeconds(_timeDuration);
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if (m_lookActions == null)
        {
            return;
        }

        for (int i = 0; i < m_lookActions.Length; i++)
        {
            if (m_lookActions[i].actionType == LookActionTypes.Turn)
            {
                GizmoUtility.DrawWireSphere(m_lookActions[i].targetPosition, 0.5f, gameObject.layer);
            }
        }
    }
#endif
}
