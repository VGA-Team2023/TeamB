// 日本語対応
using UnityEngine;
using TeamB_TD.StageManagement;

namespace TeamB_TD
{
    namespace Unit
    {
        /// <summary>
        /// ステージに配置可能なオブジェクトを表現する。
        /// </summary>
        public class UnitBehaviour : MonoBehaviour
        {
            // 配置可能オブジェクト共通基底クラス。
            private int _yPos;
            private int _xPos;
            private Stage _stage;

            public int YPos => _yPos;
            public int XPos => _xPos;
            public Stage Stage => _stage;

            public void Initialze(Stage stage, int yPos, int xPos)
            {
                _stage = stage; _yPos = yPos; _xPos = xPos;
            }
        }
    }
}