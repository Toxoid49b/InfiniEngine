using System;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniEngine {

    public delegate void OnInfiniObjectIgniteEventHandler(object sender, EventArgs e);
    public delegate void OnInfiniObjectDestroyEventHandler(object sender, InfiniObject.ObjectState os);

    public class InfiniObject {

        private Dictionary<string, object> metaData = new Dictionary<string, object>();

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

        public InfiniObject(GameObject thisUnityObject, int startingHealth, int ignitionPoint, bool dynamic) {

            unityObject = thisUnityObject;
            objectHealth = startingHealth;
            objectIngitionPoint = ignitionPoint;
            isDynamic = dynamic;

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

            }

            OnDestroy?.Invoke(this, myState);

        }

        public ObjectState GetState() {

            return myState;

        }

        public void AddMetaData(string dataName, object dataValue) {

            metaData.Add(dataName, dataValue);

        }

        public bool UpdateMetaData(string dataName, object newValue) {

            if (metaData.ContainsKey(dataName)) {

                metaData[dataName] = newValue;
                return true;

            } else {

                return false;

            }

        }

        public bool DestroyMetaData(string dataName) {

            if (metaData.ContainsKey(dataName)) {

                metaData.Remove(dataName);
                return true;

            } else {

                return false;

            }

        }

        /// <summary>
        /// Creates a new InfiniObject based on the given paramaters
        /// </summary>
        public static InfiniObject CreateObject(string objectName, Mesh objectMesh, Material objectMaterial, Vector3 initialPosition, Quaternion initialRotation, Vector3 initalScale, int initalHealth, int ignitionPoint, bool isDynamic = true) {

            GameObject baseObject = new GameObject(objectName);
            baseObject.AddComponent<MeshFilter>().mesh = objectMesh;
            baseObject.AddComponent<MeshRenderer>().material = objectMaterial;
            baseObject.transform.localPosition = initialPosition;
            baseObject.transform.localRotation = initialRotation;
            baseObject.transform.localScale = initalScale;

            InfiniObject newObject = new InfiniObject(baseObject, initalHealth, ignitionPoint, isDynamic);
            return newObject;

        }

    }

}
