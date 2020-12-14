using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassportManager : MonoBehaviour
{

    public GameObject heldPassport;
    public GameObject placedPassport;
    public MoveHand hand;
    public PlacedPassport passport;

    bool initiateTimer = false;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(initiateTimer)
        {
            timer += Time.deltaTime;
            if(timer > 0.5f)
            {
                initiateTimer = false;
                transitionToNextScreen();
            }
        }
    }

    public void passportPlaced()
    {
        disableHeld();
        enablePlaced();
        hand.enableMoveHand();
        passport.enablePassportMove();

        initiateTimer = true;
    }

    void disableHeld()
    {
        heldPassport.SetActive(false);
    }

    void enablePlaced()
    {
        placedPassport.SetActive(true);
    }

    void transitionToNextScreen()
    {
        LoadingSingleton.Loading_Instance.setNextSceneToLoad(2);
        Debug.Log("TRANSITION TIME");
        //nextSceneTransition.setCurrentState(TransitionScreenText.TextState.FadeIn);
    }

    public void LoadNextScene(int sceneNumber)
    {
        //SceneManager.LoadScene(sceneNumber);
    }


}
