using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandManager : MonoBehaviour
{
    public GameObject initialHands;
    public GameObject heldHands;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transitionHands()
    {
        disableInitialHands();
        enableHeldHands();
    }

    public void disableInitialHands()
    {
        initialHands.SetActive(false);
    }

    public void enableHeldHands()
    {
        heldHands.SetActive(true);
    }
}
