// 日本語対応
using System;
using UnityEngine;
using TeamB_TD.Player;
using TeamB_TD.Resouce;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace Place
        {
            [Serializable]
            public class PlaceData
            {
                [SerializeField]
                private PlaceableObject _placeObjectPrefab;
                [SerializeField]
                private string _name;
                [SerializeField]
                private int _cost;

                private IPlayer _player;
                private IResourceManager ResourceManager => _player.ResourceManager;
                private IFocusable FocusItem => _player.CurrentFocusItem;

                public PlaceableObject Prefab => _placeObjectPrefab;
                public string Name => _name;
                public int Cost => _cost;

                public void Initialize(IPlayer player)
                {
                    _player = player;
                }

                public void Place()
                {
                    // コストに対してリソースが足りるかどうかチェックする。
                    // 足りなかったら何もしない。
                    if (!(ResourceManager.CurrentResource > _cost)) return;

                    // フォーカスされているオブジェクトがオブジェクト配置可能インターフェースでなければリターン。
                    // フォーカスされているIObjectPlaceableにオブジェクトが配置済みであればリターン。
                    var stageCell = FocusItem as IObjectPlaceable;
                    if (stageCell == null || stageCell.PlacedObject != null) return;

                    // 足りたらセルに配置してリソースを減らす。
                    ResourceManager.UseResource(_cost);
                    stageCell.OnPlace(_placeObjectPrefab);
                }
            }
        }
    }
}