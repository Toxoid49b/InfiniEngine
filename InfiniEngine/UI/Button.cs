using System;
using UnityEngine;

namespace InfiniEngine.UI {

    public delegate void OnButtonClickEventHandler(object sender, EventArgs e);

    public class Button : IControl {

        public Rect controlRegion { get; set; }
        public GUIStyle controlStyle { get; set; }
        public string controlCaption;

        public event OnButtonClickEventHandler OnClick;

        public Button(Rect initialRegion, string initialCaption, GUIStyle initialStyle) {

            controlRegion = initialRegion;
            controlStyle = initialStyle;
            controlCaption = initialCaption;
        
        }

        public Button(Rect initialRegion, string initialCaption) {

            controlRegion = initialRegion;
            controlStyle = InterfaceManager.defaultSkin.button;
            controlCaption = initialCaption;

        }

        public void OnRender() {

            if (GUI.Button(controlRegion, controlCaption, controlStyle)) {

                if (OnClick != null) OnClick(this, EventArgs.Empty);

            }

        }

    }

}
