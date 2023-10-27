// 日本語対応
using TeamB_TD.ResourceManagement;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace PlaceDemo
        {
            public class SampleResourceManager : MonoBehaviour, IResourceManager
            {
                [SerializeField]
                private int _currentResource;

                public int CurrentResource => _currentResource;

                public void UseResource(int value)
                {
                    _currentResource -= value;
                }
            }
        }
    }
}