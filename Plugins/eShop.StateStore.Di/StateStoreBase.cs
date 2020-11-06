using eShop.UseCases.PluginInterfaces.StateStore;
using System;

namespace eShop.StateStore.Di
{
    public class StateStoreBase : IStateStore
    {
        protected Action listners;

        public void AddStateChangeListners(Action listner) => this.listners += listner;

        public void BroadCastStateChange()
        {
            if (this.listners != null)
            {
                this.listners.Invoke();
            }
        }

        public void RemoveStateChangeListners(Action listner) => this.listners += listner;
    }
}