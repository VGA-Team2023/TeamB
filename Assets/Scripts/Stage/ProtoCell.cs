using UnityEngine;

//日本語対応
namespace TeamB_TD
{
    namespace Stage
    {
        public class ProtoCell : MonoBehaviour
        {
            public CellState CellStatus => _cellStatus;
            public Vector3 GenerateMuzzle =>
                new Vector3(0f, transform.position.y + transform.localScale.y / 2, 0f);

            [SerializeField] private CellState _cellStatus = CellState.None;

            /// <summary>セルステータスに任意のステータスが含まれているかを調べる</summary>
            /// <param name="status">含まれているかを調べたいセルステータス</param>
            /// <returns>含まれているかどうか</returns>
            public bool IsContainsCellState(CellState status)
            {
                return _cellStatus.HasFlag(status);
            }
        }

        [System.Serializable, System.Flags]
        public enum CellState : byte
        {
            None = 0,
            Wall = 1,
            Path = 2,
            CanPlace = 4,
            CannotPlace = 8,
        }
    }
}