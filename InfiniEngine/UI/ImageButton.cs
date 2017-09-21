using System;
using UnityEngine;

namespace InfiniEngine.UI {

    public class ImageButton {

        public Rect controlRegion { get; set; }
        public GUIStyle controlStyle { get; set; }
        public Texture2D controlImage;

        public event OnButtonClickEventHandler OnClick;

        public ImageButton(Rect initialRegion, Texture2D initialImage, GUIStyle initialStyle) {

            controlRegion = initialRegion;
            controlStyle = initialStyle;
            controlImage = initialImage;
        
        }

        public ImageButton(Rect initialRegion, Texture2D initialImage) {

            controlRegion = initialRegion;
            controlStyle = InterfaceManager.defaultSkin.button;
            controlImage = initialImage;

        }

        public void OnRender() {

            if (GUI.Button(controlRegion, controlImage, controlStyle)) {

                if (OnClick != null) OnClick(this, EventArgs.Empty);

            }

        }

    }

}
