//日本語対応
namespace TeamB_TD
{
    namespace Stage
    {
        public class StageBlueprint
        {
            public int[,] Map => _map;

            private int[,] _map =
            {
            {2, 1, 1, 1, 1, 1},
            {1, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1},
            {1, 0, 0, 1, 0, 1},
            {1, 0, 0, 1, 0, 1},
            {1, 1, 1, 1, 1, 3},
            };
        }
    }
}