using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Peony : MonoBehaviour
{
    public Sprite[] peony_sprites;
    RectTransform background;
    Image peony_image;

    RectTransform peonyRectTransform;

    float startingSide, endingSide;
    float startingRotation, endingRotation, rotationOffset;
    float startingAlpha, endingAlpha, currentAlpha;

    float alphaTime, sizeTime;
    enum AlphaState { increase, peak, decrease, end};
    AlphaState currentAlphaState = AlphaState.increase; 



    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.Find("/Canvas/Background").GetComponent<RectTransform>();
        setRectTransform();
        determineImages();
        setImageAlpha();
        determineScales();
        determinePositions();
        determineRotations();
    }

    void setRectTransform()
    {
        peonyRectTransform = GetComponent<RectTransform>();
    }

    void determineImages()
    {
        peony_image = GetComponent<Image>();
        peony_image.sprite = peony_sprites[Random.Range(0, peony_sprites.Length)];
    }

    void setImageAlpha()
    {
        startingAlpha = 0;
        endingAlpha = 1;
        currentAlpha = startingAlpha;
        alphaTime = 0f;
        changeImageAlpha(startingAlpha);
    }

    void determineScales()
    {
        startingSide = Random.Range(50, 150);
        endingSide = Random.Range(100, 400);
        sizeTime = 0f;

        setImageSize(startingSide);
    }

    void determinePositions()
    {
        Vector2 backgroundSize = new Vector2(background.rect.width, background.rect.height);
        int randX = (int)Random.Range((backgroundSize.x / -2), backgroundSize.x / 2);
        int randY = (int)Random.Range((backgroundSize.y / -2), backgroundSize.y / 2);

        peonyRectTransform.localPosition = new Vector3(randX, randY, 0);
    }

    void determineRotations()
    {
        startingRotation = Random.Range(0, 360);
        rotationOffset = Random.Range(-180, 180);
        endingRotation = startingRotation + rotationOffset;
    }

    // Update is called once per frame
    void Update()
    {
        updateImageAlpha();
        increaseImageSize();
        updateImageRotation();
    }

    //UPDATE THE ALPHA OF THE IMAGE
    void updateImageAlpha()
    {
        switch(currentAlphaState)
        {
            case AlphaState.increase:
                _increaseImageAlpha();
                break;
            case AlphaState.peak:
                alphaTime = 0f;
                updateAlphaState(AlphaState.decrease);
                break;
            case AlphaState.decrease:
                _decreaseImageAlpha();
                break;
            case AlphaState.end:
                endPeony();
                break;
        }
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
            updateAlphaState(AlphaState.peak);
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
            updateAlphaState(AlphaState.end);
        }
    }

    void changeImageAlpha(float newAlpha)
    {
        Color tempColor = peony_image.color;
        tempColor.a = newAlpha;
        peony_image.color = tempColor;
    }

    void updateAlphaState(AlphaState state)
    {
        currentAlphaState = state;
    }

    //UPDATE THE SIZE OF THE IMAGE

    void increaseImageSize()
    {
        sizeTime += (0.5f * Time.deltaTime) / 2;
        float side = Mathf.Lerp(startingSide, endingSide, sizeTime);
        setImageSize(side);
    }

    void setImageSize(float sideLength)
    {
        peonyRectTransform.sizeDelta = new Vector2(sideLength, sideLength);
    }

    //UPDATE THE ROTATION OF THE IMAGE
    void updateImageRotation()
    {
        float side = Mathf.Lerp(startingRotation, endingRotation, sizeTime);
        setImageRotation(side);
    }

    void setImageRotation(float rotation)
    {
        Vector3 tempRot = peonyRectTransform.eulerAngles;
        tempRot.z = rotation;
        peonyRectTransform.eulerAngles = tempRot;
    }

    //ALL ANIMATIONS ARE DONE
    void endPeony()
    {
        Destroy(this.gameObject);
    }
}
