using System;
using UnityEngine;

namespace InfiniEngine {

    public delegate void OnInfiniObjectIgniteEventHandler(object sender, EventArgs e);
    public delegate void OnInfiniObjectDestroyEventHandler(object sender, InfiniObject.ObjectState os);

    public class InfiniObject {

        public enum ObjectState {

            Normal = 0,
            Destroyed = 1,
            Chared = 2,
            OnFire = 3

        }

        public GameObject unityObject;
        public Texture2D texture {

            get {

                return texture;

            }

            set {

                unityObject.GetComponent<Renderer>().material.SetTexture("_MainTex", value);
                texture = value;

            }

        }

        public bool isDynamic {

            get {

                return isDynamic;

            }

            set {

                if (value) {

                    if (unityObject.GetComponent<Rigidbody>() == null) {

                        unityObject.AddComponent<Rigidbody>();

                    }

                    isDynamic = value;

                } else {

                    if (unityObject.GetComponent<Rigidbody>() != null) {

                        GameObject.Destroy(unityObject.GetComponent<Rigidbody>());

                    }

                    isDynamic = value;

                }

            }

        }

        public event OnInfiniObjectIgniteEventHandler OnIgnite;
        public event OnInfiniObjectDestroyEventHandler OnDestroy;

        private int objectTempurature;
        private int objectHealth;
        private int objectIngitionPoint;
        private ObjectState myState;

        public InfiniObject(GameObject thisUnityObject, int startingHealth, int ignitionPoint) {

            unityObject = thisUnityObject;
            objectHealth = startingHealth;

        }

        public void RaiseTempurature(int ammountToRaise) {

            objectTempurature += ammountToRaise;

            if (objectTempurature >= objectIngitionPoint && myState != ObjectState.Chared && myState != ObjectState.OnFire) {

                Ignite();

            }

        }

        public void Ignite() {

            if (myState != ObjectState.Chared && myState != ObjectState.OnFire) {
                
                myState = ObjectState.OnFire;
                OnIgnite?.Invoke(this, EventArgs.Empty);

            }

        }

        public void Damage(int ammountOfDamage) {

            objectHealth -= ammountOfDamage;

            if (objectHealth <= 0) {

                Destroy();

            }

        }

        public void Destroy() {

            if (myState == ObjectState.OnFire) {

                myState = ObjectState.Chared;
                unityObject.GetComponent<Renderer>().material.color = Color.black;               

            }

            OnDestroy?.Invoke(this, myState);

        }

        public ObjectState GetState() {

            return myState;

        }

    }

}
