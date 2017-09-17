using UnityEngine;
using System.Collections;

public class ExitApp : MonoBehaviour {
	public GameObject user;
	public GameObject SureExitPanel;
	public float gestureSpeed = 0.7f;
	bool doorMoved = false;
	bool movementUpRecognized = false;
	bool movementDownRecognized = false;
	bool recognizing = false;
	[Header("Max time to recognize the gesture")]
	public float maxTime= 5f;
	float maxTimeToRecognizeGesture=5f;
	bool insideZone = false;

	void Start () {
		Input.gyro.enabled = true;
		recognizing = true;
		movementUpRecognized = false;
		movementDownRecognized = false;
	}

	void Update(){
		if (!doorMoved) {
				if (Time.time >= maxTimeToRecognizeGesture) {
					recognizing = false;
					movementUpRecognized = false;
					movementDownRecognized = false;
				}

				if (Input.gyro.rotationRateUnbiased.x > gestureSpeed && !movementUpRecognized)
					recognizing = true;

				if (!recognizing)
					maxTimeToRecognizeGesture = Time.time + maxTime;
				else {
					if (!movementUpRecognized && Time.time < maxTimeToRecognizeGesture) {
						if (Input.gyro.rotationRateUnbiased.x > gestureSpeed) {
							// reconocí el primer movimiento de la cabeza hacia arriba dentro del tiempo permitido
							recognizing = true;
							movementUpRecognized = true;
							if (user.GetComponent<TextMesh> ().text != null) { 
							}
						}
					} else if (Input.gyro.rotationRateUnbiased.x < -gestureSpeed &&
						!movementDownRecognized && Time.time < maxTimeToRecognizeGesture) { 
						// reconocí el primer movimiento de la cabeza hacia abajo dentro del tiempo permitido
						movementDownRecognized = true;
					} else if (Input.gyro.rotationRateUnbiased.x > gestureSpeed &&
						Time.time < maxTimeToRecognizeGesture && movementDownRecognized) {
						// reconocí el segundo movimiento de la cabeza hacia arriba dentro del tiempo permitido
						movementUpRecognized = false;
						movementDownRecognized = false;
						recognizing = false;
						if (SureExitPanel.activeInHierarchy == true) {
							Application.Quit ();
							doorMoved = true;
						}
					}

				}
			}
		}
	}

