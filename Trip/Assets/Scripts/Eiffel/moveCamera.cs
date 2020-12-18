using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moveCamera : MonoBehaviour
{
    public float speed = 1f;
    bool enableAction = false;
    float delayTimer = 0f;
    public float reachedDelayTimer = 3f;
    bool waitingForTimer = true;
    bool canCameraMove = true;

    float startingY = 1.03f;
    float cameraMaxY = 21.5f;
    public TransitionScreenText transitionScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!enableAction) return;

        if(waitingForTimer)
        {
            increaseDelayTimer();
        }
        else
        {
            moveCameraUp();
        }
    }

    void increaseDelayTimer()
    {
        delayTimer += Time.deltaTime;
        if (delayTimer >= reachedDelayTimer)
        {
            waitingForTimer = false;
        }
    }

    public void canStart()
    {
        enableAction = true;
    }

    void moveCameraUp()
    {
        if(canCameraMove)
        {
            startingY += (Time.deltaTime * speed);
            if(startingY < cameraMaxY)
            {
                transform.position = new Vector3(transform.position.x, startingY, transform.position.z);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, cameraMaxY, transform.position.z);
                reachedEnd();
            }
        }
    }

    public void disableCameraMove()
    {
        canCameraMove = false;
    }

    public void reachedEnd()
    {
        canCameraMove = false;
        LoadingSingleton.Loading_Instance.setNextSceneToLoad(0);
        transitionScene.setCurrentState(TransitionScreenText.TextState.FadeIn);
    }

    public void LoadNextScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
