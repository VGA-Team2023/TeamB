using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//日本語対応
namespace TeamB_TD
{
    namespace Enemy
    {
        public class EnemyMove : MonoBehaviour
        {
            private EnemyStatus _status = new();

            private void Start()
            {
                if (TryGetComponent(out EnemyController controller)) _status = controller.EnemyStatus;
                else Debug.Log("ProtoEnemyController is not found"); // 参照の取得が確認出来たら削除する
            }

            /// <summary>ステージのグリッドに沿って移動するコルーチン</summary>
            /// <param name="route">移動経路</param>
            public IEnumerator MoveAlongRoute(List<Vector3> route)
            {
                foreach (var path in route)
                {
                    yield return ToNextDestination(path); // 目的地に到着するまで待機する
                }
            }

            /// <summary>次の目的地に向かって移動するコルーチン</summary>
            /// <param name="dest">目的地</param>
            private IEnumerator ToNextDestination(Vector3 dest)
            {
                Vector3 moveVec = dest - transform.position;

                while (moveVec.magnitude > 0.1f)
                {
                    transform.position = moveVec.normalized * _status.MoveSpeed * Time.deltaTime;
                    moveVec = dest - transform.position;
                    yield return null;
                }
            }
        }
    }
}