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
            private PlaceUnitSelector _placeUnitSelector; // どのユニットを配置するか制御するクラス。
            [SerializeField]
            private Vector3 _createOffset = new Vector3(0f, 0f, -1f);

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

            public void Place()
            {
                if (!_placeUnitSelector.Current)
                {
                    Debug.Log("配置するユニットが選択されていません");
                    return;
                }

                var prefab = _placeUnitSelector.Current.UnitPrefab;

                var cell = _player.CurrentFocusItem as IStageCell;
                if (cell == null)
                {
                    Debug.Log("フォーカス中のオブジェクトは配置可能オブジェクトではありません。");
                    return;
                }

                if (!cell.Status.HasFlag(CellStatus.Placeable))
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
                var instance = GameObject.Instantiate(prefab, cell.GameObject.transform.position + _createOffset, Quaternion.identity, cell.GameObject.transform);
                instance.Initialze(cell);
                cell.Place(instance);
                _player.ResourceManager.UseResource(prefab.Cost);
            }

            public void Place(UnitBehaviour prefab, IStageCell cell)
            {
                if (!cell.Status.HasFlag(CellStatus.Placeable))
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
                var instance = GameObject.Instantiate(prefab, cell.GameObject.transform.position + _createOffset, Quaternion.identity, cell.GameObject.transform);
                instance.Initialze(cell);
                instance.GetComponent<Collider>().enabled = true;
                cell.Place(instance);
                _player.ResourceManager.UseResource(prefab.Cost);
            }
        }
    }
}