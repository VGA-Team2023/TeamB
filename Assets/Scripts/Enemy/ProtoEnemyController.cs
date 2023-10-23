using System.Collections;
using System.Collections.Generic;
using TeamB_TD.Enemy;
using UnityEngine;

//日本語対応
[RequireComponent(typeof(ProtoEnemyAttack), typeof(ProtoEnemyMove))]
public class ProtoEnemyController : MonoBehaviour
{
    public EnemyStatus EnemyStatus => _status;

    [SerializeField] private EnemyStatus _status = new EnemyStatus();
}
