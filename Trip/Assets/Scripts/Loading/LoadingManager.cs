﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [SerializeField]
    private Slider _progressBar;
    int key = 0;
    float timer = 0;
    bool timerGoing = true;
    // Start is called before the first frame update
    void Start()
    {
        //start async operation
        key = LoadingSingleton.Loading_Instance.getNextSceneToLoad();
    }

    // Update is called once per frame
    void Update()
    {
        if(timerGoing)
        {
            timer += Time.deltaTime;
            if (timer > 3.0f )
            {
                StartCoroutine(LoadAsyncOperation());
                timerGoing = false;
            }
        }
       
    }

    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation gameLevel = SceneManager.LoadSceneAsync(key);
        while(gameLevel.progress < 1)
        {
            _progressBar.value = gameLevel.progress;
            yield return new WaitForEndOfFrame();
        }
    }
}
