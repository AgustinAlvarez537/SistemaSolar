using UnityEngine;
using System.Collections;
namespace CardboardGestures.Conditions
{
    public class Condition_NearSphere : AbstractCondition
    {
        [HideInInspector] public GameObject objeto1;
        public GameObject Balloon;
        public bool showBalloon;
        public float range;
        public float oldRange;
		public Vector3 posicion;
        public GameObject objeto2;
        // el range forma una esfera alrededor del centro del objeto que de ser traspasada hacia adentro hace que la función satisfied se evalue en true, de lo contrario en false

		public override bool satisfied()
		{
            /*
            if (objeto2 != null)
            {
                if (objeto2.GetComponent<SphereCollider>() == null)
                {
                    SphereCollider c = objeto1.AddComponent<SphereCollider>();
                    c.radius = 50f;
                }
            }  */
                if (objeto1 != null)
			{	
				
				if (objeto1.GetComponent<BoxCollider>() != null) {
					if (Balloon.GetComponent<SphereCollider> ().bounds.Intersects (objeto1.GetComponent<BoxCollider> ().bounds))
					{					
						return true;
					}
				}

                if (objeto1.GetComponent<SphereCollider>() == null)
                {
                    SphereCollider c = objeto1.AddComponent<SphereCollider>();
                    c.radius = 50f;
                }

                else if (objeto1.GetComponent<SphereCollider>() != null) {
					if (Balloon.GetComponent<SphereCollider> ().bounds.Intersects (objeto1.GetComponent<SphereCollider> ().bounds)) {
						return true;
					}
				}
			}
			return false;
		}

        void Start()
        {
            if (Balloon == null)
            {
                Balloon = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            }
            Balloon.GetComponent<MeshRenderer>().materials = new Material[0];
        }
    }
}
