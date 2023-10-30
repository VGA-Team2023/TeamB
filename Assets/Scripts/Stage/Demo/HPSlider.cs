// 日本語対応
using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace Unit
    {
        public class HPSlider : MonoBehaviour
        {
            [SerializeField]
            private Slider _slider;

            private EnemyController _enemyController;
            private Ally.AllyMain _allyMain;

            private void Start()
            {
                _enemyController = GetComponent<EnemyController>();
                _allyMain = GetComponent<Ally.AllyMain>();


                if (_enemyController != null)
                {
                    _slider.maxValue = _enemyController.EnemyStatus.MaxLife;
                }
                else if (_allyMain != null)
                {
                    _slider.maxValue = _allyMain.AllyStatus.MaxLife;
                }
                else
                {
                    throw new System.ArgumentException("ステータスを表現するオブジェクトがありません！");
                }
            }

            private void Update()
            {
                if (_enemyController != null)
                {
                    _slider.value = _enemyController.EnemyStatus.CurrentLife;
                }
                else if (_allyMain != null)
                {
                    _slider.value = _allyMain.AllyStatus.CurrentLife;
                }
                else
                {
                    throw new System.ArgumentException("ステータスを表現するオブジェクトがありません！");
                }
            }
        }
    }
}