// 日本語対応
using System;
using TeamB_TD.StageManagement;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace PlaceDemo
        {
            public class SampleStageCell : MonoBehaviour, IStageCell
            {
                [SerializeField]
                private CellStatus _cellStatus;
                [SerializeField]
                private Color _nomalColor = Color.white;
                [SerializeField]
                private Color _focusedColor = Color.red;

                private MeshRenderer _meshRenderer;
                private UnitBehaviour _unit = null;

                public event Action OnFocused;
                public event Action OnUnfocused;

                public CellStatus Status => _cellStatus;
                public bool IsPlaced => _unit;
                public UnitBehaviour PlacedObject => _unit;
                public GameObject GameObject => this.gameObject;

                private void Start()
                {
                    _meshRenderer = GetComponent<MeshRenderer>();
                }

                public void Place(UnitBehaviour placedObject)
                {
                    _unit = placedObject;
                }

                public void Focus()
                {
                    _meshRenderer.material.color = _focusedColor;
                    OnFocused?.Invoke();
                }
                public void Unfocus()
                {
                    _meshRenderer.material.color = _nomalColor;
                    OnUnfocused?.Invoke();
                }


                // 以下は一旦不要。
                public int YPos => throw new System.NotImplementedException();
                public int XPos => throw new System.NotImplementedException();
                public IStageCell Parent { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

                public void AttachView(IStageCellView stageCellView)
                {
                    throw new System.NotImplementedException();
                }
            }
        }
    }
}