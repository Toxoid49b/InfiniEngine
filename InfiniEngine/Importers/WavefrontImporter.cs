using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace InfiniEngine.Importers {

    public class WavefrontImporter {

        private struct OBJFace {

            public string materialName;
            public string meshName;
            public int[] indexes;

        }

        /// <summary>
        /// Creates a mesh from a byte array containing Wavefront OBJ data
        /// </summary>
        public static Mesh MeshFromBytes(byte[] meshData) {

            return LoadFromString(Encoding.UTF8.GetString(meshData).Split('\n'));

        }

        /// <summary>
        /// Creates a mesh from a file containing Wavefront OBJ data
        /// </summary>
        public static Mesh LoadFromFile(string filePath) {

            return LoadFromString(File.ReadAllLines(filePath));

        }

        /// <summary>
        /// Creates a mesh from a string containing Wavefront OBJ data
        /// </summary>
        public static Mesh LoadFromString(string[] objData) { // The worlds worst OBJ importer

            Mesh generatedMesh = new Mesh();

            List<Vector3> vertices = new List<Vector3>();
            List<Vector3> normals = new List<Vector3>();
            List<Vector2> uvs = new List<Vector2>();
            List<string> objectNames = new List<string>();
            string cmesh = "default";

            foreach (string ln in objData) {

                if (ln.Length > 0 && ln[0] != '#') {

                    string l = ln.Trim().Replace("  ", " ");
                    string[] cmps = l.Split(' ');
                    string data = l.Remove(0, l.IndexOf(' ') + 1);

                    switch (cmps[0]) {

                        case "g":
                        case "o":
                            cmesh = data;
                            if (!objectNames.Contains(cmesh)) objectNames.Add(cmesh);
                            break;
                        case "v":
                            vertices.Add(ParseVectorFromCMPS(cmps));
                            break;
                        case "vn":
                            normals.Add(ParseVectorFromCMPS(cmps));
                            break;
                        case "vt":
                            uvs.Add(ParseVectorFromCMPS(cmps));
                            break;
                    }                    

                }

            }

            generatedMesh.vertices = vertices.ToArray();
            generatedMesh.normals = normals.ToArray();
            generatedMesh.uv = uvs.ToArray();
            generatedMesh.RecalculateNormals();
            generatedMesh.RecalculateBounds();
            generatedMesh.Optimize();

            return generatedMesh;

        }

        private static Vector3 ParseVectorFromCMPS(string[] cmps) {

            float x = float.Parse(cmps[1]);
            float y = float.Parse(cmps[2]);

            if (cmps.Length == 4) {

                float z = float.Parse(cmps[3]);
                return new Vector3(x, y, z);

            }

            return new Vector2(x, y);

        }

    }

}
