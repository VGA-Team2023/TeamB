// 日本語対応
using System;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        [Serializable]
        public class PlaceUnitSelector
        {
            [SerializeField]
            private PlaceUnitSelectorView _viewPrefab;
            [SerializeField]
            private Transform _viewParent;

            private PlaceUnitSelectorView _current;
            public PlaceUnitSelectorView Current => _current;

            public void CreateView(UnitBehaviour unitPrefab)
            {
                var view = GameObject.Instantiate(_viewPrefab, _viewParent);
                view.Initialize(this, unitPrefab);
            }

            public void OnSelectionChanged(PlaceUnitSelectorView view)
            {
                _current?.OnDeselected();
                _current = view;
            }
        }
    }
}