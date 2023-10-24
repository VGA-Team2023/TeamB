// 日本語対応
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace Place
        {
            namespace Demo
            {
                public class SamplePlaceObjectViewController : MonoBehaviour
                {
                    [SerializeField]
                    private PlaceData[] _placeDataCollection;
                    [SerializeField]
                    private Transform _viewParent;
                    [SerializeField]
                    private PlaceDataView _viewPrefab;

                    [SerializeField]
                    private SamplePlayer _samplePlayer; // テスト用プレイヤー

                    private void Start()
                    {
                        foreach (PlaceData data in _placeDataCollection)
                        {
                            data.Initialize(_samplePlayer);
                            CreateView(data);
                        }
                    }

                    private void CreateView(PlaceData data)
                    {
                        var instance = Instantiate(_viewPrefab, _viewParent);
                        instance.Initialize(data);
                    }
                }
            }
        }
    }
}