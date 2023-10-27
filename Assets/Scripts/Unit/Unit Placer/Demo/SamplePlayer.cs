// 日本語対応
using System;
using TeamB_TD.Player;
using TeamB_TD.ResourceManagement;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace PlaceDemo
        {
            public class SamplePlayer : MonoBehaviour, IPlayer
            {
                [SerializeField]
                private SampleResourceManager _resourceManager;
                [SerializeField]
                private SampleStageCell[] _cells;

                public IResourceManager ResourceManager => _resourceManager;
                public IFocusable CurrentFocusItem
                {
                    get
                    {
                        if (IsInIndex(_cells, _index))
                        {
                            return _cells[_index];
                        }
                        return null;
                    }
                }

                private int _index = 99999;

                private void Update()
                {
                    var oldIndex = _index;
                    if (Input.GetKeyDown(KeyCode.LeftArrow)) _index--;
                    if (Input.GetKeyDown(KeyCode.RightArrow)) _index++;

                    if (_index >= _cells.Length) _index = 0;
                    if (_index < 0) _index = _cells.Length - 1;

                    if (oldIndex != _index)
                    {
                        if (IsInIndex(_cells, oldIndex))
                        {
                            _cells[oldIndex].Unfocus();
                        }

                        if (IsInIndex(_cells, _index))
                        {
                            _cells[_index].Focus();
                        }
                    }
                }
                bool IsInIndex(Array array, int index)
                {
                    return index < _cells.Length && index >= 0;
                }
            }
        }
    }
}