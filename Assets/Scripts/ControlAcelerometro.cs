using UnityEngine;
using System.Collections;

public class ControlAcelerometro : MonoBehaviour {

    [Header("Objeto")]
    public GameObject ObjetoAMover;

    //private Vector3 posicionActualCamara;

    [Header("Sensibilidad")]
    public float sensibilidad =1;

    [Header("Debug Field(TextMesh)")]
    public TextMesh textMesh;

    [Header("Ejes a activar")]
    public bool posXActivada = true;
    public bool posYActivada = false;
    public bool posZActivada = true;


   

    public void setPosActualCamara(Vector3 vector) {
        Debug.Log("Seteo la posicion actual");
        //posicionActualCamara = vector;
        //posicionActualCamara = GameObject.Find("UI").GetComponent<MenuPlanetario>().getCurrentPlanetPosition();
    }
    void FixedUpdate() {
        
        /*
        Debug.Log("Posicion Actual Camara"+posicionActualCamara);
        Debug.Log("Posicion Objeto" + ObjetoAMover.transform.position);
        */
        float posX;
        float posY;
        float posZ;

        if (posXActivada)
            posX = Input.acceleration.x * sensibilidad;
        else
            posX = 0.0f;

        if (posYActivada)
            posY = Input.acceleration.y * sensibilidad;
        else
            posY = 0.0f;

        if (posZActivada)
            posZ = Input.acceleration.z * sensibilidad;
        else
            posZ = 0.0f;




        //ObjetoAMover.transform.position = new Vector3(posicionActualCamara.x + posX , cero, posicionActualCamara.z - posZ);
        ObjetoAMover.transform.position = new Vector3(ObjetoAMover.transform.position.x + posX, posY, ObjetoAMover.transform.position.z + posZ);
        //ObjetoAMover.transform.position = new Vector3(posicionActualCamara.x + 15, 0.0f, posicionActualCamara.z - Input.acceleration.z * 15);
        //GameObject.Find("Debugg").GetComponent<GUIText>().text = "Flopppiii"; NO ANDA
        //GetComponent(Debugg).text = "blah";   TAMPOCO ANDA


        //-----------------------------------------Esto anda bien
        //TextMesh t = (TextMesh)GameObject.Find("UI").GetComponent<TextMesh>(); // ANDA BIEN
        //t.text = "Pos X: " + Input.acceleration.x.ToString("F2") + " Pos Z: " + Input.acceleration.z.ToString("F2");
        //----------------------------------------------------------
        
        if (textMesh != null)
            textMesh.text = "X:" + ObjetoAMover.transform.position.x.ToString("F2") + " Z:" + ObjetoAMover.transform.position.z.ToString("F2");
        
        
        //------------------------------------------

        //gameObject.GetComponent<TextMesh>();




        //Esto es lo que tengo que lograr que ande
        //ObjetoAMover.transform.position = new Vector3(posicionActualCamara.x + Input.acceleration.x, 0, posicionActualCamara.z - Input.acceleration.z);

        //myObject.GetComponent<MyScript>().MyFunction();
	}

    void start() {

        Debug.LogWarning("Entre al control del acelerómetro.");
    }
}
