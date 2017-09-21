using System;
using System.Collections.Generic;
using UnityEngine;

namespace InfiniEngine {

    public interface IObjectPrefab {

        void Instantiate(Vector3 requestedPosition, Quaternion requestedRotation);

    }

}
