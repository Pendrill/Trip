using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public GameObject scrollRectObject;
    ScrollRect scrollRect;

    public float distance = 500f;
    public float startingY = -3f;
  
    public float speedIncrease = 0.001f;

    private bool _moveUp = false;
    private float _currentY;

    // Start is called before the first frame update
    void Start()
    {
        scrollRect = scrollRectObject.GetComponent<ScrollRect>();
        _currentY = startingY;
    }

    // Update is called once per frame
    void Update()
    {
        if(_moveUp)
        {
            if (_currentY <= distance)
            {
                _currentY += speedIncrease;
            }
            else
            {
                _moveUp = false;
            }

            setRectPosition(_currentY);
        }

        if(_currentY >= 4.9f)
        {
            _moveUp = false;
        }
    }

    void setRectPosition(float yPos)
    {
        if(scrollRect != null)
        {
            var pos = new Vector2(0f, yPos * 100f);
            scrollRect.content.localPosition = pos;
        }
    }

    public void setMoveBool(bool activate)
    {
        _moveUp = activate;
        checkRectPosition();
    }

    void checkRectPosition()
    {
        if (_currentY != startingY)
        {
            _currentY = startingY;
            setRectPosition(startingY);
        }
    }
}
