using System;
using TeamB_TD.Stage.Place;
using UnityEngine;

//日本語対応
namespace TeamB_TD
{
    namespace Stage
    {
        public class ProtoCell : MonoBehaviour, IObjectPlaceable
        {
            [SerializeField]
            private CellState _cellStatus = CellState.None;

            private PlaceableObject _placedObject = null;

            public CellState CellStatus => _cellStatus;
            public Vector3 GenerateMuzzle => new Vector3(0f, transform.position.y + transform.localScale.y / 2, 0f);
            public PlaceableObject PlacedObject => _placedObject;
            public bool IsPlaced => _placedObject != null;

            private void OnMouseEnter()
            {
                Focus();
            }

            private void OnMouseExit()
            {
                Unfocus();
            }

            public bool IsContainsCellState(CellState status)
            {
                return _cellStatus.HasFlag(status);
            }

            public void Focus()
            {
                Debug.Log($"{gameObject.name} is focused");
            }

            public void Unfocus()
            {
                Debug.Log($"{gameObject.name} is unfocused");
            }

            public void Place(PlaceableObject placedObject)
            {
                _placedObject = placedObject;
            }
        }

        [Serializable, Flags]
        public enum CellState : byte
        {
            None = 0,
            Wall = 1,
            Path = 2,
            CanPlace = 4,
            CannotPlace = 8,
        }
    }
}