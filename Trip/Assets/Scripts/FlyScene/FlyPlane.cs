using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPlane : MonoBehaviour
{
    public MoveCamera parallaxRef;
    public Transform plane;
    private float _time = 0;

    private float _yTweenVal = 0;
    private float _yTweenSpeed = 2;
    private float _yMax = 9;

    private float _rotTweenVal = 0;
    private float _rotTweenSpeed = 8;
    private float _rotMax = 45;

    private bool _yReached = false;
    private bool _rotReached = false;

    // Start is called before the first frame update
    void Start()
    {
        _yTweenVal = plane.position.y;
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
        if(_time > 0.2)
        {
            increaseRotation();
        }

        if(_time > 0.21)
        {
            increaseY();
        }
    }

    private void increaseY()
    {
        if(!_yReached)
        {
            if (plane.position.y < _yMax)
            {
                _yTweenVal += (Time.deltaTime * _yTweenSpeed);
                plane.position = new Vector3(plane.position.x, _yTweenVal, plane.position.z);
            }
            else
            {
                _yReached = true;
            }
        }
    }

    private void increaseRotation()
    {
        if(!_rotReached)
        {
            if (plane.rotation.z < 0.07)
            {
                _rotTweenVal += (Time.deltaTime * _rotTweenSpeed);
                plane.rotation = Quaternion.Euler(plane.rotation.x, plane.rotation.y, _rotTweenVal);

            }
            else
            {
                _rotReached = true;
            }
        }
        else
        {

        }
        
    }
}
