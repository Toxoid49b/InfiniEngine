using System;
using UnityEngine;

namespace InfiniEngine {

    public class Item : MonoBehaviour {

        public string itemName {
        
            get {

                return itemName;

            }

            set {

                if (itemName == "") {

                    itemName = value;

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
