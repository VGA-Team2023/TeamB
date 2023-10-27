// 日本語対応
using TeamB_TD.StageManagement.Demo;
using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace StageManagement
    {
        public class StageCellView : MonoBehaviour, IStageCellView
        {
            [SerializeField]
            private MeshRenderer _meshRenderer;
            [SerializeField]
            private SpriteRenderer _spriteRenderer;
            [SerializeField]
            private Image _image;

            [SerializeField]
            private Color _cellStatus0;
            [SerializeField]
            private Color _cellStatus1;
            [SerializeField]
            private Color _cellStatus2;
            [SerializeField]
            private Color _cellStatus3;

            private IStageCell _stageCell = null;
            private Color _nomalColor;
            private Color _focusedColor = Color.red;

            private SamplePlayer _samplePlayer = null;
            public GameObject GameObject => this.gameObject;

            public IStageCell StageCell => _stageCell;

            public void Initialize(SamplePlayer samplePlayer, IStageCell stageCell)
            {
                _samplePlayer = samplePlayer;
                _stageCell = stageCell;

                Color color;
                if (stageCell.Status.HasFlag(CellStatus.Movable | CellStatus.Placeable))
                    color = _cellStatus3;
                else if (stageCell.Status.HasFlag(CellStatus.Movable))
                    color = _cellStatus2;
                else if (stageCell.Status.HasFlag(CellStatus.Placeable))
                    color = _cellStatus1;
                else
                    color = _cellStatus0;

                _nomalColor = color;
                if (_image) _image.color = color;
                if (_spriteRenderer) _spriteRenderer.color = color;
                if (_meshRenderer) _meshRenderer.material.color = color;

                _stageCell.OnFocused += Focus;
                _stageCell.OnUnfocused += Unfocus;
            }

            private void Focus()
            {
                if (_image) _image.color = _focusedColor;
                if (_spriteRenderer) _spriteRenderer.color = _focusedColor;
                if (_meshRenderer) _meshRenderer.material.color = _focusedColor;
            }

            private void Unfocus()
            {
                if (_image) _image.color = _nomalColor;
                if (_spriteRenderer) _spriteRenderer.color = _nomalColor;
                if (_meshRenderer) _meshRenderer.material.color = _nomalColor;
            }

            private void OnMouseEnter()
            {
                //_stageCell.Focus();
                _samplePlayer.ChangeFocusedStageCell(this.StageCell);
            }

            private void OnMouseExit()
            {
                //_stageCell.Unfocus();
                _samplePlayer.ChangeFocusedStageCell(null);
            }
        }

        public interface IStageCellView
        {
            GameObject GameObject { get; }

            IStageCell StageCell { get; }
        }
    }
}