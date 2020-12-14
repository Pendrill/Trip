using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPassport : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;
    bool canMove = true;
    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            moveCharacter();
        }
    }

    void moveCharacter()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    public void disableMove()
    {
        canMove = false;
    }

    public void enableMove()
    {
        canMove = true;
    }
}
