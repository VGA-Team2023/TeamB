// 日本語対応
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
                private SamplePlayer _player;
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