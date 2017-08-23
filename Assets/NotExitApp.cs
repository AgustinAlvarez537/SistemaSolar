using UnityEngine;
using System.Collections;

public class NotExitApp : MonoBehaviour {
	
	public GameObject SureExitPanel;
	public GameObject MenuPlanetarioPanel;
	public GameObject usuario;
	public float tiempoMaximoParaReconocerGesto = 5.0f;
	bool derechaReconocida;
	bool IzquierdaReconocida;
	bool reconociendo;
	public float velocidad;
	float tiempoMax = 5.0f;
	bool notExit = false;

	void Start () {
		Input.gyro.enabled = true;
		derechaReconocida = false;
		IzquierdaReconocida = false;
		reconociendo = true;
		velocidad = velocidad;
	}


	void Update(){
		if (!notExit) {
			if (Time.time >= tiempoMaximoParaReconocerGesto) {
				reconociendo = false;
				IzquierdaReconocida = false;
				derechaReconocida = false;
			}

			if (Input.gyro.rotationRateUnbiased.y > velocidad && !IzquierdaReconocida)
				reconociendo = true;

			if (!reconociendo)
				tiempoMaximoParaReconocerGesto = Time.time + tiempoMax;
			else {
				if (!IzquierdaReconocida && Time.time < tiempoMaximoParaReconocerGesto) {
					if (Input.gyro.rotationRateUnbiased.y > velocidad) {
						reconociendo = true;
						IzquierdaReconocida = true;
					}
				} else {
					if (Input.gyro.rotationRateUnbiased.y < -velocidad && !derechaReconocida && Time.time < tiempoMaximoParaReconocerGesto) { 
						derechaReconocida = true;
					} else {
						if (Input.gyro.rotationRateUnbiased.y > velocidad && Time.time < tiempoMaximoParaReconocerGesto && derechaReconocida) {
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
