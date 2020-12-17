using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuOption : MonoBehaviour
{
    // public UnityEvent action;
    public CafeManager cafeManager;
    public GameObject highlight;
    public TransitionScreenText transitionScene;
    public string drinkName;
    string objectTag;
    bool disableMouse;
    // Start is called before the first frame update
    void Start()
    {
        objectTag = transform.GetChild(0).transform.tag;
        drinkName += "... That's a good choice! \n Enjoy honey.";
    }

    // Update is called once per frame
    void Update()
    {
        if(!disableMouse)
        {
            checkMouseOverMenu();
            checkForInteraction();
        }
        
    }

    void checkMouseOverMenu()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if(hit.transform.tag == objectTag)
            {
                activateOutline();
            }
            else
            {
                deactivateOutline();
            }
            
        }
        else
        {
            deactivateOutline();
        }
    }

    void checkForInteraction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if(hit.transform.tag == objectTag)
                {
                    activateEvent();
                }
            }
        }
    }

    public void activateEvent()
    {
        //action.Invoke();
        cafeManager.disableMenuItems();
        transitionScene.updateString(drinkName);
        LoadingSingleton.Loading_Instance.setNextSceneToLoad(6);
        transitionScene.setCurrentState(TransitionScreenText.TextState.FadeIn);

    }

    void activateOutline()
    {
        this.highlight.SetActive(true);
    }

    void deactivateOutline()
    {
        this.highlight.SetActive(false);
    }

    public void disableFunctionality()
    {
        disableMouse = true;
        deactivateOutline();
    }
}
