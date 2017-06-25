using UnityEngine;
using System.Collections;

public class GyroController : MonoBehaviour {

    public GameObject debugInfo;
    public GameObject gestos;

	private float xMax = 0f;
	private float yMax = 0f;
	private float zMax = 0f;
	private float xMin = 0f;
	private float yMin = 0f;
	private float zMin = 0f;
	// Use this for initialization
	void Start () {
        Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        Quaternion transQuat;
        if (Input.gyro.enabled){

			if (xMax < Input.gyro.rotationRateUnbiased.x) xMax = Input.gyro.rotationRateUnbiased.x;
			if (yMax < Input.gyro.rotationRateUnbiased.y) yMax = Input.gyro.rotationRateUnbiased.y;
			if (zMax < Input.gyro.rotationRateUnbiased.z) zMax = Input.gyro.rotationRateUnbiased.z;

			if (xMin > Input.gyro.rotationRateUnbiased.x) xMin = Input.gyro.rotationRateUnbiased.x;
			if (yMin > Input.gyro.rotationRateUnbiased.y) yMin = Input.gyro.rotationRateUnbiased.y;
			if (zMin > Input.gyro.rotationRateUnbiased.z) zMin = Input.gyro.rotationRateUnbiased.z;

			debugInfo.GetComponent<TextMesh> ().text = // "Gravedad: " +Input.gyro.gravity +
			// "\nAceleración del usuario:" + Input.gyro.userAcceleration + // cuanto acelera en x, cuanto acelera en y y cuanto acelera en z
			// "\nMagnitud de la rotación:" + Input.gyro.rotationRate.magnitude + // para mi es un valor que te indica que tan rápido se está rotando
			// "\nRotation Rate:" + Input.gyro.rotationRate +
				"\nMax Rotation Rate Unbiased:(" + xMax + "," + yMax + "," + zMax + ")" + "\nMin Rotation Rate Unbiased:(" + xMin + "," + yMin + "," + zMin + ")" +
			"\nRotation Rate Unbiased:" + Input.gyro.rotationRateUnbiased +
			"\nRotation Rate Unbiased:(" + Input.gyro.rotationRateUnbiased.x + "," + Input.gyro.rotationRateUnbiased.y + "," + Input.gyro.rotationRateUnbiased.z + ")"; 
                                                     //"\nX:" + Input.gyro.attitude.x+
                                                     //"\nY:" + Input.gyro.attitude.y+
                                                    // "\nZ:" + Input.gyro.attitude.z+
                                                    // "\nW:" + Input.gyro.attitude.w+
                                                    // "\nTime:"+Time.time+
                                                    // "\nTime:" + (Time.time + 5.0);
            
            transQuat = new Quaternion(Input.gyro.attitude.x, Input.gyro.attitude.y,
                                         -Input.gyro.attitude.z, -Input.gyro.attitude.w);
            gameObject.transform.rotation = Quaternion.Euler (90, 0, 0) * transQuat;
            //debugInfo.GetComponent<TextMesh>().text = debugInfo.GetComponent<TextMesh>().text + "\ntransQuat = " + transQuat.eulerAngles.ToString();

           /* if ( Input.gyro.rotationRateUnbiased.y < -1.5)
                gestos.GetComponent<TextMesh>().text = "Derecha";
            else
                if (Input.gyro.rotationRateUnbiased.y > 1.5)
                    gestos.GetComponent<TextMesh>().text = "Izquierda";
                else
                    gestos.GetComponent<TextMesh>().text = "nada" + "\nTime:" + Time.time +
                                                     "\nTime:" + (Time.time + 5.0);*/
        }else
            Input.gyro.enabled = true;

        

	}


    public void NoReconocido() {

        debugInfo.GetComponent<TextMesh>().text = "NOOOOOOO!!!!";
        StartCoroutine(Esperar(5.0f));
        
    }

    public void YesReconocido()
    {
        debugInfo.GetComponent<TextMesh>().text = "YESSSSSS!!!!";
        StartCoroutine(Esperar(5.0f));
    }
    IEnumerator Esperar(float tiempo)
    {
        
        yield return new WaitForSeconds(tiempo);
        debugInfo.GetComponent<TextMesh>().text = "En Espera de otro";
    }

    IEnumerator DispositivoCentrado(float tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        StartCoroutine("d");

    }




}
