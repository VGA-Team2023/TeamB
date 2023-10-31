// 日本語対応
using TeamB_TD.Enemy;
using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        public class GameManager : MonoBehaviour
        {
            private static GameManager _current;
            public static GameManager Current => _current;

            [SerializeField]
            private StageManagement.StageController _stageController;
            [SerializeField]
            private int _towerLife;
            [SerializeField]
            private Status _gameStatus;

            [SerializeField]
            private int _enemyCount; // 全ての敵の数
            [SerializeField]
            private int _enemyArrivalCount; // タワーに到着した敵の数
            [SerializeField]
            private int _completedEnemyCount; // 行動完了した敵の総数

            public Status GameStatus => _gameStatus;

            private void Start()
            {
                _gameStatus = Status.InProgress;
                var enemySpawners = GameObject.FindObjectsByType<EnemySpawner>(FindObjectsSortMode.None);

                foreach (var spawner in enemySpawners)
                {
                    if (spawner.enabled)
                    {
                        _enemyCount += spawner.SpawnCount;
                    }
                }

                if (_stageController.Stage.GetTowerCell().GameObject.TryGetComponent(out TowerControl.Tower tower))
                {
                    _towerLife = tower.MaxLife;
                }

                if (_enemyCount < _towerLife) _towerLife = _enemyCount;
            }

            private void OnEnable()
            {
                _current = this;
            }

            private void OnDisable()
            {
                _current = null;
            }

            public void AddCompletedEnemyCount(EnemyStatus enemyStatus) // 敵が行動完了したときに呼び出す。
            {
                if (_gameStatus != Status.InProgress)
                {
                    Debug.Log("既に決着しています。");
                    return;
                }

                if (enemyStatus.IsArrivedTower)
                {
                    _enemyArrivalCount++;

                    if (_towerLife == _enemyArrivalCount)
                    {
                        _gameStatus = Status.Loss;
                        return;
                    }
                }

                _completedEnemyCount++;
                if (_completedEnemyCount == _enemyCount)
                {
                    _gameStatus = Status.Win;
                    return;
                }
            }

            public enum Status
            {
                InProgress, // ゲームが進行中であることを示します。
                Win,        // プレイヤーがゲームに勝利したことを示します。
                Loss,       // プレイヤーがゲームに負けたことを示します。
            }
        }
    }
}