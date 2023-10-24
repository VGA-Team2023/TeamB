// 日本語対応
using TeamB_TD.Resouce;
using UnityEngine;
using System;

namespace TeamB_TD
{
    namespace Place
    {
        namespace Demo
        {
            [Serializable]
            public class SampleResourceManager : IResourceManager
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