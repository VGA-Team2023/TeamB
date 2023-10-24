// 日本語対応
using TeamB_TD.Stage;
using TeamB_TD.Stage.Place;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace Demo
        {
            public class SampleStageCell : MonoBehaviour, IObjectPlaceable
            {
                [SerializeField]
                private Color _nomalColor = Color.white;
                [SerializeField]
                private Color _focusedColor = Color.red;

                private MeshRenderer _meshRenderer;
                private PlaceableObject _placedObject = null;

                public PlaceableObject PlacedObject => _placedObject;
                public bool IsPlaced => _placedObject != null;

                private void Start()
                {
                    _meshRenderer = GetComponent<MeshRenderer>();
                }

                public void Place(PlaceableObject prefab)
                {
                    var placedObject = Instantiate(prefab, this.transform.position + Vector3.up, Quaternion.identity, this.transform);
                    _placedObject = placedObject;
                }

                public void Focus()
                {
                    _meshRenderer.material.color = _focusedColor;
                }

                public void Unfocus()
                {
                    _meshRenderer.material.color = _nomalColor;
                }
            }
        }
    }
}
