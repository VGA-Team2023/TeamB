//日本語対応

using TeamB_TD.Unit;

namespace TeamB_TD
{
    namespace StageManagement
    {
        public interface IUnitPlaceable // ユニット配置可能を表現する
        {
            bool IsPlaced { get; }
            UnitBehaviour PlacedObject { get; }
            void Place(UnitBehaviour placedObject);
        }
    }
}