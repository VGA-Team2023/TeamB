// 日本語対応
using System;
using TeamB_TD.Player;
using TeamB_TD.Resouce;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace Place
        {
            namespace Demo
            {
                public class SamplePlayer : MonoBehaviour, IPlayer
                {
                    [SerializeField]
                    private SampleResourceManager _resourceManager;
                    [SerializeField]
                    private SampleStageCell[] _cells;

                    private int _focusIndex = 99999;
                    private IFocusable _currentFocus = null;

                    public IResourceManager ResourceManager => _resourceManager;
                    public IFocusable CurrentFocusItem => _currentFocus;

                    private void Update()
                    {
                        SelectionUpdate();
                    }

                    private void SelectionUpdate()
                    {
                        if (_cells == null || _cells.Length == 0) return;

                        int oldIndex = _focusIndex;

                        if (Input.GetKeyDown(KeyCode.RightArrow)) _focusIndex++;
                        if (Input.GetKeyDown(KeyCode.LeftArrow)) _focusIndex--;

                        if (_focusIndex >= _cells.Length) _focusIndex = 0;
                        else if (_focusIndex < 0) _focusIndex = _cells.Length - 1;

                        if (oldIndex != _focusIndex)
                        {
                            if (IsInIndex(_cells, oldIndex)) _cells[oldIndex].Unfocus();
                            if (IsInIndex(_cells, _focusIndex))
                            {
                                _cells[_focusIndex].Focus();
                                _currentFocus = _cells[_focusIndex];
                            }
                            else
                            {
                                _currentFocus = null;
                            }
                        }

                        bool IsInIndex(Array array, int index)
                        {
                            return index < array.Length && index >= 0;
                        }
                    }
                }
            }
        }
    }
}