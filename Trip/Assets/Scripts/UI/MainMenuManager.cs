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
}
