//日本語対応
using TeamB_TD.Stage.Place;

namespace TeamB_TD
{
    namespace Stage
    {
        public class ProtoCell2 : IStageCell, IObjectPlaceable
        {
            private PlaceableObject _placedObject = null;

            public bool IsPlaced => _placedObject;

            public PlaceableObject PlacedObject => _placedObject;

            public void Place(PlaceableObject placedObject)
            {
                _placedObject = placedObject;
            }

            public void Focus()
            {
                // フォーカスされた時に呼び出される。
            }

            public void Unfocus()
            {
                // フォーカスから外れた時に呼び出される。
            }
        }
    }
}