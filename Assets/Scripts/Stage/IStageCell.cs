//日本語対応

using TeamB_TD.Player;

namespace TeamB_TD
{
    namespace StageManagement
    {
        public interface IStageCell : IFocusable
        {
            CellStatus Status { get; }
        }
    }
}
