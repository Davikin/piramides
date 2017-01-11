using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IHasChanged {
    void Start() {
        HasChanged();
    }

    #region IHasChanged implementation
    public void HasChanged() {
        System.Text.StringBuilder builder = new System.Text.StringBuilder();
    }
    #endregion
}

namespace UnityEngine.EventSystems {
    public interface IHasChanged : IEventSystemHandler {
        void HasChanged();
    }
}