using System;
using UnityEngine;

namespace InfiniEngine.UI {

    public class Box : IControl {

        public Rect controlRegion { get; set; }
        public GUIStyle controlStyle { get; set; }
        public string controlCaption;

        public Box(Rect initialRegion, string initialCaption, GUIStyle initialStyle) {

            controlRegion = initialRegion;
            controlStyle = initialStyle;
            controlCaption = initialCaption;
        
        }

        public Box(Rect initialRegion, string initialCaption) {

            controlRegion = initialRegion;
            controlStyle = InterfaceManager.defaultSkin.box;
            controlCaption = initialCaption;

        }

        public void OnRender() {
            
            GUI.Box(controlRegion, controlCaption, controlStyle);

        }

    }

}
