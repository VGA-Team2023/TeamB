// 日本語対応
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

            IStageCell _stageCell = null;
            public GameObject GameObject => this.gameObject;

            public void Initialze(IStageCell stageCell)
            {
                _stageCell = stageCell;

                Color color;
                if (stageCell.Status.HasFlag(CellStatus.Moveable | CellStatus.Placeable))
                    color = _cellStatus3;
                else if (stageCell.Status.HasFlag(CellStatus.Moveable))
                    color = _cellStatus2;
                else if (stageCell.Status.HasFlag(CellStatus.Placeable))
                    color = _cellStatus1;
                else
                    color = _cellStatus0;

                if (_image) _image.color = color;
                if (_spriteRenderer) _spriteRenderer.color = color;
                if (_meshRenderer) _meshRenderer.material.color = color;
            }

            private void OnMouseEnter()
            {
                _stageCell.Focus();
            }

            private void OnMouseExit()
            {
                _stageCell.Unfocus();
            }
        }

        public interface IStageCellView
        {
            GameObject GameObject { get; }
        }
    }
}