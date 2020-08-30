using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Credits : MonoBehaviour
{
    public GameObject scrollRectObject;
    ScrollRect scrollRect;

    public float distance = 500f;
    public float currentY = -552f;
    public float speedIncrease = 0.001f;

    private bool _moveUp = false;

    // Start is called before the first frame update
    void Start()
    {
        scrollRect = scrollRectObject.GetComponent<ScrollRect>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_moveUp)
        {
            if (currentY <= distance)
            {
                currentY += speedIncrease;
            }
            else
            {
                _moveUp = false;
            }

            var pos = new Vector2(0f, currentY * 100f);
            scrollRect.content.localPosition = pos;
        }
    }

    public void setMoveBool(bool activate)
    {
        _moveUp = activate;
    }
}
