// 日本語対応

namespace TeamB_TD
{
    namespace Resouce
    {
        public interface IResourceManager
        {
            int CurrentResource { get; }
            void UseResource(int value);
        }
    }
}