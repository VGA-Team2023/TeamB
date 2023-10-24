//日本語対応
using System;

namespace TeamB_TD
{
    namespace Stage
    {
        public class StageBlueprint // ステージの設計図
        {
            private int[][,] _stageBlueprints =
            {
                new int[,]{ // Stage0
                {0, 0, 0, 0, 0, 0},
                {0, 1, 2, 2, 2, 0},
                {0, 1, 1, 1, 1, 0},
                {0, 2, 2, 1, 0, 0},
                {0, 2, 2, 1, 0, 0},
                {0, 0, 0, 0, 0, 0},
                },
                new int[,]{ // Stage1
                {2, 1, 1, 1, 1, 1},
                {1, 0, 0, 0, 0, 1},
                {1, 1, 1, 1, 1, 1},
                {1, 0, 0, 1, 0, 1},
                {1, 0, 0, 1, 0, 1},
                {1, 1, 1, 1, 1, 3},
                },
            };

            public int[,] SampleStageData0 => _stageBlueprints[0];
            public int[,] SampleStageData1 => _stageBlueprints[1];

            public int[,] GetStageData(int stageNumber)
            {
                if (stageNumber < 0 && stageNumber >= _stageBlueprints.Length)
                    throw new ArgumentOutOfRangeException(nameof(stageNumber));

                return _stageBlueprints[stageNumber];
            }
        }
    }
}