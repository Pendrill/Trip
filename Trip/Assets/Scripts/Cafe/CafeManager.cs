using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CafeManager : MonoBehaviour
{

    public GameObject cafeScene;
    public GameObject menuScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void transitionToMenu()
    {
        cafeScene.SetActive(false);
        menuScene.SetActive(true);
    }
}
