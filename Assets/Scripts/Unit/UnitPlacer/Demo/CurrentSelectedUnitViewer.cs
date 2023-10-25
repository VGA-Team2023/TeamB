// 日本語対応
using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace PlaceDemo
        {
            public class CurrentSelectedUnitViewer : MonoBehaviour
            {
                [SerializeField]
                private UnitPlaceManager _manager;
                [SerializeField]
                private Text _text;

                private void Update()
                {
                    if (_manager.PlaceUnitSelector.Current != null)
                        _text.text = "Current selected unit is " + _manager.PlaceUnitSelector.Current.UnitPrefab.Name;
                    else
                        _text.text = "Current selected unit is None";
                }
            }
        }
    }
}