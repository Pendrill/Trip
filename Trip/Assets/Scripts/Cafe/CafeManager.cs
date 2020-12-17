using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CafeManager : MonoBehaviour
{

    public GameObject cafeScene;
    public GameObject menuScene;
    public GameObject menuItem;
    public MenuOption[] itemsOnMenu;
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

    public void activateMenuItem()
    {
        this.menuItem.SetActive(true);
    }

    public void LoadNextScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void disableMenuItems()
    {
        for(int i = 0; i < itemsOnMenu.Length; i++)
        {
            itemsOnMenu[i].disableFunctionality();
        }
    }
}
