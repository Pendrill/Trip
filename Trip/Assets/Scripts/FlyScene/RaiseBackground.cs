using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseBackground : MonoBehaviour
{
    public MoveCamera parallaxRef;
    public Transform background;
    private float _time = 0;

    private float _yTweenVal = 0;
    private float _yTweenSpeed = 2;
    private float _yMax = -5;

    private bool _yReached = false;

    // Start is called before the first frame update
    void Start()
    {
        _yTweenVal = background.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        updateTime();
        checkParallaxTime();
    }

    private void updateTime()
    {
        _time = parallaxRef.currentTime;
    }

    private void checkParallaxTime()
    {
        if (_time > 0.24)
        {
            increaseY();
        }
    }

    private void increaseY()
    {
        if (!_yReached)
        {
            if (background.position.y > _yMax)
            {
                _yTweenVal -= (Time.deltaTime * _yTweenSpeed);
                background.position = new Vector3(background.position.x, _yTweenVal, background.position.z);
            }
            else
            {
                _yReached = true;
            }
        }
    }
}
