// 日本語対応
using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Battle
    {
        public class GameStatusText : MonoBehaviour
        {
            [SerializeField]
            private Text _text;

            private void Update()
            {
                if (GameManager.Current)
                {
                    if (GameManager.Current.GameStatus != GameManager.Status.InProgress)
                    {
                        _text.text = GameManager.Current.GameStatus.ToString();
                    }
                    else
                    {
                        _text.text = null;
                    }
                }
            }
        }
    }
}