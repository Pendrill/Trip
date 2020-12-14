using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacedPassport : MonoBehaviour
{
    public GameObject passport;
    bool canMovePassport = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canMovePassport)
        {
            movePassportUp();
        }
    }

    public void enablePassportMove()
    {
        canMovePassport = true;
    }

    public void disablePassportMove()
    {
        canMovePassport = false;
    }


    void movePassportUp()
    {
        if (passport.transform.position.y < 9.5)
        {
            passport.transform.position = new Vector3(passport.transform.position.x, passport.transform.position.y + (Time.deltaTime * 10f), passport.transform.position.z);
        }
        else
        {
            disablePassportMove();
        }

    }
}
