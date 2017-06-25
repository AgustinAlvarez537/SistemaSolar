using UnityEngine;
using System.Collections;

public class DebugComponent : MonoBehaviour {

    [Header("Debug Field(TextMesh)")]
    public TextMesh textMesh;

    [Header("Mensaje a Mostrar")]
    public string mensaje;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

       
            //textMesh.text = "Funciona el tilt a la derecha";
	}

    public void MostrarMensaje() {

        if (textMesh != null)
            textMesh.text = mensaje;
        else
            Debug.Log("no hay mensaje que mostrar en el script DebugComponent");
    
    }

}
