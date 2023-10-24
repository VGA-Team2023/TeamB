using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace UI
    {
        public class UIView : MonoBehaviour
        {
            [SerializeField] private Text _resourceText;

            public void SetCurrentResource(int value)
            {
                _resourceText.text = value.ToString();
            }
        }
    }
}


