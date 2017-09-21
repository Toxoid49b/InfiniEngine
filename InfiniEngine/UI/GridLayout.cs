using System;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniEngine.UI {

    public class GridLayout : InterfaceLayout {

        public uint controlsPerLine;

        public override void UpdateControls(Rect layoutRegion) {

            uint ctrlCount = 0;

            foreach (IControl ctrl in GetControlList()) {

                ctrlCount++;

                if (ctrlCount % controlsPerLine != 0) {

                    //ctrl.controlRegion = 

                }                

            }

        }

    }

}
