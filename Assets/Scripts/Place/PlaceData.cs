// 日本語対応
using System;
using UnityEngine;
using TeamB_TD.Player;
using TeamB_TD.ResourceManagement;

namespace TeamB_TD
{
    namespace Stage
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
            }
        }
    }
}