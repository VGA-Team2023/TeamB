//日本語対応
using TeamB_TD.Player;
using TeamB_TD.Stage.Place;

namespace TeamB_TD
{
    namespace Stage
    {
        public class StageCell : IStageCell, IUnitPlaceable, IFocusable
        {
            public StageCell(int initialCellState)
            {
                _cellStatus = (CellStatus)initialCellState;
            }

            private CellStatus _cellStatus;
            private UnitBehaviour _placedObject = null;

            public CellStatus Status => _cellStatus;
            public UnitBehaviour PlacedObject => _placedObject;
            public bool IsPlaced => _placedObject;

            public void Place(UnitBehaviour placedObject)
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