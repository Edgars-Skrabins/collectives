using System.Collections;
using UnityEngine;

namespace Collectives.AICameraSystems
{
    public class CameraTurnState : CameraLookBehaviourState
    {
        public CameraTurnState(Transform objectToRotate) : base(objectToRotate)
        {
        }

        public override IEnumerator Execute(LookAction action)
        {
            float elapsedTime = 0f;
            Quaternion initialRotation = ObjectToRotate.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(action.targetPosition - ObjectToRotate.position);

            while (elapsedTime < action.timeDuration)
            {
                ObjectToRotate.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsedTime / action.timeDuration);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            ObjectToRotate.rotation = targetRotation;
        }
    }
}