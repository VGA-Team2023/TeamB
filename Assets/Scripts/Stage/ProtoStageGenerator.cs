using UnityEngine;

//日本語対応
namespace TeamB_TD
{
    namespace Stage
    {
        public class ProtoStageGenerator : MonoBehaviour
        {
            [SerializeField] private ProtoCell _wall = null;
            [SerializeField] private ProtoCell _path = null;
            [SerializeField] private ProtoCell _spawn = null;
            [SerializeField] private ProtoCell _tower = null;

            private StageBlueprint _stage = new();

            private void Start()
            {
                bool isNull = !_wall || !_path || !_spawn || !_tower;
                if (isNull) throw new System.NullReferenceException();

                GenerateMap();
            }

            private void GenerateMap()
            {
                if (_stage == null) throw new System.NullReferenceException("Stage is not found");

                ProtoCell cell = null;

                for (int r = 0; r < _stage.Map.GetLength(0); r++)
                    for (int c = 0; c < _stage.Map.GetLength(1); c++)
                    {
                        cell = _stage.Map[r, c] switch
                        {
                            0 => _wall,
                            1 => _path,
                            2 => _spawn,
                            3 => _tower,
                        };
                        Instantiate(cell, ConvertSenter(r, c), Quaternion.identity, transform);
                    }
            }

            /// <summary>ステージの中央がカメラの中央になるように座標を変換する</summary>
            /// <param name="r">行番号</param>
            /// <param name="c">列番号</param>
            /// <returns>変換された座標</returns>
            private Vector3 ConvertSenter(int r, int c)
                => new Vector3(r - _stage.Map.GetLength(0) / 2, 0f, -(c - _stage.Map.GetLength(1) / 2));
        }
    }
}