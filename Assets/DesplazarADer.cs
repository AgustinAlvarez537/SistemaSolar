using UnityEngine;
using System.Collections;

public class DesplazarADer : MonoBehaviour {
	public GameObject user;
	public GameObject planet;
	public float range = 1000f;
	public float inclination = 70f;
	bool movementDone = false;
	private Vector3 initialVector;

	void Start () {
		inclination = convertDegreesToSensibility (inclination);
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
				if (initialVector.x + inclination < Input.acceleration.x){
					user.transform.position = new Vector3 (-4835,
						2, -1805);
					movementDone=true;
				}
			}
		}
	}

	private float convertDegreesToSensibility(float inclinationDegrees){
		return inclinationDegrees / 90f;
	}
}