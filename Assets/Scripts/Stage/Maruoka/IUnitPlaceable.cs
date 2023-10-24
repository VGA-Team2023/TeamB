//日本語対応

namespace TeamB_TD
{
    namespace Stage
    {
        namespace Place
        {
            public interface IUnitPlaceable
            {
                bool IsPlaced { get; }
                UnitBehaviour PlacedObject { get; }
                void Place(UnitBehaviour placedObject);
            }
        }
    }
}