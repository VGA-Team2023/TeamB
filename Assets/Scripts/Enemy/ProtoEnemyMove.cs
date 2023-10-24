using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//日本語対応
namespace TeamB_TD
{
    namespace Enemy
    {
        public class ProtoEnemyMove : MonoBehaviour
        {
            public int[,] StageMap = null;

            private EnemyStatus _status = new EnemyStatus();

            private void Start()
            {
                if (!TryGetComponent(out ProtoEnemyController controller)) return;

                //StartCoroutine(MoveAlongRoute());

            }

            /// <summary></summary>
            private IEnumerator MoveAlongRoute<T>(List<T> route) where T : MonoBehaviour
            {
                foreach (var path in route)
                {
                    Vector3 dest = path.transform.position;
                    dest.y = transform.position.y;
                    yield return ToNextDestination(dest);
                }
            }

            /// <summary>次の目的地に向かって移動するコルーチン</summary>
            /// <param name="dest">目的地</param>
            private IEnumerator ToNextDestination(Vector3 dest)
            {
                Vector3 moveVec = dest - transform.position;

                while (moveVec.magnitude > 0.1f)
                {
                    transform.position += moveVec.normalized * _status.MoveSpeed;
                    moveVec = dest - transform.position;
                    yield return null;
                }
            }
        }
    }
}