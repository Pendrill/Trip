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
    Vector3 startinPosition;


    // Start is called before the first frame update
    void Start()
    {
        background = GameObject.Find("/Canvas/Background").GetComponent<RectTransform>();
        setRectTransform();
        determineImages();
        determineScales();
        determinePositions();
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

    void determineScales()
    {
        startingSide = Random.Range(50, 150);
        endingSide = Random.Range(100, 200);

        peonyRectTransform.sizeDelta = new Vector2(startingSide, startingSide);
    }

    void determinePositions()
    {
        Vector2 backgroundSize = new Vector2(background.rect.width, background.rect.height);
        int randX = (int)Random.Range((backgroundSize.x / -2), backgroundSize.x / 2);
        int randY = (int)Random.Range((backgroundSize.y / -2), backgroundSize.y / 2);

        peonyRectTransform.localPosition = new Vector3(randX, randY, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
