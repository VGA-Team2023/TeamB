using UnityEngine;
using TeamB_TD.StageManagement;
using System.Collections.Generic;

namespace TeamB_TD
{
    namespace Enemy
    {
        public class EnemyMoveV2 : MonoBehaviour
        {
            [SerializeField]
            private float _moveSpeed;

            private IStageCell _last; // 最後に通ったセル
            private IStageCell _next; // 現在向かっているセル

            private int _nextIndex = 0;
            private Vector3 _moveVector;

            private IStageCell[,] _stageCells;

            private List<IStageCell> _path = new List<IStageCell>();

            public void Initialize(IStageCell[,] stageCells, int startY, int startX, int goalY, int goalX)
            {
                _stageCells = stageCells;
                InitializePath(startY, startX, goalY, goalX);
                UpdateNext();
            }

            private void UpdateNext() // 進行方向の変更
            {
                _last = _path[_nextIndex];
                _nextIndex++;
                if (_nextIndex < _path.Count)
                {
                    _next = _path[_nextIndex];
                    Vector3 lastPos = _last.GameObject.transform.position;
                    Vector3 nextPos = _next.GameObject.transform.position;
                    _moveVector = (nextPos - lastPos).normalized;
                    _moveVector.y = 0f;
                    //Debug.Log(_last.GameObject.name + ", " + _next.GameObject.name);
                }
                else
                {
                    _next = null;
                    _moveVector = Vector3.zero;
                    var enemyController = GetComponent<EnemyController>();
                    enemyController.EnemyStatus.IsArrivedTower = true;
                    Battle.GameManager.Current.AddCompletedEnemyCount(enemyController.EnemyStatus);
                    GameObject.Destroy(this.gameObject);
                }
            }

            private void Update()
            {
                transform.Translate(_moveVector * Time.deltaTime * _moveSpeed);

                if (UpdateNextTrigger())
                {
                    UpdateNext();
                }
            }

            private bool UpdateNextTrigger() // 進行方向の変更が必要かどうか
            {
                if (_next == null) return false;
                var targetPos = _next.GameObject.transform.position;

                if (Mathf.Abs(_moveVector.x) < 0.01f && _moveVector.z > 0.01f && transform.position.z >= targetPos.z) return true;
                else if (Mathf.Abs(_moveVector.x) < 0.01f && _moveVector.z < 0.01f && transform.position.z <= targetPos.z) return true;
                else if (Mathf.Abs(_moveVector.z) < 0.01f && _moveVector.x > 0.01f && transform.position.x >= targetPos.x) return true;
                else if (Mathf.Abs(_moveVector.z) < 0.01f && _moveVector.x < 0.01f && transform.position.x <= targetPos.x) return true;

                return false;
            }

            private void InitializePath(int startY, int startX, int goalY, int goalX)
            {
                // ダイクストラ法でスタートから各セルへのコストを計算
                int[,] cost = new int[_stageCells.GetLength(0), _stageCells.GetLength(1)];
                for (int y = 0; y < _stageCells.GetLength(0); y++)
                {
                    for (int x = 0; x < _stageCells.GetLength(1); x++)
                    {
                        cost[y, x] = int.MaxValue;
                    }
                }

                cost[startY, startX] = 0;
                List<IStageCell> openSet = new List<IStageCell>();

                IStageCell startCell = _stageCells[startY, startX];
                openSet.Add(startCell);

                while (openSet.Count > 0)
                {
                    IStageCell currentCell = openSet[0];
                    openSet.RemoveAt(0);

                    if (currentCell.YPos == goalY && currentCell.XPos == goalX)
                    {
                        // ゴールに到達
                        // 経路を構築
                        BuildPath(startCell, currentCell);
                        return;
                    }

                    foreach (var neighbor in GetNeighbors(currentCell))
                    {
                        int newCost = cost[currentCell.YPos, currentCell.XPos] + 1;

                        if (newCost < cost[neighbor.YPos, neighbor.XPos])
                        {
                            cost[neighbor.YPos, neighbor.XPos] = newCost;
                            neighbor.Parent = currentCell;

                            // コストを計算してオープンセットに追加
                            int f = newCost + Heuristic(neighbor, goalY, goalX);
                            int index = 0;
                            while (index < openSet.Count && f >= Heuristic(openSet[index], goalY, goalX))
                            {
                                index++;
                            }
                            openSet.Insert(index, neighbor);
                        }
                    }
                }
            }

            private List<IStageCell> GetNeighbors(IStageCell cell)
            {
                List<IStageCell> neighbors = new List<IStageCell>();

                int[] dy = { -1, 1, 0, 0 };
                int[] dx = { 0, 0, -1, 1 };

                for (int i = 0; i < 4; i++)
                {
                    int ny = cell.YPos + dy[i];
                    int nx = cell.XPos + dx[i];

                    if (IsValidCell(ny, nx) && _stageCells[ny, nx].Status.HasFlag(CellStatus.Movable))
                    {
                        neighbors.Add(_stageCells[ny, nx]);
                    }
                }

                return neighbors;
            }

            private bool IsValidCell(int y, int x)
            {
                return y >= 0 && y < _stageCells.GetLength(0) && x >= 0 && x < _stageCells.GetLength(1);
            }

            private int Heuristic(IStageCell cell, int goalY, int goalX)
            {
                // マンハッタン距離を使用
                return Mathf.Abs(cell.YPos - goalY) + Mathf.Abs(cell.XPos - goalX);
            }

            private void BuildPath(IStageCell startCell, IStageCell goalCell)
            {
                _path.Clear();
                IStageCell current = goalCell;
                while (current != startCell)
                {
                    _path.Insert(0, current);
                    current = current.Parent;
                }
                _path.Insert(0, startCell);
            }
        }
    }
}
