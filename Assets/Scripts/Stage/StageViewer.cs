// 日本語対応
using System.Collections.Generic;
using TeamB_TD.StageManagement.Demo;
using UnityEngine;

namespace TeamB_TD
{
    namespace StageManagement
    {
        public class StageViewer
        {
            public void CreateView(StageController stageController, SamplePlayer player, Stage stage, StageCellView prefab, IStageCell towerCell)
            {
                if (towerCell == null) throw new System.ArgumentException("タワーが一つもありません。");

                for (int y = 0; y < stage.StageCells.GetLength(0); y++)
                {
                    for (int x = 0; x < stage.StageCells.GetLength(1); x++)
                    {
                        var instance = GameObject.Instantiate(prefab, new Vector3(x, 0f, -y), Quaternion.identity);

                        instance.gameObject.name = $"Stage Cell: {y}, {x}";
                        instance.Initialize(stageController, player, stage.StageCells[y, x], towerCell);
                        stage.StageCells[y, x].AttachView(instance);
                    }
                }
            }
        }
    }
}