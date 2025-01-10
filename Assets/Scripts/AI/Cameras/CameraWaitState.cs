using UnityEngine;
using System.Collections;

namespace Collectives.AICameraSystems
{
    public class CameraWaitState : CameraLookBehaviourState
    {
        public CameraWaitState(Transform objectToRotate) : base(objectToRotate) { }

        public override IEnumerator Execute(LookAction action)
        {
            yield return new WaitForSeconds(action.timeDuration);
        }
    }
}