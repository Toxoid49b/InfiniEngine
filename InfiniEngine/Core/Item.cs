using System;
using UnityEngine;

namespace InfiniEngine {

    public class Item : MonoBehaviour {

        public string itemName {
        
            get {

                return this.itemName;

            }

            set {

                if (this.itemName == "") {

                    this.itemName = value;

                }

            }

        }

        private uint? itemID;

        public Item(string name, uint? id) {

            itemName = name;
            itemID = id;

        }

        public uint? GetID(){

            return itemID;

        }

    }

}
