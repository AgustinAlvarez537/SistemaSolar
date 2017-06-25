using UnityEngine;
using System.Collections;
using UnityEditor;

namespace CardboardGestures.Conditions
{
    [CustomEditor(typeof(Condition_NearCube))]
    public class Condition_NearCubeEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            Condition_NearCube myScript = (Condition_NearCube)target;

            myScript.objeto1 = (GameObject)EditorGUILayout.ObjectField("Objecto 1 (Movil)", myScript.objeto1, typeof(GameObject));

            myScript.showCube = EditorGUILayout.Toggle("Mostrar rango", myScript.showCube);
            myScript.posicion = EditorGUILayout.Vector3Field("Posición del cubo", myScript.posicion);
            myScript.size = EditorGUILayout.FloatField("Tamaño del cubo", myScript.size);

            if (myScript.showCube)
            {
                if (myScript.Cube == null)
                {
                    myScript.Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                    //myScript.Cube.GetComponent<MeshRenderer>().materials = new Material[0];
                    myScript.Cube.name = "Range cube";
                    myScript.Cube.transform.position = myScript.posicion;
                    Color c = Color.yellow;
                    c.a = 0.3f;
                    myScript.Cube.GetComponent<Renderer>().material.color = c;


                    myScript.Cube.transform.localScale = new Vector3(myScript.size / 2, myScript.size / 2, myScript.size / 2);
                }

                if (myScript.size != myScript.oldSize)
                {
                    myScript.oldSize = myScript.size;
                    myScript.Cube.transform.position = myScript.posicion;
                    myScript.Cube.transform.localScale = new Vector3(myScript.size / 2, myScript.size / 2, myScript.size / 2);
                }
            }
            else
            {
                GameObject.DestroyImmediate(myScript.Cube);
                myScript.Cube = null;
            }
        }
    }
}