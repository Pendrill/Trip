using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExploreManager : MonoBehaviour
{
    public GameObject coupleManager;
    public GameObject[] backgrounds;
    int currentIndex, tempIndex = 0;
    public TransitionScreenText transitionScene;
    // Start is called before the first frame update
    void Start()
    {
        manageBackground(true, 0);
    }

    // Update is called once per frame
    void Update()
    {
        changeBackground();
    }

    void changeBackground()
    {
        if (tempIndex != currentIndex && tempIndex < backgrounds.Length)
        {
            currentIndex = tempIndex;
            manageBackground(false, currentIndex - 1);
            manageBackground(true, currentIndex);
        }
    }

    void manageBackground(bool activate, int index)
    {
        backgrounds[index].SetActive(activate);
    }

    public void increaseIndex()
    {
        tempIndex += 1;
    }

    public bool checkForMaxIndex()
    {
        return tempIndex < backgrounds.Length;
    }

    public void enableCoupleManager()
    {
        coupleManager.SetActive(true);
    }

    public void reachedEnd()
    {
        LoadingSingleton.Loading_Instance.setNextSceneToLoad(7);
        transitionScene.setCurrentState(TransitionScreenText.TextState.FadeIn);
    }

    public void LoadNextScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
