using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TransitionScreenText : MonoBehaviour
{
    public enum TextState { Wait, Type, ResetTimer, Complete, WaitForCompletedAction, Reset, FadeIn, FadeOut, };
    public TextState currentTextState;

    float lastStateChange = 0.0f; //tracks time that has passed since the last state change

    public float waitTime = 1.0f;
    public string testString = "this is a test string";

    string currentTextString = "";
    int index = 0;
    string colorRichText = "";

    public bool alphaDisplay = true;

    public Text textObject;
    public Image backgroundImage;
    public GameObject blinker;

    public bool fadeOutAction = true;

    int indexAlpha = 0;
    string alphaText = "";

    float alphaTime = 0.0f;
    float startingAlpha = 0f;
    float endingAlpha = 1f;

    public UnityEvent action;

    // Start is called before the first frame update
    void Start()
    {
        colorRichText = getTextColor();
        alphaText = colorRichText + testString + "</color>";
        textObject.text = alphaText;
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
                if(alphaDisplay)
                {                    
                    displayTextAlpha();
                }
                else
                {
                    displayText();
                }
                
                break;

            case TextState.ResetTimer:
                setCurrentState(TextState.Type);
                break;

            case TextState.Complete:
                activateBlinker();
                setCurrentState(TextState.WaitForCompletedAction);
                break;

            case TextState.WaitForCompletedAction:
                waitForClick();
                break;

            case TextState.Reset:
                resetString();
                break;

            case TextState.FadeIn:
                _increaseImageAlpha();
                break;

            case TextState.FadeOut:
                action.Invoke();
                if(fadeOutAction)
                {
                    _decreaseImageAlpha();
                }
                else
                {
                    setCurrentState(TextState.Wait);
                }
               
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

    public void displayTextAlpha()
    {
        //ColorUtility.ToHtmlStringRGBA( myColor )
       
        if( indexAlpha >= testString.Length)
        {
            currentTextString = testString;
            textObject.text = currentTextString;
            setCurrentState(TextState.Complete);
        }
        else
        {
            if (getStateElapsed() > waitTime)
            {

                char nextChar = alphaText[colorRichText.Length + indexAlpha];
                alphaText = alphaText.Remove(colorRichText.Length + indexAlpha, 1);
                alphaText = alphaText.Insert(indexAlpha, nextChar.ToString());
                textObject.text = alphaText;
                indexAlpha += 1;
                setCurrentState(TextState.ResetTimer);
            }
               
        }


    }

    public string getTextColor()
    {
        return "<color=#" + ColorUtility.ToHtmlStringRGB(textObject.color) + "00>";
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

    void activateTyping()
    {
        setCurrentState(TextState.Type);
    }

    void activateFadeIn()
    {
        setCurrentState(TextState.FadeIn);
    }

    void activateFadeOut()
    {
        setCurrentState(TextState.FadeOut);
    }

    void _increaseImageAlpha()
    {
        alphaTime += 0.5f * Time.deltaTime;
        if (alphaTime < 1f)
        {
            float alpha = Mathf.Lerp(startingAlpha, endingAlpha, alphaTime);
            changeImageAlpha(alpha);
        }
        else
        {
            changeImageAlpha(endingAlpha);
            alphaTime = 0;
            activateTyping();
        }

    }

    void _decreaseImageAlpha()
    {
        alphaTime += 0.5f * Time.deltaTime;
        if (alphaTime < 1f)
        {
            float alpha = Mathf.Lerp(endingAlpha, startingAlpha, alphaTime);
            changeImageAlpha(alpha);
        }
        else
        {
            changeImageAlpha(startingAlpha);
            alphaTime = 0;
            setCurrentState(TextState.Wait);
        }
    }

    void changeImageAlpha(float newAlpha)
    {
        Color tempColor = backgroundImage.color;
        tempColor.a = newAlpha;
        backgroundImage.color = tempColor;
    }

    void waitForClick()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            disableBlinker();
            textObject.gameObject.SetActive(false);
            setCurrentState(TextState.FadeOut);
        }
    }

    void activateBlinker()
    {
        blinker.SetActive(true);
    }

    void disableBlinker()
    {
        blinker.SetActive(false);
    }

    public void updateString(string newString)
    {
        testString = newString;
        alphaText = colorRichText + testString + "</color>";
    }
}
