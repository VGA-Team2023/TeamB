//日本語対応
using TeamB_TD.Player;
using TeamB_TD.Unit;

namespace TeamB_TD
{
    namespace StageManagement
    {
        public interface IStageCell : IUnitPlaceable, IFocusable
        {
            int YPos { get; }
            int XPos { get; }
            CellStatus Status { get; }
            void AttachView(IStageCellView stageCellView);

            IStageCell Parent { get; set; }
        }
    }
}
