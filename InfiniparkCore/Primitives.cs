using System;
using UnityEngine;
using InfiniEngine;
using InfiniEngine.Importers;

namespace InfiniparkCore {

    public class Primitives {

        public class Cube : IObjectPrefab {

            public void Instantiate(Vector3 requestedPosition, Quaternion requestedRotation) {

                GameObject primitiveCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                primitiveCube.transform.position = requestedPosition;
                primitiveCube.transform.rotation = requestedRotation;
                primitiveCube.name = "Cube Primitive";
                ObjectComponent cubeInfiniObject = primitiveCube.AddComponent<ObjectComponent>();
                cubeInfiniObject.InitializeObject(25, 600);

            }

        }

        public class DynamicCube : IObjectPrefab {

            public void Instantiate(Vector3 requestedPosition, Quaternion requestedRotation) {

                GameObject primitiveCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                primitiveCube.transform.position = requestedPosition;
                primitiveCube.transform.rotation = requestedRotation;
                primitiveCube.name = "Dynamic Cube Primitive";
                primitiveCube.AddComponent<Rigidbody>();
                ObjectComponent cubeInfiniObject = primitiveCube.AddComponent<ObjectComponent>();
                cubeInfiniObject.InitializeObject(25, 600);

            }

        }

        public class TexturedCube : IObjectPrefab {

            public void Instantiate(Vector3 requestedPosition, Quaternion requestedRotation) {

                GameObject primitiveCube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                primitiveCube.transform.position = requestedPosition;
                primitiveCube.transform.rotation = requestedRotation;
                primitiveCube.name = "Textured Cube Primitive";
                ObjectComponent cubeInfiniObject = primitiveCube.AddComponent<ObjectComponent>();
                cubeInfiniObject.InitializeObject(25, 600);
                cubeInfiniObject.infiniObject.texture = TextureImporter.LoadFromBytes(Properties.Resources.Portal);

            }

        }

        public class Sphere : IObjectPrefab {

            public void Instantiate(Vector3 requestedPosition, Quaternion requestedRotation) {

                GameObject primitiveSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                primitiveSphere.transform.position = requestedPosition;
                primitiveSphere.transform.rotation = requestedRotation;
                primitiveSphere.name = "Sphere Primitive";
                ObjectComponent sphereInfiniObject = primitiveSphere.AddComponent<ObjectComponent>();
                sphereInfiniObject.InitializeObject(25, 600);

            }

        }

        public class DynamicSphere : IObjectPrefab {

            public void Instantiate(Vector3 requestedPosition, Quaternion requestedRotation) {

                GameObject primitiveSphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                primitiveSphere.transform.position = requestedPosition;
                primitiveSphere.transform.rotation = requestedRotation;
                primitiveSphere.name = "Dynamic Sphere Primitive";
                primitiveSphere.AddComponent<Rigidbody>();
                ObjectComponent sphereInfiniObject = primitiveSphere.AddComponent<ObjectComponent>();
                sphereInfiniObject.InitializeObject(25, 600);

            }

        }

    }

}
