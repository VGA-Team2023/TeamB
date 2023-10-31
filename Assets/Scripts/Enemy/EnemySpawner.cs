// 日本語対応
using TeamB_TD.StageManagement;
using UnityEngine;

namespace TeamB_TD
{
    namespace Enemy
    {
        public class EnemySpawner : MonoBehaviour
        {
            [SerializeField]
            private EnemyMoveV2 _enemyPrefab;
            [SerializeField, Range(0.2f, 10f)]
            private float _spawnInterval = 0.5f;
            [SerializeField, Range(1, 5)]
            private int _spawnCount = 0;

            private float _timer = 0f;
            private int _spawnedCount;
            private StageController _stageController;
            private IStageCell _cell; // スポナーにするセル。
            private IStageCell _towerCell; // タワーが配置してあるセル。

            public int SpawnCount => _spawnCount;

            public void Initialize(StageController stageController, IStageCell spawnerCell, IStageCell towerCell)
            {
                _stageController = stageController;
                _cell = spawnerCell; _towerCell = towerCell;
            }

            private void Update()
            {
                _timer += Time.deltaTime;

                if (_spawnedCount < _spawnCount && _timer >= _spawnInterval)
                {
                    Spawn();
                    _timer -= _spawnInterval;
                }
            }

            private void Spawn()
            {
                _spawnedCount++;

                var pos = _cell.GameObject.transform.position;
                pos.y += 1;
                var instance = Instantiate(_enemyPrefab, pos, Quaternion.identity, _cell.GameObject.transform);
                instance.Initialize(
                    _stageController.Stage.StageCells,
                    _cell.YPos,
                    _cell.XPos,
                    _towerCell.YPos,
                    _towerCell.XPos);
            }
        }
    }
}