using System;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniEngine.UI {

    public delegate void OnTextFieldTextChangeEventHandler(object sender, EventArgs e);
    public delegate void OnTextFieldTrapkeyPressed(object sender, TrapkeyEventArgs e);

    public class TrapkeyEventArgs : EventArgs {

        private KeyCode tKeyCode;
        public KeyCode trappedKey {

            get {

                return tKeyCode;

            }

            set { }

        }

        public TrapkeyEventArgs(KeyCode tKey) {

            tKeyCode = tKey;

        }

    }

    public class TextField : IControl {

        private string oldText;
        private List<KeyCode> trapedKeys = new List<KeyCode>();

        public Rect controlRegion { get; set; }
        public GUIStyle controlStyle { get; set; }
        public string textFieldCaption;

        public event OnTextFieldTextChangeEventHandler OnTextChange;
        public event OnTextFieldTrapkeyPressed OnTrapkeyPressed;

        public TextField(Rect initialRegion, string initialCaption, GUIStyle initialStyle) {

            controlRegion = initialRegion;
            controlStyle = initialStyle;
            textFieldCaption = initialCaption;
        
        }

        public TextField(Rect initialRegion, string initialCaption) {

            controlRegion = initialRegion;
            controlStyle = InterfaceManager.defaultSkin.textField;
            textFieldCaption = initialCaption;

        }

        public void OnRender() {

            Event e = Event.current;

            if (e.type == EventType.keyDown) {

                foreach (KeyCode kc in trapedKeys) {

                    if (e.keyCode == kc) {

                        if (OnTrapkeyPressed != null) OnTrapkeyPressed(this, new TrapkeyEventArgs(e.keyCode));

                    }

                }                

            }

            textFieldCaption = GUI.TextField(controlRegion, textFieldCaption, controlStyle);

            if (textFieldCaption != oldText) {
                if (OnTextChange != null) OnTextChange(this, EventArgs.Empty);
            }            

            oldText = textFieldCaption;

        }

        public void AddKeytrap(KeyCode keyToTrap) {

            trapedKeys.Add(keyToTrap);

        }

    }

}
