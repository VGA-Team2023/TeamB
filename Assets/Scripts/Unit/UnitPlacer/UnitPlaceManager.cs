// 日本語対応
using TeamB_TD.Player;
using TeamB_TD.StageManagement;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        public class UnitPlaceManager : MonoBehaviour
        {
            [SerializeField]
            private PlaceUnitContainer _placeUnitContainer;
            [SerializeField]
            private PlaceUnitSelector _placeUnitSelector;

            private IPlayer _player;

            public PlaceUnitContainer PlaceUnitContainer => _placeUnitContainer;
            public PlaceUnitSelector PlaceUnitSelector => _placeUnitSelector;

            private void Start()
            {
                foreach (var unitPrefab in _placeUnitContainer.UnitPrefabs)
                {
                    _placeUnitSelector.CreateView(unitPrefab);
                }
            }

            public void Initialize(IPlayer player)
            {
                _player = player;
            }

            public void Create()
            {
                var prefab = _placeUnitSelector.Current.UnitPrefab;

                var cell = _player.CurrentFocusItem as IStageCell;
                if (cell == null)
                {
                    Debug.Log("フォーカス中のオブジェクトは配置可能オブジェクトではありません。");
                    return;
                }

                if (cell.Status.HasFlag(CellStatus.Placeable))
                {
                    Debug.Log("フォーカス中のセルにはユニットを配置できません。");
                    return;
                }

                if (_player.ResourceManager.CurrentResource < prefab.Cost)
                {
                    Debug.Log("リソースが足りません。");
                    return;
                }

                if (cell.PlacedObject)
                {
                    Debug.Log("そのセルには既にオブジェクトが配置されいます。");
                    return;
                }

                // 必要なら引数を増やす。（座標の調整や親オブジェクトの設定など）
                var instance = GameObject.Instantiate(prefab, cell.GameObject.transform.position + Vector3.up, Quaternion.identity, cell.GameObject.transform);
                instance.Initialze(cell);
                cell.Place(instance);
                _player.ResourceManager.UseResource(prefab.Cost);
            }
        }
    }
}