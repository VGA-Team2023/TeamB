// 日本語対応
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Unit
    {
        public class PlaceUnitSelectorView : MonoBehaviour, IPointerClickHandler
        {
            [SerializeField]
            private Text _name;
            [SerializeField]
            private Text _cost;

            private UnitBehaviour _unitPrefab;
            private PlaceUnitSelector _selector;

            public UnitBehaviour UnitPrefab => _unitPrefab;

            public void Initialize(PlaceUnitSelector selector, UnitBehaviour unitPrefab)
            {
                _name.text = "Name: " + unitPrefab.Name;
                _cost.text = "Cost: " + unitPrefab.Cost.ToString();
                _selector = selector;
                _unitPrefab = unitPrefab;
            }

            public void OnPointerClick(PointerEventData eventData)
            {
                _selector.OnSelectionChanged(this);
                OnSelected();
            }

            public void OnSelected()
            {
                // 選択時の処理をここに記述してください。
                Debug.Log("selected");
            }

            public void OnDeselected()
            {
                // 選択解除時の処理をここに記述してください。
                Debug.Log("deselected");
            }
        }
    }
}