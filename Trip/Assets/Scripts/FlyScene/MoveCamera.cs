using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    private Transform camTransform;
    private Vector3 camPos;
    private float _startingTime = 0f;
    private float _currentTime;
    private float _addX;

    public bool enableMove = false;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        camTransform = GetComponent<Transform>();
        camPos = camTransform.position;
        _currentTime = _startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(enableMove)
        {
            updateXPos();
        }
       
    }

    public void updateXPos()
    {
        _currentTime += (Time.deltaTime * speed);
        _addX = _addX >= 1 ? 1 : CubicOut(_currentTime);
        camPos.x += (_addX * 1);
        camTransform.position = camPos;

    }

    public static float CubicOut(float k)
    {
        return 1f + ((k -= 1f) * k * k);
    }

    public void enableCameraMove()
    {

    }

    public float currentTime
    {
        get { return CubicOut(_currentTime); }
    }
}
