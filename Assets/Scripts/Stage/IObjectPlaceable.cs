//日本語対応
using TeamB_TD.Player;

namespace TeamB_TD
{
    namespace Stage
    {
        namespace Place
        {
            public interface IObjectPlaceable : IFocusable
            {
                bool IsPlaced { get; }
                PlaceableObject PlacedObject { get; }
                void Place(PlaceableObject placedObject);
            }
        }
    }
}