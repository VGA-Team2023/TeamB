// 日本語対応
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace PlaceDemo
        {
            public class SampleUnit : UnitBehaviour
            {
                [SerializeField]
                private string _name;
                [SerializeField]
                private int _cost;

                public override string Name => _name;
                public override int Cost => _cost;
            }
        }
    }
}