// 日本語対応

using UnityEngine;

namespace TeamB_TD
{
    namespace StageManagement
    {
        public class StageController : MonoBehaviour
        {
            [SerializeField]
            private StageCellView _viewPrefab;

            private StageBlueprint _stageBlueprint = new StageBlueprint();
            private Stage _stage = new Stage();
            private StageViewer _stageViewer = new StageViewer();

            public void CreateStage(int stageNumber)
            {
                var stageData = _stageBlueprint.GetStageData(stageNumber);
                _stage.CreateStage(stageData);
                _stageViewer.CreateView(_stage, _viewPrefab);
            }

            private void Start()
            {
                CreateStage(0);
            }
        }
    }
}