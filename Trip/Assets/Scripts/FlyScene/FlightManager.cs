using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlightManager : MonoBehaviour
{
    public GameObject gameCamera;
    public GameObject flyingSequence;
    public GameObject handManager;
    public MoveCamera cameraScript;
    public MoveCamera planeScript;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startFlying()
    {
        cameraScript.enableCameraMove();
        planeScript.enableCameraMove();
    }

    public void activateHandManager()
    {
        cameraScript.disableCameraMove();
        _resetCamera();
        _disableFlying();
        handManager.SetActive(true);

    }

    void _resetCamera()
    {
        gameCamera.transform.position = new Vector3(0, 1, -10);
    }

    void _disableFlying()
    {
        flyingSequence.SetActive(false);
    }

    public void LoadNextScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
