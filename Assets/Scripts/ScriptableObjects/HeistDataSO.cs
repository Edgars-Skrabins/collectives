using UnityEngine;

namespace Collectives.ScriptableObjects
{
    [CreateAssetMenu(fileName = "ValuableData", menuName = "Collectives/ValuableData", order = 0)]
    public class HeistDataSO : ScriptableObject
    {
        public string heistName;
        public string description;
        public int amountOfValuablesRequired;
        public int[] mustHaveValuableIDs;
    }
}