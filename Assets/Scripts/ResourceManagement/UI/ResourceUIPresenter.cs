using TeamB_TD.ResourceManagement;
using UniRx;
using UnityEngine;

namespace TeamB_TD
{
    namespace Resouce
    {
        namespace UI
        {
            public class ResourceUIPresenter : MonoBehaviour
            {
                [SerializeField] ResourceManager _rm;
                [SerializeField] ResourceTextApplyer _view;

                void Start()
                {
                    _rm.CurrentResourceChanged.Subscribe(value => _view.ApplyCurrentResource(value));
                }
            }
        }
    }
}