using System;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniEngine.UI {

    /// <summary>
    /// Represents a dragable window populated by various controls
    /// </summary>
    public class Window {

        public string windowCaption;
        public int windowID;
        public Rect windowRegion;
        public GUIStyle windowStyle;
        public bool windowVisible;

        private List<IControl> controlList = new List<IControl>();

        public Window(int id, Rect region, string caption, GUIStyle style) {

            windowCaption = caption;
            windowRegion = region;
            windowID = id;
            windowStyle = style;
            windowVisible = true;

        }

        public Window(int id, Rect region, string caption) {

            windowCaption = caption;
            windowRegion = region;
            windowID = id;
            windowStyle = InterfaceManager.defaultSkin.window;
            windowVisible = true;

        }

        /// <summary>
        /// Called by the renderer
        /// </summary>
        public void Render(int windowID) {

            GUI.DragWindow(new Rect(0, 0, windowRegion.width, 17));

            foreach (IControl c in controlList) {

                c.OnRender();
            
            }

        }

        /// <summary>
        /// Remove the window from the interface stack
        /// </summary>
        public void Dispose() {

            InterfaceManager.RemoveWindow(this);

        }

        /// <summary>
        /// Adds a control to the window instance
        /// </summary>
        public void AddControl(IControl newControl) {

            controlList.Add(newControl);

        }

    }

}
