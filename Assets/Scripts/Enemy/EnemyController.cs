using System.Collections;
using TeamB_TD.Enemy;
using UnityEngine;

//日本語対応
[RequireComponent(typeof(EnemyAttack), typeof(EnemyMove))]
public class EnemyController : MonoBehaviour
{
    public EnemyStatus EnemyStatus => _status;

    [SerializeField] private EnemyStatus _status = new EnemyStatus();
}
