//日本語対応
using UnityEngine;
using TeamB_TD.Unit;

namespace TeamB_TD
{
    namespace StageManagement
    {
        public class StageCell : IStageCell, IUnitPlaceable
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
                Debug.Log($"focused");
            }

            public void Unfocus()
            {
                Debug.Log($"unfocused");
            }
        }
    }
}