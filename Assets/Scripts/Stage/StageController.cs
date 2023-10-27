// 日本語対応

using TeamB_TD.StageManagement.Demo;
using UnityEngine;

namespace TeamB_TD
{
    namespace StageManagement
    {
        public class StageController : MonoBehaviour
        {
            [SerializeField]
            private StageCellView _viewPrefab;
            [SerializeField]
            private SamplePlayer _samplePlayer;

            private StageBlueprint _stageBlueprint = new StageBlueprint();
            private Stage _stage = new Stage();
            private StageViewer _stageViewer = new StageViewer();

            public Stage Stage => _stage;

            private void Awake()
            {
                CreateStage(0);
            }

            public void CreateStage(int stageNumber)
            {
                var stageData = _stageBlueprint.GetStageData(stageNumber);
                _stage.CreateStage(stageData);
                _stageViewer.CreateView(_samplePlayer, _stage, _viewPrefab);
            }
        }
    }
}