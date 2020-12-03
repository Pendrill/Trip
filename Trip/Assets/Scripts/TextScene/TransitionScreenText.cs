using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransitionScreenText : MonoBehaviour
{
    public enum TextState { Wait, Type, ResetTimer, Complete, Reset };
    public TextState currentTextState;

    float lastStateChange = 0.0f; //tracks time that has passed since the last state change

    public float waitTime = 1.0f;
    public string testString = "this is a test string";
    string currentTextString = "";
    int index = 0;

    public Text textObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkTextState();
    }

    public void checkTextState()
    {
        switch (currentTextState)
        {
            case TextState.Wait:

                break;

            case TextState.Type:
                displayText();
                break;

            case TextState.ResetTimer:
                setCurrentState(TextState.Type);
                break;

            case TextState.Complete:

                break;

            case TextState.Reset:
                resetString();
                break;
        }

    }

    public void displayText()
    {
        Debug.Log(getStateElapsed());
        if (this.currentTextString.Length >= testString.Length)
        {
            currentTextString = testString;
            textObject.text = currentTextString;
            setCurrentState(TextState.Complete);
        }
        else
        {
            if (getStateElapsed() > waitTime)
            {
                Debug.Log("do we get here");
                currentTextString += testString[index];
                index += 1;
                textObject.text = currentTextString;
                setCurrentState(TextState.ResetTimer);
            }
        }
        
    }

    /// <summary>
    /// sets the current state of the game manager
    /// </summary>
    /// <param name="state"></param>
    public void setCurrentState(TextState state)
    {
        //update the state and the time since the state has been changes
        currentTextState = state;
        lastStateChange = Time.time;
    }

    /// <summary>
    /// returns the amount of time that has passed since the last state change
    /// </summary>
    /// <returns></returns>
    float getStateElapsed()
    {
        return Time.time - lastStateChange; //return time since the last change in state
    }

    void resetString()
    {
        currentTextString = "";
        index = 0;
        textObject.text = "";
        setCurrentState(TextState.Type);
    }
}
