using UnityEngine;
using System.Collections;

public class CamMoveScript : MonoBehaviour
{


    public GameObject currentCamera;

    public enum Planets { Mercury, Venus, Earth, Mars, Jupiter, Saturn, Uranus, Neptune, Pluto };

    // Use this for initialization
    void Start()
    {
        
    }

    public void ChangeView(int planet)
    {
        switch(planet)
        {
            case (int)Planets.Mercury:
                //maincamera.transform.position = new Vector3(GameObject.Find("Mercury").transform.position.x, maincamera.transform.position.y, maincamera.transform.position.z);
                break;
            case (int)Planets.Venus:
                break;
            case (int)Planets.Earth:
                break;
            case (int)Planets.Mars:
                break;
            case (int)Planets.Jupiter:
                break;
            case (int)Planets.Saturn:
                break;
            case (int)Planets.Uranus:
                break;
            case (int)Planets.Neptune:
                break;
            case (int)Planets.Pluto:
                break;

        };
    }
}