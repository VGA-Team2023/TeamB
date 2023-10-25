// 日本語対応
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        /// <summary>
        /// ステージに配置可能なオブジェクトを表現する。
        /// </summary>
        public abstract class UnitBehaviour : MonoBehaviour
        {
            // 配置可能オブジェクト共通基底クラス。
            public abstract string Name { get; }
            public abstract int Cost { get; }

            protected IUnitPlaceable _unitPlaceable; // 自分が配置されている場所。（より良い命名があればリネームしてください。）

            public void Initialze(IUnitPlaceable unitPlaceable)
            {
                _unitPlaceable = unitPlaceable;
            }
        }
    }
}