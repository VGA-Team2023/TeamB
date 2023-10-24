// 日本語対応
using TeamB_TD.ResourceManagement;

namespace TeamB_TD
{
    namespace Player
    {
        public interface IPlayer
        {
            public IResourceManager ResourceManager { get; }
            public IFocusable CurrentFocusItem { get; }
        }
    }
}