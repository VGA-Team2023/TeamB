// 日本語対応
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace TeamB_TD
{
    namespace Unit
    {
        namespace PlaceDemo
        {
            public class SampleAllyUnit : UnitBehaviour
            {
                [SerializeField]
                private string _name;
                [SerializeField]
                private int _cost;

                public override string Name => _name;
                public override int Cost => _cost;


                private async void OnMouseDown()
                {
                    var startPos = Input.mousePosition;
                    Debug.Log("start");
                    while (!Input.GetMouseButtonUp(0))
                    {
                        var mouseDir = DirectionUtility.GetClosestDirection(startPos, Input.mousePosition);
                        this.transform.rotation = DirectionUtility.GetRotationFromDirection(mouseDir);
                        await UniTask.Yield(cancellationToken: this.GetCancellationTokenOnDestroy());
                    }
                    Debug.Log("end");
                }
            }
        }
    }
}