using UnityEngine;
using System.Collections;

public class NotExitApp : MonoBehaviour {
	
	public GameObject SureExitPanel;
	public GameObject MenuPlanetarioPanel;
	public GameObject user;
	public float maxTimeToRecognizeGesture = 5.0f;
	bool derechaReconocida;
	bool IzquierdaReconocida;
	bool reconociendo;
	public float gestureSpeed = 2.0f;
	float tiempoMax = 5.0f;
	bool notExit = false;

	void Start () {
		Input.gyro.enabled = true;
		derechaReconocida = false;
		IzquierdaReconocida = false;
		reconociendo = true;
	}


	void Update(){
		if (!notExit) {
			if (Time.time >= maxTimeToRecognizeGesture) {
				reconociendo = false;
				IzquierdaReconocida = false;
				derechaReconocida = false;
			}

			if (Input.gyro.rotationRateUnbiased.y > gestureSpeed && !IzquierdaReconocida)
				reconociendo = true;

			if (!reconociendo)
				maxTimeToRecognizeGesture = Time.time + tiempoMax;
			else {
				if (!IzquierdaReconocida && Time.time < maxTimeToRecognizeGesture) {
					if (Input.gyro.rotationRateUnbiased.y > gestureSpeed) {
						reconociendo = true;
						IzquierdaReconocida = true;
					}
				} else {
					if (Input.gyro.rotationRateUnbiased.y < -gestureSpeed && !derechaReconocida && Time.time < maxTimeToRecognizeGesture) { 
						derechaReconocida = true;
					} else {
						if (Input.gyro.rotationRateUnbiased.y > gestureSpeed && Time.time < maxTimeToRecognizeGesture && derechaReconocida) {
							IzquierdaReconocida = false;
							derechaReconocida = false;
							reconociendo = false;
							if (SureExitPanel.activeInHierarchy == true) {
								SureExitPanel.SetActive (false);
								MenuPlanetarioPanel.SetActive (true);
								notExit = true;
							}
						}
					}
				}
			}
		}
	}
}
