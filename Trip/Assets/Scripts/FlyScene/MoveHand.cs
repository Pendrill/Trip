using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MoveHand : MonoBehaviour
{
    //public HandManager HandManager;
    public GameObject hand;
    public static int zAxisPos = 0; //Static because other scripts may need to get this.
    private float yAxisPos = -5.23f;
    public float xAxisBoundary = 10f;
    public float yAxisBoundaryMin = -7.5f;
    public float yAxisBoundaryMax = 2f;
    public float yOffset = 0f;
    public float xOffset = 0f;
    public float speed = 10f;

    public UnityEvent action;

    bool hideHand = false;

    private bool enableHandMovement = true;

    void Update()
    {
        if(enableHandMovement)
        {
            updateMousePosition();
            checkForInteraction();
        }

        if(hideHand)
        {
            moveHandDown();
        }
    }

    void updateMousePosition()
    {
        Vector3 mouse = new Vector3(Input.mousePosition.x + xOffset, Input.mousePosition.y + yOffset, zAxisPos - Camera.main.transform.position.z);
        mouse = checkMouseBoundary(Camera.main.ScreenToWorldPoint(mouse));


        this.transform.position = new Vector3(mouse.x + xOffset, mouse.y + yOffset, zAxisPos);
    }

    Vector3 checkMouseBoundary(Vector3 pos)
    {
        if(pos.x < -xAxisBoundary)
        {
            pos.x = -xAxisBoundary;
        }
        else if( pos.x > xAxisBoundary)
        {
            pos.x = xAxisBoundary;
        }

        if(pos.y > yAxisBoundaryMax)
        {
            pos.y = yAxisBoundaryMax;
        }
        else if(pos.y < yAxisBoundaryMin)
        {
            pos.y = yAxisBoundaryMin;
        }
        return pos;
    }

    void checkForInteraction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                enableHandMovement = false;
                activateEvent();
            }
        }
    }
    public  void activateEvent()
    {
        action.Invoke();
    }

    public void enableMoveHand()
    {
        hideHand = true;
    }

    public void disableMoveHand()
    {
        hideHand = false;
    }

    

    void moveHandDown()
    {
        Debug.Log("are we here");
        if(hand.transform.position.y > -11)
        {
            hand.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y - (Time.deltaTime * 10f), hand.transform.position.z);
        }
        else
        {
            disableMoveHand();
        }
        
    }

}
