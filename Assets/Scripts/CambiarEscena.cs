using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour {
    public GameObject Desactivar;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
       
	}

    public void cambiarEscena() {
        Desactivar.SetActive(false);
        //Application.LoadLevelAdditive("EarthScene");
        SceneManager.LoadScene("EarthScene");
    }
}
