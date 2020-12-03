using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHand : MonoBehaviour
{
    public HandManager HandManager;
    public static int zAxisPos = 0; //Static because other scripts may need to get this.
    private float yAxisPos = -5.23f;
    public float xAxisBoundary = 10f;
    public float yAxisBoundaryMin = -7.5f;
    public float yAxisBoundaryMax = 2f;
    public float speed = 10f;

    private bool enableHandMovement = true;

    void Update()
    {
        if(enableHandMovement)
        {
            updateMousePosition();
            checkForInteraction();
        }
    }

    void updateMousePosition()
    {
        Vector3 mouse = new Vector3(Input.mousePosition.x, Input.mousePosition.y, zAxisPos - Camera.main.transform.position.z);
        mouse = checkMouseBoundary(Camera.main.ScreenToWorldPoint(mouse));


        this.transform.position = new Vector3(mouse.x, mouse.y, zAxisPos);
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
                holdHands();
            }
        }
    }

    void holdHands()
    {
        HandManager.transitionHands();
    }

}
