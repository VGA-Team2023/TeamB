// 日本語対応
using UnityEngine;

namespace TeamB_TD
{
    namespace StageManagement
    {
        public class StageViewer
        {
            public void CreateView(Stage stage, StageCellView prefab)
            {
                for (int y = 0; y < stage.StageCells.GetLength(0); y++)
                {
                    for (int x = 0; x < stage.StageCells.GetLength(1); x++)
                    {
                        var instance = GameObject.Instantiate(prefab, new Vector3(x, 0f, -y), Quaternion.identity);
                        instance.Initialze(stage.StageCells[y, x]);
                        stage.StageCells[y, x].AttachView(instance);
                    }
                }
            }
        }
    }
}