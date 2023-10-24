// 日本語対応
using System;
using TeamB_TD.Stage.Place;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Stage
    {
        namespace Place
        {
            [Serializable]
            public class PlaceDataView : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
            {
                [SerializeField]
                private Image _image;
                [SerializeField]
                private Text _name;
                [SerializeField]
                private Text _cost;
                [SerializeField]
                private Color _nomalColor = Color.white;
                [SerializeField]
                private Color _hoverdColor = Color.red;

                private PlaceData _placeData;

                public PlaceData PlaceData => _placeData;

                public void Initialize(PlaceData placeData)
                {
                    _placeData = placeData;
                    _name.text = "Name: " + placeData.Name;
                    _cost.text = "Cost: " + placeData.Cost.ToString();
                }

                public void OnHovered()
                {
                    _image.color = _hoverdColor;
                }

                public void OnDehovered()
                {
                    _image.color = _nomalColor;
                }

                public void OnPointerClick(PointerEventData eventData)
                {
                    // Stageに生成の責任を渡す。
                    // _placeData.Place();
                }

                public void OnPointerEnter(PointerEventData eventData)
                {
                    OnHovered();
                }

                public void OnPointerExit(PointerEventData eventData)
                {
                    OnDehovered();
                }
            }
        }
    }
}