// 日本語対応
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;

namespace TeamB_TD
{
    namespace UIControl
    {
        [Serializable]
        public class DragHandler : MonoBehaviour
        {
            public event Action<GameObject> OnButtonPressed;
            public event Action<List<RaycastResult>> OnButtonPressedAll;
            public event Action<GameObject> OnButtonReleased;

            [SerializeField]
            private LayerMask _layerMask;

            void Update()
            {
                if (Input.GetMouseButtonDown(0))
                {
                    var mouseOverlappingUIs = GetMouseOverlappingUI();
                    if (mouseOverlappingUIs.Count > 0)
                    {
                        // 一番手前のUIだけ取得する。
                        OnButtonPressedAll?.Invoke(mouseOverlappingUIs);
                        OnButtonPressed?.Invoke(mouseOverlappingUIs[0].gameObject);
                    }
                    else if (GetMouseOverlappingCollider(out RaycastHit mouseOverlappingCollider))
                    {
                        OnButtonPressed?.Invoke(mouseOverlappingCollider.collider.gameObject);
                    }
                    else
                    {
                        OnButtonPressed?.Invoke(null);
                    }
                }
                if (Input.GetMouseButtonUp(0))
                {
                    var mouseOverlappingUIs = GetMouseOverlappingUI();
                    if (mouseOverlappingUIs.Count > 0)
                    {
                        // 一番手前のUIだけ取得する。
                        OnButtonReleased?.Invoke(mouseOverlappingUIs[0].gameObject);
                    }
                    else if (GetMouseOverlappingCollider(out RaycastHit mouseOverlappingCollider))
                    {
                        OnButtonReleased?.Invoke(mouseOverlappingCollider.collider.gameObject);
                    }
                    else
                    {
                        OnButtonReleased?.Invoke(null);
                    }
                }
            }

            private List<RaycastResult> _results = new List<RaycastResult>();

            private List<RaycastResult> GetMouseOverlappingUI()
            {
                PointerEventData eventData = new PointerEventData(EventSystem.current);
                Vector2 mousePosition = Input.mousePosition;
                eventData.position = mousePosition;

                EventSystem.current.RaycastAll(eventData, _results);
                return _results;
            }

            private bool GetMouseOverlappingCollider(out RaycastHit hit)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                return Physics.Raycast(ray, out hit, Mathf.Infinity, _layerMask);
            }
        }
    }
}