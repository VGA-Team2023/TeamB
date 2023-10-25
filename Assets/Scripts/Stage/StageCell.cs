//日本語対応
using TeamB_TD.Unit;
using UnityEngine;

namespace TeamB_TD
{
    namespace StageManagement
    {
        public class StageCell : IStageCell
        {
            public StageCell(int yPos, int xPos, int initialCellState)
            {
                _cellStatus = (CellStatus)initialCellState;
            }

            public void AttachView(IStageCellView stageCellView)
            {
                _stageCellView = stageCellView;
            }

            private int _yPos;
            private int _xPos;
            private CellStatus _cellStatus;
            private UnitBehaviour _placedObject;
            private IStageCellView _stageCellView;

            public int YPos => _yPos;
            public int XPos => _xPos;
            public CellStatus Status => _cellStatus;
            public UnitBehaviour PlacedObject => _placedObject;
            public bool IsPlaced => _placedObject;

            public virtual GameObject GameObject { get { return _stageCellView.GameObject; } }

            public void Place(UnitBehaviour placedObject)
            {
                _placedObject = placedObject;
            }

            public void Focus()
            {
                // Debug.Log("focused");
            }

            public void Unfocus()
            {
                // Debug.Log("unfocused");
            }
        }
    }
}