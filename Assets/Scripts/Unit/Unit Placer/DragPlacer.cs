// 日本語対応
using System;
using System.Collections.Generic;
using TeamB_TD.StageManagement;
using TeamB_TD.UIControl;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

namespace TeamB_TD
{
    namespace Unit
    {
        public class DragPlacer : MonoBehaviour
        {
            [SerializeField]
            private DragHandler _dragHandler;
            [SerializeField]
            private UnitPlaceManager _placeManager;

            private UnitBehaviour _dragItem; // ドラッグ中のオブジェクト

            private void OnEnable()
            {
                _dragHandler.OnButtonPressedAll += OnButtonPressedAll;
                _dragHandler.OnButtonReleased += OnButtonReleased;
            }

            private void OnDisable()
            {
                _dragHandler.OnButtonPressedAll -= OnButtonPressedAll;
                _dragHandler.OnButtonReleased -= OnButtonReleased;
            }

            private void OnButtonPressedAll(List<RaycastResult> pressedObject)
            {
                // ドラッグビュー用のオブジェクトを生成。
                PlaceUnitSelectorView placeItemView = null;
                foreach (var ui in pressedObject)
                {
                    placeItemView = ui.gameObject.GetComponent<PlaceUnitSelectorView>();
                    if (placeItemView) break;
                }
                if (placeItemView)
                {
                    _dragItem = GameObject.Instantiate(placeItemView.UnitPrefab);
                    _dragItem.GetComponent<Collider>().enabled = false;
                    _placeManager.PlaceUnitSelector.OnSelectionChanged(placeItemView);
                }
            }

            private void OnButtonReleased(GameObject releasedObject)
            {
                // ドラッグビュー用のオブジェクトを破棄。
                if (releasedObject)
                {
                    var cellView = releasedObject.GetComponent<IStageCellView>();
                    if (cellView != null)
                    {
                        _placeManager.Place(_dragItem, cellView.StageCell);
                    }
                }
                if (_dragItem)
                {
                    GameObject.Destroy(_dragItem.gameObject);
                }
            }

            private void Update()
            {
                if (_dragItem)
                {
                    var distance = 9f;
                    var mousePos = Input.mousePosition;
                    mousePos.z = distance;
                    Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

                    _dragItem.transform.position = worldPos;
                }
            }
        }
    }
}