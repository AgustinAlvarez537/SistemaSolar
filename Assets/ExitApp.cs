using UnityEngine;
using System.Collections;

public class ExitApp : MonoBehaviour {
	public GameObject usuario;
	public GameObject SureExitPanel;
	public float velocidad = 0.7f;
	bool doorMoved = false;
	bool movementUpRecognized = false;
	bool movementDownRecognized = false;
	bool recognizing = false;
	[Header("Tiempo máximo para reconocer el gesto")]
	public float tiempoMax= 5f;
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

				if (Input.gyro.rotationRateUnbiased.x > velocidad && !movementUpRecognized)
					recognizing = true;

				if (!recognizing)
					maxTimeToRecognizeGesture = Time.time + tiempoMax;
				else {
					if (!movementUpRecognized && Time.time < maxTimeToRecognizeGesture) {
						if (Input.gyro.rotationRateUnbiased.x > velocidad) {
							// reconocí el primer movimiento de la cabeza hacia arriba dentro del tiempo permitido
							recognizing = true;
							movementUpRecognized = true;
							if (usuario.GetComponent<TextMesh> ().text != null) { 
							}
						}
					} else if (Input.gyro.rotationRateUnbiased.x < -velocidad &&
						!movementDownRecognized && Time.time < maxTimeToRecognizeGesture) { 
						// reconocí el primer movimiento de la cabeza hacia abajo dentro del tiempo permitido
						movementDownRecognized = true;
					} else if (Input.gyro.rotationRateUnbiased.x > velocidad &&
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

