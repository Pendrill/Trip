using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject MenuPanel;
    public GameObject CreditsPanel;

    private Credits _creditsScript;

    // Start is called before the first frame update
    void Start()
    {
        _creditsScript = CreditsPanel.GetComponent<Credits>();
        CreditsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateCredits()
    {
        CreditsPanel.SetActive(true);
        enableMovingCredits();
    }

    void enableMovingCredits()
    {
        _creditsScript.setMoveBool(true);
    }

    public void DisableCredit()
    {
        disableMovingCredits();
        CreditsPanel.SetActive(false);
       
    }

    void disableMovingCredits()
    {
        _creditsScript.setMoveBool(false);
    }
}
