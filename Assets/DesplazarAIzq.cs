using UnityEngine;
using System.Collections;

public class DesplazarAIzq : MonoBehaviour {
	public GameObject user;
	public GameObject planet;
	public float range = 1000f;
	public float inclinacion = 70f;
	bool movementDone = false;
	private Vector3 initialVector;

	void Start () {
		inclinacion = convertDegreesToSensibility (inclinacion);
		initialVector = new Vector3(0.0f, -1.0f, 0.0f);
	}

	void Update () {
		if (!movementDone) {
			float distanceX = user.transform.position.x - planet.transform.position.x;
			float distanceY = user.transform.position.y - planet.transform.position.y;
			float distanceZ = user.transform.position.z - planet.transform.position.z;
			if (Mathf.Abs (distanceX) <= range 
				&& Mathf.Abs (distanceY) <= range 
				&& Mathf.Abs (distanceZ) <= range) {
				if (initialVector.x + inclinacion < Input.acceleration.x){
					user.transform.position = new Vector3 (-8053,
						2, -1760);
					movementDone=true;
				}
			}
		}
	}

	private float convertDegreesToSensibility(float inclinationDegrees){
		return inclinationDegrees / 90f;
	}
}
