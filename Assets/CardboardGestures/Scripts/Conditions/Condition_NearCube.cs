using UnityEngine;
using System.Collections;
namespace CardboardGestures.Conditions
{
    public class Condition_NearCube : AbstractCondition
    {
        public GameObject objeto1;
        public GameObject Cube;
        public bool showCube;
        public float size;
        public float oldSize;
        public Vector3 posicion;

        // el range forma una esfera alrededor del centro del objeto que de ser traspasada hacia adentro hace que la función satisfied se evalue en true, de lo contrario en false

        public override bool satisfied()
        {
            if (objeto1 != null)
			{	
				if (objeto1.GetComponent<BoxCollider>() == null) 
				{
					BoxCollider c = objeto1.AddComponent<BoxCollider>();
					c.size = new Vector3 (10, 10, 10);
				}
				if (Cube.GetComponent<BoxCollider>().bounds.Intersects(objeto1.GetComponent<BoxCollider>().bounds))
                {
                    return true;
                }
            }
            return false;
        }

        void Start()
        {
            if (Cube == null)
            {
                Cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                Cube.transform.position = posicion;
                Cube.transform.localScale = new Vector3(size / 2, size / 2, size / 2);
            }
            Cube.GetComponent<MeshRenderer>().materials = new Material[0];
        }
    }
    
}
