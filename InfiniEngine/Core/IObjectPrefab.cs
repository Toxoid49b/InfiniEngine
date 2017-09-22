using UnityEngine;

namespace InfiniEngine {

    public interface IObjectPrefab {

        void Instantiate(Vector3 requestedPosition, Quaternion requestedRotation);

    }

}
