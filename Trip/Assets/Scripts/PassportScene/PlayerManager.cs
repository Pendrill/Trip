using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerManager : MonoBehaviour
{

    public GameObject textConfirm;
    public TransitionScreenText nextSceneTransition;
    public PlayerMovementPassport playerMove;
    public MouseLook cameraMove;

    bool enableManager = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enableManager)
        {
            checkIfFacingDoor();
            checkForInteraction();
        }
    }

    void checkIfFacingDoor()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 10.0f))
        {
            if (hit.transform.tag.Equals("ExitDoor"))
            {
                activateUI();
            }
            else
            {
                deactivateUI();
            }
        }
    }

    void checkForInteraction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 10.0f))
            {
                if (hit.transform.tag.Equals("ExitDoor"))
                {
                    setUpNextScene();
                    disableMovement();
                    deactivateUI();
                    enableManager = false;
                }
                else
                {
                    Debug.Log("NOT WHERE WE WATN TO BE");
                }
            }
        }
    }

    public void enableMovement()
    {
        playerMove.enableMove();
        cameraMove.enableMove();
    }

    void disableMovement()
    {
        playerMove.disableMove();
        cameraMove.disableMove();
    }


    void activateUI()
    {
        textConfirm.SetActive(true);
    }

    void deactivateUI()
    {
        textConfirm.SetActive(false);
    }

    public void setUpNextScene()
    {
        LoadingSingleton.Loading_Instance.setNextSceneToLoad(4);
        nextSceneTransition.setCurrentState(TransitionScreenText.TextState.FadeIn);
    }

    public void LoadNextScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
