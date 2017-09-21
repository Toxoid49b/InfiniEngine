using System;
using UnityEngine;

namespace InfiniEngine.UI {

    public class Label : IControl {

        public Rect controlRegion { get; set; }
        public GUIStyle controlStyle { get; set; }
        public string controlCaption;

        public Label(Rect initialRegion, string initialCaption, GUIStyle initialStyle) {

            controlRegion = initialRegion;
            controlCaption = initialCaption;
            controlStyle = initialStyle;

        }

        public Label(Rect initialRegion, string initialCaption) {

            controlRegion = initialRegion;
            controlCaption = initialCaption;
            controlStyle = InterfaceManager.defaultSkin.label;

        }

        public void OnRender() {

            GUI.Label(controlRegion, controlCaption, controlStyle);

        }

    }

}
