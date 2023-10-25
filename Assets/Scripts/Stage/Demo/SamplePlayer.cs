// 日本語対応
using System;
using TeamB_TD.Player;
using TeamB_TD.ResourceManagement;
using TeamB_TD.StageManagement;
using TeamB_TD.Unit.PlaceDemo;
using UnityEngine;

namespace TeamB_TD
{
    namespace Stage
    {
        namespace Demo
        {
            public class SamplePlayer : MonoBehaviour, IPlayer
            {
                [SerializeField]
                private SampleResourceManager _resourceManager;
                [SerializeField]
                private StageController _stageController;

                private int _xIndex = 99999;
                private int _yIndex = 99999;
                private IStageCell[,] _cells;

                public IResourceManager ResourceManager => _resourceManager;
                public IFocusable CurrentFocusItem
                {
                    get
                    {
                        if (IsInIndex(_cells, _yIndex, _xIndex))
                        {
                            return _cells[_yIndex, _xIndex];
                        }
                        return null;
                    }
                }

                private void Start()
                {
                    _cells = _stageController.Stage.StageCells;
                }

                private void Update()
                {
                    var oldYIndex = _yIndex;
                    var oldXIndex = _xIndex;

                    if (Input.GetKeyDown(KeyCode.UpArrow)) _yIndex--;
                    if (Input.GetKeyDown(KeyCode.DownArrow)) _yIndex++;
                    if (Input.GetKeyDown(KeyCode.LeftArrow)) _xIndex--;
                    if (Input.GetKeyDown(KeyCode.RightArrow)) _xIndex++;

                    if (_yIndex >= _cells.GetLength(0)) _yIndex = 0;
                    if (_yIndex < 0) _yIndex = _cells.GetLength(0) - 1;
                    if (_xIndex >= _cells.GetLength(1)) _xIndex = 0;
                    if (_xIndex < 0) _xIndex = _cells.GetLength(1) - 1;

                    if (oldYIndex != _yIndex || oldXIndex != _xIndex)
                    {
                        if (IsInIndex(_cells, oldYIndex, oldXIndex))
                        {
                            _cells[oldYIndex, oldXIndex].Unfocus();
                        }

                        if (IsInIndex(_cells, _yIndex, _xIndex))
                        {
                            _cells[_yIndex, _xIndex].Focus();
                        }
                    }
                }

                bool IsInIndex(Array array, int yIndex, int xIndex)
                {
                    return
                        yIndex < _cells.GetLength(0) && yIndex >= 0 &&
                        xIndex < _cells.GetLength(1) && xIndex >= 0;
                }
            }
        }
    }
}