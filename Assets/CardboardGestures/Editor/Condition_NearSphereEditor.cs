using UnityEngine;
using System.Collections;
using UnityEditor;

namespace CardboardGestures.Conditions
{
    [CustomEditor(typeof(Condition_NearSphere))]
    public class Condition_NearSphereEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            Condition_NearSphere myScript = (Condition_NearSphere)target;
            myScript.objeto1 = (GameObject)EditorGUILayout.ObjectField("Objecto 1 (Movil)", myScript.objeto1, typeof(GameObject));

            myScript.objeto2 = (GameObject)EditorGUILayout.ObjectField("Objecto 2 (Inmovil)", myScript.objeto2, typeof(GameObject));

            myScript.range = EditorGUILayout.FloatField("Rango", myScript.range);

            myScript.showBalloon = EditorGUILayout.Toggle("Mostrar rango", myScript.showBalloon);

            if (myScript.showBalloon)
            {
                if (myScript.objeto2 != null && myScript.Balloon == null)
                {
                    myScript.Balloon = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                    myScript.Balloon.name = "Range sphere";
                    myScript.Balloon.transform.position = myScript.objeto2.transform.position;
                    
                    myScript.Balloon.transform.localScale = new Vector3(myScript.range * 2, myScript.range * 2, myScript.range * 2);
                    //myScript.Balloon.GetComponent<Renderer>().material.shader = Shader.Find("Unlit/Transparent");
                    Color c = Color.yellow;
                    c.a = 0.3f;
                    myScript.Balloon.GetComponent<Renderer>().material.color = c;
                    myScript.Balloon.GetComponent<Renderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
                }
                if (myScript.range != myScript.oldRange)
                {
                    myScript.oldRange = myScript.range;
                    myScript.Balloon.transform.position = myScript.objeto2.transform.position;
                    myScript.Balloon.transform.localScale = new Vector3(myScript.range * 2, myScript.range * 2, myScript.range * 2);
                }
            }
            else
            {
                GameObject.DestroyImmediate(myScript.Balloon);
                myScript.Balloon = null;
            }
        }
    }
}