using System;
using UnityEngine;
using InfiniEngine;

public class ObjectComponent : MonoBehaviour {

    // Should be applied to all gameobjects to be managed by the engine

    public InfiniObject infiniObject {

        get {

            if (isInitialized) {

                return infiniObject;

            } else return null;

        }

        set { }

    }

    private bool isInitialized = false;

    public void InitializeObject(int startingHealth, int ignitionTemp) {

        infiniObject = new InfiniObject(this.gameObject, startingHealth, ignitionTemp, true);
        isInitialized = true;

    }

}

