using UnityEngine;
using System.Collections;

public class CamSwitchController : MonoBehaviour
{


    public Camera maincamera;
    public Camera YellowCubeCamera;


    private Camera[] cameras;
    private int currentCameraIndex = 0;
    private Camera currentCamera;

    // Use this for initialization
    void Start()
    {
        cameras = new Camera[] { maincamera, YellowCubeCamera };//this is the array of cameras
        currentCamera = maincamera; //When the program start the main camera is selected as the default camera
    }

    // Update is called once per frame
    void Update()
    {
        //Cardboard.SDK.OnTrigger = ChangeView();
       /* if (Input.GetKeyDown("s"))
        {
            currentCameraIndex++;
            if (currentCameraIndex > cameras.Length - 1)
                currentCameraIndex = 0;*/
        /*if (Cardboard.SDK.Triggered)
        {
            currentCameraIndex++;
            if (currentCameraIndex > cameras.Length - 1)
                currentCameraIndex = 0;
            ChangeView();
        }*/
       /* }*/
        /*
        if (Input.GetKeyDown("s"))
        {
            currentCameraIndex++;
            if (currentCameraIndex > cameras.Length - 1)
                currentCameraIndex = 0;
            ChangeView();
        }*/
        
    }

    public void ChangeView()
    {
        currentCameraIndex++;
        if (currentCameraIndex > cameras.Length - 1)
            currentCameraIndex = 0;
        currentCamera.enabled = false;
        currentCamera = cameras[currentCameraIndex];
        currentCamera.enabled = true;
    }
}