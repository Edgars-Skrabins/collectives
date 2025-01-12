using System.Collections;
using System.Collections.Generic;
using Collectives.Utilities;
using UnityEngine;

namespace Collectives.AICameraSystems
{
    public class CameraLookBehaviour : MonoBehaviour
    {
        [SerializeField] private LookAction[] m_lookActions;
        [SerializeField] private Transform m_objectToRotate;
        private readonly Dictionary<CameraLookBehaviourTypes, CameraLookBehaviourState> m_states = new();

        private void Awake()
        {
            m_states[CameraLookBehaviourTypes.Turn] = new CameraTurnState(m_objectToRotate);
            m_states[CameraLookBehaviourTypes.Wait] = new CameraWaitState(m_objectToRotate);
        }

        private IEnumerator Start()
        {
            yield return StartActions();
        }

        private IEnumerator StartActions()
        {
            while (true)
            {
                foreach (LookAction action in m_lookActions)
                {
                    yield return m_states[action.actionType].Execute(action);
                }
            }
        }

        private void OnDisable()
        {
            StopAllCoroutines();
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            if (m_lookActions == null) return;

            foreach (LookAction action in m_lookActions)
            {
                if (action.actionType == CameraLookBehaviourTypes.Turn)
                {
                    GizmosUtility.DrawWireSphere(action.targetPosition, 0.5f, gameObject.layer, Color.green);
                }
                else
                {
                    GizmosUtility.DrawWireSphere(action.targetPosition, 0.25f, gameObject.layer, Color.red);
                }
            }
        }
#endif
    }
}
