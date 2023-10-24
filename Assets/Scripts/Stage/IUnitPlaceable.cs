//日本語対応
using TeamB_TD.Unit;

namespace TeamB_TD
{
    namespace Unit
    {
        public interface IUnitPlaceable
        {
            bool IsPlaced { get; }
            UnitBehaviour PlacedObject { get; }
            void Place(UnitBehaviour placedObject);
        }
    }
}