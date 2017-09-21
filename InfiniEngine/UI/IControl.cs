using System;
using UnityEngine;

namespace InfiniEngine.UI {

    /// <summary>
    /// Defines a new control
    /// </summary>
    public interface IControl {

        Rect controlRegion { get; set; }
        GUIStyle controlStyle { get; set; }

        void OnRender();

    }

}
