using System;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniEngine.UI {

    public static class InterfaceManager {

        private static Dictionary<int, Window> windowList = new Dictionary<int, Window>();
        private static bool showUI;
        private static GUISkin uiSkin;

        public static GUISkin defaultSkin {

            get {

                return uiSkin;

            }

            set { }

        }

        public static bool Initialize(GUISkin skin) {

            uiSkin = skin;
            return true;

        }

        public static bool AddWindow(Window windowToAdd) {

            if (!windowList.ContainsKey(windowToAdd.windowID)) {

                windowList.Add(windowToAdd.windowID, windowToAdd);
                return true;

            } else {

                Logger.Put("A window with ID " + windowToAdd.windowID + " already exists! (use InterfaceManager.GetFreeID())");                

            }

            return false;

        }

        public static bool RemoveWindow(Window windowToRemove) {

            if (windowList.ContainsKey(windowToRemove.windowID)) {

                windowList.Remove(windowToRemove.windowID);
                return true;

            } else {

                Logger.Put("A window with an invalid ID (" + windowToRemove.windowID + ") tried to remove itself!");

            }

            return false;

        }

        public static void GUILoop() {

            if (showUI) {

                foreach (Window w in windowList.Values) {

                    if(w.windowVisible) w.windowRegion = GUI.Window(w.windowID, w.windowRegion, w.Render, w.windowCaption, w.windowStyle);

                }

            }
            
        }

        public static int GetFreeWindowID() {

            if (windowList.Count == 0) { //No windows yet, return first index!

                return 0;

            }

            for (int I = 0; I <= windowList.Count; I++) { //Test for gaps, if not, return end value

                if (!windowList.ContainsKey(I)) {

                    return I;
                }

            }

            return -1; // Should never get to here

        }

        public static bool IsUIVisible() {

            return showUI;

        }

        public static bool RequestUIVisibilityState(bool newState) {

            if (newState) {

                if (!showUI) {

                    showUI = true;
                    return true;

                } else {

                    return false;

                }

            } else {

                if (showUI) {

                    showUI = false;
                    return true;

                } else {

                    return false;

                }

            }            

        }

        public static bool RequestUIVisibilityToggle() {
            
            if (!showUI) {
                
                showUI = true;
                return true;
            
            } else {

                showUI = false;
                return true;
            
            }

        }

    }

}
