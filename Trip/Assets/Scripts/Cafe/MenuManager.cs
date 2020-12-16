using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MenuManager : MonoBehaviour
{
    public GameObject menuHighlight;
    public UnityEvent action;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        checkMouseOverMenu();
        checkForInteraction();
    }

    void checkMouseOverMenu()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            activateMenuOutline();
        }
        else
        {
            deactivateMenuOutline();
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
                activateEvent();
            }
        }
    }

    public void activateEvent()
    {
        action.Invoke();
    }

    void activateMenuOutline()
    {
        menuHighlight.SetActive(true);
    }

    void deactivateMenuOutline()
    {
        menuHighlight.SetActive(false);
    }
}
