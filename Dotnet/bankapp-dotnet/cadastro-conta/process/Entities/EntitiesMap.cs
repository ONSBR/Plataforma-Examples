using ONS.SDK.Impl.Data;

namespace Entities
{
    public class EntitiesMap: AbstractDataMapCollection
    {
        protected override void Load() {
            BindMap<Conta>();
        }
    }
}