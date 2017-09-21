using System;
using UnityEngine;

namespace InfiniEngine.UI {

    public class TextArea : IControl {

        public Rect controlRegion { get; set; }
        public GUIStyle controlStyle { get; set; }
        public string textAreaCaption;

        public TextArea(Rect initialRegion, string initialCaption, GUIStyle initialStyle) {

            controlRegion = initialRegion;
            controlStyle = initialStyle;
            textAreaCaption = initialCaption;
        
        }

        public TextArea(Rect initialRegion, string initialCaption) {

            controlRegion = initialRegion;
            controlStyle = InterfaceManager.defaultSkin.textArea;
            textAreaCaption = initialCaption;

        }

        public void OnRender() {
            
            GUI.TextArea(controlRegion, textAreaCaption, controlStyle);

        }

    }

}
