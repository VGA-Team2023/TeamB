using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Resouce
    {
        namespace UI
        {
            public class ResourceTextApplyer : MonoBehaviour
            {
                [SerializeField] private Text _resourceText;

                public void ApplyCurrentResource(int value)
                {
                    _resourceText.text = value.ToString();
                }
            }
        }
    }
}