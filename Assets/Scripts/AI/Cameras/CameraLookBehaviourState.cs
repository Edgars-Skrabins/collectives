using System;
using System.Collections;
using UnityEngine;

namespace Collectives.AICameraSystems
{
    public abstract class CameraLookBehaviourState
    {
        protected readonly Transform ObjectToRotate;

        protected CameraLookBehaviourState(Transform objectToRotate)
        {
            ObjectToRotate = objectToRotate;
        }

        public abstract IEnumerator Execute(LookAction action);
    }

    [Serializable]
    public class LookAction
    {
        public CameraLookBehaviourTypes actionType;
        public Vector3 targetPosition;
        public float timeDuration;
    }
}