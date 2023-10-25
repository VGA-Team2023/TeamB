// 日本語対応
using TeamB_TD.Unit.PlaceDemo;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace PlaceDemo
        {
            public class Initializer : MonoBehaviour
            {
                [SerializeField]
                private Stage.Demo.SamplePlayer _player;
                [SerializeField]
                private UnitPlaceManager _placeManager;

                private void Awake()
                {
                    _placeManager.Initialize(_player);
                }
            }
        }
    }
}