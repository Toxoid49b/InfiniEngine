using System;
using UnityEngine;
using InfiniEngine;

public class ObjectComponent : MonoBehaviour {

    public InfiniObject infiniObject {

        get {

            if (isInitialized) {

                return this.infiniObject;

            } else return null;

        }

        set { }

    }

    private bool isInitialized = false;

    public void InitializeObject(int startingHealth, int ignitionTemp) {

        infiniObject = new InfiniObject(this.gameObject, startingHealth, ignitionTemp);
        isInitialized = true;

    }

}

