//日本語対応
using System;
using TeamB_TD.Unit;
using UnityEngine;

namespace TeamB_TD
{
    namespace StageManagement
    {
        public class Stage
        {
            private IStageCell[,] _stageCells;
            public IStageCell[,] StageCells => _stageCells;

            public bool IsInStage(int yPos, int xPos)
            {
                return
                    yPos >= 0 && xPos >= 0 &&
                    yPos < StageCells.GetLength(0) && xPos < StageCells.GetLength(1);
            }

            public bool TryGetCell(int yPos, int xPos, out IStageCell cell)
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

            public void CreateStage(int[,] stageData)
            {
                _stageCells = new IStageCell[stageData.GetLength(0), stageData.GetLength(1)];

                for (int y = 0; y < stageData.GetLength(0); y++)
                {
                    for (int x = 0; x < stageData.GetLength(1); x++)
                    {
                        _stageCells[y, x] = CreateCell(y, x, stageData[y, x]);
                    }
                }
            }

            public IStageCell CreateCell(int yPos, int xPos, int initialCellState)
            {
                if (!IsInStage(yPos, xPos)) throw new ArgumentOutOfRangeException(nameof(yPos) + ", " + nameof(xPos));
                if (_stageCells[yPos, xPos] != null)
                {
                    Debug.LogWarning(
                        $"その座標にはすでにセルが生成されています。\n" +
                        $"yPos: {yPos}, xPos: {xPos}");
                }

                var cell = new StageCell(initialCellState);
                _stageCells[yPos, xPos] = cell;

                return cell;
            }

            public void DeleteCell()
            {
                throw new NotImplementedException();
            }

            public UnitBehaviour CreateUnit(UnitBehaviour prefab, int yPos, int xPos)
            {
                if (!prefab) throw new ArgumentNullException(nameof(prefab));
                if (!TryGetCell(yPos, xPos, out IStageCell cell)) throw new ArgumentException(nameof(yPos) + ", " + nameof(xPos));

                var placeInterface = cell as IUnitPlaceable;
                if (placeInterface == null) throw new ArgumentException(nameof(placeInterface));

                var instance = GameObject.Instantiate(prefab);
                instance.Initialze(this, yPos, xPos);
                placeInterface.Place(instance);
                return instance;
            }

            public void DeletePlacedObject()
            {
                throw new NotImplementedException();
            }
        }
    }
}
