// 日本語対応
using TeamB_TD.Unit.Ally;
using UnityEngine;
using UnityEngine.UI;

public class TestAllyDamage : MonoBehaviour
{
    [SerializeField]
    private AllyMain _damageTaker;

    [SerializeField]
    private Button _damagaButton;

    [SerializeField]
    private float _damageValue;

    private void Start()
    {
        _damagaButton.onClick.AddListener(() => _damageTaker.Damage(_damageValue));
    }
}