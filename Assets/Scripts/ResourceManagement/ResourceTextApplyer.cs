// 日本語対応
using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace ResourceManagement
    {
        namespace UI
        {
            public class ResourceTextApplyer : MonoBehaviour
            {
                [SerializeField]
                private Text _text;
                [SerializeField]
                private ResourceManager _resourceManager;

                private void Update()
                {
                    _text.text = "Current Resource: " + _resourceManager.CurrentResource;
                }
            }
        }
    }
}