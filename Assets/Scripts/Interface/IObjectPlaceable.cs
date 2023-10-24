// 日本語対応
using TeamB_TD.Player;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace Place
        {
            public interface IObjectPlaceable : IFocusable
            {
                PlaceableObject PlacedObject { get; }
                void OnPlace(PlaceableObject prefab);
            }
        }
    }
}