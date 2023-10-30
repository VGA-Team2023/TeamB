// 日本語対応
using System;
using TeamB_TD.Player;
using TeamB_TD.ResourceManagement;
using UnityEngine;

namespace TeamB_TD
{
    namespace StageManagement
    {
        namespace Demo
        {
            public class SamplePlayer : MonoBehaviour, IPlayer
            {
                [SerializeField]
                private ResourceManager _resourceManager;
                [SerializeField]
                private StageController _stageController;

                private IFocusable _currentFocusedStageCell;
                public IResourceManager ResourceManager => _resourceManager;
                public IFocusable CurrentFocusItem => _currentFocusedStageCell;

                public void ChangeFocusedStageCell(IFocusable cell)
                {
                    _currentFocusedStageCell = cell;
                }
            }
        }
    }
}