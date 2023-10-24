// 日本語対応

namespace TeamB_TD
{
    namespace ResourceManagement
    {
        public interface IResourceManager
        {
            int CurrentResource { get; }
            void UseResource(int value);
        }
    }
}