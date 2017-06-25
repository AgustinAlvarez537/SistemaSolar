using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuPlanetario : MonoBehaviour {

	enum Planets { Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune, Pluto}

    [Header("Camara")]
    public GameObject Camera;

    [Header("Planetas")]
    public GameObject Mercury;
    public GameObject Venus;
    public GameObject Earth;
    public GameObject Mars;
    public GameObject Jupiter;
    public GameObject Saturn;
    public GameObject Uranus;
    public GameObject Neptune;
    public GameObject Pluto;

    [Header("Paneles de info. de los planetas")]
    public GameObject MercuryInfoPanel;
    public GameObject VenusInfoPanel;
    public GameObject EarthInfoPanel;
    public GameObject MarsInfoPanel;
    public GameObject JupiterInfoPanel;
    public GameObject SaturnInfoPanel;
    public GameObject UranusInfoPanel;
    public GameObject NeptuneInfoPanel;
    public GameObject PlutoInfoPanel;

    [Header("Menus disponibles")]
    public GameObject MenuPlanetarioPanel;
    public GameObject SelectPlanetPanel;
    public GameObject SureExitPanel;
    public GameObject InfoPanel;

    [Header("Feedbacks")]
    public GameObject feedback;

    int currentPlanet=2;

    int cameraMoveActivated = 0; // variable que controla si te estás moviendo en el espacio con el acelerómetro o no. 0 desactivado, 1 activado

    [Header("Script Acelerometro")]
    public ControlAcelerometro acelerometro;

    //--Variables para typear como máquina de escribir
    public float letterPause = 0.2f;
    public AudioClip typeSound1;
    public AudioClip typeSound2;
    string message;
    string textComp;
    //------------------------------------------------

    public void OnInfoPressed()
    {
        MenuPlanetarioPanel.SetActive(false);
        InfoPanel.SetActive(true);
        textComp = selectPlanetInfo(currentPlanet);
        message = textComp;
        Debug.Log("message " + message);
        textComp = "";
   //--------------------------------------------------------

        StartCoroutine(TypeText());
    }

    public void OnPlanetSelectPressed()
    {
        MenuPlanetarioPanel.SetActive(false);
        SelectPlanetPanel.SetActive(true);
    }

    public void OnPlanetPressed(int Planet)
    {
        switch (Planet)
        {
            case (int)Planets.Mercury:
                currentPlanet = (int) Planets.Mercury;
                Camera.transform.position = new Vector3(Mercury.transform.position.x, 2, - (Mercury.GetComponent<SphereCollider>().radius * Mercury.transform.localScale.z) -1712.8f);
                break;
            case (int)Planets.Venus:
                currentPlanet = (int)Planets.Venus;
                Camera.transform.position = new Vector3(Venus.transform.position.x, 2, -(Venus.GetComponent<SphereCollider>().radius * Venus.transform.localScale.z) - 1712.8f);
                break;
            case (int)Planets.Earth:
                currentPlanet = (int)Planets.Earth;
                Camera.transform.position = new Vector3(Earth.transform.position.x, 2, -(Earth.GetComponent<SphereCollider>().radius * Earth.transform.localScale.z) - 1712.8f);
                break;
            case (int)Planets.Mars:
                currentPlanet = (int)Planets.Mars;
                Camera.transform.position = new Vector3(Mars.transform.position.x, 2, -(Mars.GetComponent<SphereCollider>().radius * Mars.transform.localScale.z) - 1712.8f);
                break;
            case (int)Planets.Jupiter:
                currentPlanet = (int)Planets.Jupiter;
                Camera.transform.position = new Vector3(Jupiter.transform.position.x, 2, -(Jupiter.GetComponent<SphereCollider>().radius * Jupiter.transform.localScale.z) - 1712.8f);
                break;
            case (int)Planets.Saturn:
                currentPlanet = (int)Planets.Saturn;
                Camera.transform.position = new Vector3(Saturn.transform.position.x, 2, -(Saturn.GetComponent<SphereCollider>().radius * Saturn.transform.localScale.z) - 1712.8f);
                break;
            case (int)Planets.Uranus:
                currentPlanet = (int)Planets.Uranus;
                Camera.transform.position = new Vector3(Uranus.transform.position.x, 2, -(Uranus.GetComponent<SphereCollider>().radius * Uranus.transform.localScale.z) - 1712.8f);
                break;
            case (int)Planets.Neptune:
                currentPlanet = (int)Planets.Neptune;
                Camera.transform.position = new Vector3(Neptune.transform.position.x, 2, -(Neptune.GetComponent<SphereCollider>().radius * Neptune.transform.localScale.z) - 1712.8f);
                break;
            case (int)Planets.Pluto:
                currentPlanet = (int)Planets.Pluto;
                Camera.transform.position = new Vector3(Pluto.transform.position.x, 2, -(Pluto.GetComponent<SphereCollider>().radius * Pluto.transform.localScale.z) - 1712.8f);
                break;
        }
    }

    string selectPlanetInfo(int Planet) {

        switch (Planet)
        {
            case (int)Planets.Mercury:
                return "MERCURIO\nTamaño (Diámetro): 4.880 km.\nRadio: 2.440 km.\nDistancia al Sol: 57.910.000\nLunas: 0\nPeriodo de Rotación:58,6 dias \nÓrbita: 87,97 dias\nInclinación del eje: 0,00 º\nInclinación ecuatorial	orbital: 7,00 º";
            case (int)Planets.Venus:
                return "VENUS\nTamaño (Diámetro): 12.104 km.\nRadio: 6.052 km.\nDistancia al Sol: 108.200.000\nLunas: 0\nPeriodo de Rotación:-243 dias \nÓrbita: 224,7 dias\nInclinación del eje: 177,36 º\nInclinación ecuatorial	orbital: 3,39 º";
            case (int)Planets.Earth:
                return "LA TIERRA\nTamaño (Diámetro): 12.756 km.\nRadio: 6.378 km.\nDistancia al Sol: 149.600.000\nLunas: 1\nPeriodo de Rotación:23,93 horas \nÓrbita: 365,256 dias\nInclinación del eje: 23,45 º\nInclinación ecuatorial	orbital: 0,00 º";
            case (int)Planets.Mars:
                return "MARTE\nTamaño (Diámetro): 6.794 km.\nRadio: 3.397 km.\nDistancia al Sol: 227.940.000\nLunas: 2\nPeriodo de Rotación:24,62 horas \nÓrbita: 686,98 dias\nInclinación del eje: 25,19 º\nInclinación ecuatorial	orbital: 1,85 º";
            case (int)Planets.Jupiter:
                return "JÚPITER\nTamaño (Diámetro): 142.984 km.\nRadio: 71.492 km.\nDistancia al Sol: 778.330.000\nLunas: 16\nPeriodo de Rotación:9,84 horas \nÓrbita: 11,86 años\nInclinación del eje: 3,13 º\nInclinación ecuatorial	orbital: 1,31 º";
            case (int)Planets.Saturn:
                return "SATURNO\nTamaño (Diámetro): 108.728 km.\nRadio: 60.268 km.\nDistancia al Sol: 1.429.400.000\nLunas: 18\nPeriodo de Rotación:10,23 horas \nÓrbita: 29,46 años\nInclinación del eje: 25,33 º\nInclinación ecuatorial	orbital: 2,49 º";
            case (int)Planets.Uranus:
                return "URANO\nTamaño (Diámetro): 51.118 km.\nRadio: 25.559 km.\nDistancia al Sol: 2.870.990.000\nLunas: 15\nPeriodo de Rotación:17,9 horas \nÓrbita: 84,01 años\nInclinación del eje: 97,86 º\nInclinación ecuatorial	orbital: 0,77 º";
            case (int)Planets.Neptune:
                return "NEPTUNO\nTamaño (Diámetro): 49.532 km.\nRadio: 24.746 km.\nDistancia al Sol: 4.504.300.000\nLunas: 8\nPeriodo de Rotación:16,11 horas \nÓrbita: 164,8 años\nInclinación del eje: 28,31 º\nInclinación ecuatorial	orbital: 1,77 º";
            case (int)Planets.Pluto:
                return "PLUTÓN\nTamaño (Diámetro): 2.320 km.\nRadio: 1.160 km.\nDistancia al Sol: 5.913.520.000\nLunas: 1\nPeriodo de Rotación:-6,39 días \nÓrbita: 248,54 años\nInclinación del eje: 122,72 º\nInclinación ecuatorial	orbital: 17,15 º";
                
        }
    return "ERROR, NO ENTRE EN NINGÚN PLANETA";
    }

    public Vector3 getCurrentPlanetPosition() {

        switch (currentPlanet)
        {
            case (int)Planets.Mercury:
                return new Vector3(Mercury.transform.position.x, 2, -(Mercury.GetComponent<SphereCollider>().radius * Mercury.transform.localScale.z) - 1712.8f);
            case (int)Planets.Venus:
                return new Vector3(Venus.transform.position.x, 2, -(Venus.GetComponent<SphereCollider>().radius * Venus.transform.localScale.z) - 1712.8f);
            case (int)Planets.Earth:
                {
                    Debug.Log("Entre a la tierra");
                    return new Vector3(Earth.transform.position.x, 2, -(Earth.GetComponent<SphereCollider>().radius * Earth.transform.localScale.z) - 1712.8f);
                }
            case (int)Planets.Mars:
                return new Vector3(Mars.transform.position.x, 2, -(Mars.GetComponent<SphereCollider>().radius * Mars.transform.localScale.z) - 1712.8f);
            case (int)Planets.Jupiter:
                return new Vector3(Jupiter.transform.position.x, 2, -(Jupiter.GetComponent<SphereCollider>().radius * Jupiter.transform.localScale.z) - 1712.8f);
            case (int)Planets.Saturn:
                return new Vector3(Saturn.transform.position.x, 2, -(Saturn.GetComponent<SphereCollider>().radius * Saturn.transform.localScale.z) - 1712.8f);
            case (int)Planets.Uranus:
                return new Vector3(Uranus.transform.position.x, 2, -(Uranus.GetComponent<SphereCollider>().radius * Uranus.transform.localScale.z) - 1712.8f);
            case (int)Planets.Neptune:
                return new Vector3(Neptune.transform.position.x, 2, -(Neptune.GetComponent<SphereCollider>().radius * Neptune.transform.localScale.z) - 1712.8f);
            case (int)Planets.Pluto:
                return new Vector3(Pluto.transform.position.x, 2, -(Pluto.GetComponent<SphereCollider>().radius * Pluto.transform.localScale.z) - 1712.8f);
            default:
                {
                    Debug.Log("No entré en ningún caso no se xq");
                    return new Vector3(0, 0, 0);
                }
        }
        
       
    }
    

    public void OnBackPressed()
    {
        StopAllCoroutines();
        SelectPlanetPanel.SetActive(false);
        InfoPanel.SetActive(false);
        MenuPlanetarioPanel.SetActive(true);
    }

    public void OnModPressed() 
    {
        feedback.GetComponent<TextMesh>().text = " ";
        feedback.GetComponent<TextMesh>().fontSize=30;
        feedback.transform.position = new Vector3(feedback.transform.position.x - 15, feedback.transform.position.y, feedback.transform.position.z);
        StopCoroutine(CamaraActivada(2f));
        if (cameraMoveActivated == 0)
        {
            
            Debug.Log("Activo el script para mover la cámara");
            acelerometro.setPosActualCamara(getCurrentPlanetPosition());
            acelerometro.enabled = true;
            cameraMoveActivated = 1;
            StartCoroutine(CamaraActivada(2f));
        }
        else
        {
            Debug.Log("Desactivo el script para mover la cámara");
            acelerometro.enabled = false;
            cameraMoveActivated = 0;
            StartCoroutine(CamaraDesactivada(2f));
        }
        feedback.transform.position = new Vector3(feedback.transform.position.x + 15, feedback.transform.position.y, feedback.transform.position.z);
    
    }

    public void OnExitPressed()
    {
        StopAllCoroutines();
        Application.Quit();
    }

    public void OnExitControlledPressed()
    {
        if (SureExitPanel.activeInHierarchy == true)
        {
            StopAllCoroutines();
            Application.Quit();
        }
    }
    public void OnNotExitPressed()
    {
        SureExitPanel.SetActive(false);
        MenuPlanetarioPanel.SetActive(true);
    }

    public void OnNotExitControlledPressed()
    {
        if (SureExitPanel.activeInHierarchy == true)
        {
            SureExitPanel.SetActive(false);
            MenuPlanetarioPanel.SetActive(true);
        }
    }

    public void SureExit()
    {
        MenuPlanetarioPanel.SetActive(false);
        SureExitPanel.SetActive(true);
    }



    void start() {
        currentPlanet = (int)Planets.Earth;
        currentPlanet = 5;


    
    }

    public void nextPlanet() {

        if (currentPlanet != 8)
            currentPlanet = currentPlanet + 1;
        else
            currentPlanet = 0;
        OnPlanetPressed(currentPlanet);
    }

    public void previousPlanet()
    {
        if (currentPlanet != 0)
            currentPlanet = currentPlanet - 1;
        else
            currentPlanet = 8;
        OnPlanetPressed(currentPlanet);

    }

    IEnumerator CamaraActivada(float tiempo)
    {
        
        feedback.GetComponent<TextMesh>().text = "Movimiento activado";
        yield return new WaitForSeconds(tiempo);
        StartCoroutine(Fade(0.25f));
    }

    IEnumerator CamaraDesactivada(float tiempo)
    {
        feedback.GetComponent<TextMesh>().text = "Movimiento desactivado";
        yield return new WaitForSeconds(tiempo);
        StartCoroutine(Fade(0.25f));
    }

    IEnumerator Fade(float tiempito)
    {
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = feedback.GetComponent<Renderer>().material.color;
            c.a = f;
            feedback.GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(tiempito);
        }
        feedback.GetComponent<TextMesh>().text = "";
    }

    IEnumerator TypeText()
    {
        if (GameObject.Find("Audio Source(Teclas)")!=null)
            GameObject.Find("Audio Source(Teclas)").GetComponent<AudioSource>().mute = false;
        GameObject.Find("InfoText").GetComponent<TextMesh>().text = "";
        Debug.Log("message " + message);
        foreach (char letter in message)
        {
            textComp += letter+"";
            GameObject.Find("InfoText").GetComponent<TextMesh>().text = textComp;
            if (typeSound1 && typeSound2)
                SoundManager.instance.RandomizeSfx(typeSound1, typeSound2);
            yield return 0;
            yield return new WaitForSeconds(letterPause);
        }
        GameObject.Find("Audio Source(Teclas)").GetComponent<AudioSource>().mute = true;
    }


}
