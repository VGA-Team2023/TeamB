//日本語対応
using System;
using TeamB_TD.Stage.Place;
using UnityEngine;

namespace TeamB_TD
{
    namespace Stage
    {
        public class ProtoStage
        {
            private IObjectPlaceable[,] _stageCells;
            public IObjectPlaceable[,] StageCells => _stageCells;

            public bool IsInStage(int yPos, int xPos)
            {
                return
                    yPos >= 0 && xPos >= 0 &&
                    yPos < StageCells.GetLength(0) && xPos < StageCells.GetLength(1);
            }

            public bool TryGetCell(int yPos, int xPos, out IObjectPlaceable cell)
            {
                if (IsInStage(yPos, xPos))
                {
                    cell = StageCells[yPos, xPos];
                }
                else
                {
                    cell = null;
                }
                return cell != null;
            }

            public event Action<IStageCell> OnCreatedCell;

            public IStageCell CreateCell(int yPos, int xPos)
            {
                if (!IsInStage(yPos, xPos)) throw new ArgumentOutOfRangeException(nameof(yPos) + ", " + nameof(xPos));
                if (_stageCells[yPos, xPos] != null)
                {
                    Debug.LogWarning(
                        $"その座標にはすでにセルが生成されています。\n" +
                        $"yPos: {yPos}, xPos: {xPos}");
                }

                var cell = new ProtoCell2();
                _stageCells[yPos, xPos] = cell;

                OnCreatedCell(cell); // ステージ見た目管理クラスが検知して見た目の生成を行う。
                return cell;
            }

            public void DeleteCell()
            {
                throw new NotImplementedException();
            }

            public PlaceableObject CreatePlaceObject(PlaceableObject prefab, int yPos, int xPos)
            {
                if (!prefab) throw new ArgumentNullException(nameof(prefab));
                if (!TryGetCell(yPos, xPos, out IObjectPlaceable cell)) throw new ArgumentException(nameof(yPos) + ", " + nameof(xPos));

                var instance = GameObject.Instantiate(prefab);
                cell.Place(instance);
                return instance;
            }

            public void DeletePlacedObject()
            {
                throw new NotImplementedException();
            }
        }
    }
}
