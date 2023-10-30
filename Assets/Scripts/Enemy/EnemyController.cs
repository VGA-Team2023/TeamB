using TeamB_TD.Enemy;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private EnemyStatus _status = new EnemyStatus();

    public EnemyStatus EnemyStatus => _status;
}
