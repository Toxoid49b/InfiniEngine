using System;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniEngine.UI {

    public class InterfaceLayout {

        private List<IControl> childControls = new List<IControl>();

        public void AddControlToList(IControl newControl) {

            childControls.Add(newControl);

        }

        public void RemoveControlFromList(IControl controlToRemove) {

            childControls.Remove(controlToRemove);

        }

        public List<IControl> GetControlList() {

            return childControls;

        }

        public virtual void UpdateControls(Rect layoutRegion) { }

    }

}
