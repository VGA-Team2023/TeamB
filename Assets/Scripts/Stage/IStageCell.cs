//日本語対応
using TeamB_TD.Player;

namespace TeamB_TD
{
    namespace Stage
    {
        public interface IStageCell : IFocusable
        {
            CellStatus Status { get; }
        }
    }
}
