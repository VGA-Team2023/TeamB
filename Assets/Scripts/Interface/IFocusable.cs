// 日本語対応

using UnityEngine;

namespace TeamB_TD
{
    namespace Player
    {
        public interface IFocusable
        {
            GameObject GameObject { get; }
            public void Focus();
            public void Unfocus();
        }
    }
}