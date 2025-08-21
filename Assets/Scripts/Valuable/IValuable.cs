using Collectives.HeistSystems.DropOffZone;
using Collectives.ScriptableObjects;

namespace Collectives.ValuableSystems
{
    public interface IValuable
    {
        public void Collect(DropOffZoneData _dropOffZoneData);
        public ValuableDataSO GetValuableData();
        public int GetID();
    }
}