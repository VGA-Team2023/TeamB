using UnityEngine;

//日本語対応
namespace TeamB_TD
{
    namespace Stage
    {
        public class ProtoCell : MonoBehaviour
        {
            public CellState CellStatus => _cellStatus;

            [SerializeField] private CellState _cellStatus = CellState.None;

            [System.Serializable, System.Flags]
            public enum CellState : byte
            {
                None = 0,
                Wall = 1,
                Path = 2,
                CanPlace = 4,
                CantPlace = 8,
            }
        }
    }
}