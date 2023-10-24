// 日本語対応
using TeamB_TD.Resouce;

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