// 日本語対応
using System;
using UnityEngine;

// インスペクタからプレハブを割り当てることを想定して作成されたクラス。
namespace TeamB_TD
{
    namespace Unit
    {
        [Serializable]
        public class PlaceUnitContainer
        {
            [SerializeField]
            private UnitBehaviour[] _unitPrefabs;

            public UnitBehaviour[] UnitPrefabs => _unitPrefabs;
        }
    }
}