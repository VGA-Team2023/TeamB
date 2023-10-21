using TeamB_TD.ResourceManagement;
using UniRx;
using UnityEngine;

public class UIPresenter : MonoBehaviour
{
    [SerializeField] ResourceModel _rm;
    [SerializeField] UIView _view;

    void Start()
    {
        _rm.CurrentResourceChanged.Subscribe(value => _view.SetCurrentResource(value));
    }
}
