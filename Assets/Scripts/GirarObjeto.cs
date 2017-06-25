using UnityEngine;
using System.Collections;

public class GirarObjeto : MonoBehaviour {

public float girarx = 0.0f;
public float girary = 0.0f;
public float girarz = 0.0f;

[Header("Movimientos sobre el cuerpo")]
public bool girar = true; 

public void start() {

    girar = true;
}


public void Update() {

    if (girar)
        transform.Rotate(girarx, girary / 5.0f, girarz);
    
}

public void cancelarGiro(){

    girar = false;

}

public void activarGiro() {

    girar = true;

}

}
