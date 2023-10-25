// 日本語対応

using System;
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
            event Action OnFocused;
            event Action OnUnfocused;
        }
    }
}