using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleManager : MonoBehaviour
{
    public GameObject Couple;
    public GameObject Aleksei;
    public GameObject Michelle;
    public ExploreManager exploreManager;
    SpriteRenderer AlSprite;
    SpriteRenderer MiSprite;
    Vector3 coupleOgPos;

    Animator alekseiAnimator;
    Animator michelleAnimator;

    float walkingSpeed = 0.05f;

    bool enableMove = true;
    
    // Start is called before the first frame update
    void Start()
    {
        coupleOgPos = Couple.transform.position;
        AlSprite = Aleksei.GetComponent<SpriteRenderer>();
        MiSprite = Michelle.GetComponent<SpriteRenderer>();
        alekseiAnimator = Aleksei.GetComponent<Animator>();
        michelleAnimator = Michelle.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enableMove)
        {
            moveCouple();
        }
        
    }

    void moveCouple()
    {
        Vector3 couplePos = Couple.transform.position;

        if(Input.GetKey(KeyCode.LeftShift))
        {
            walkingSpeed = 0.1f;
        }
        else
        {
            walkingSpeed = 0.05f;
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            if (AlSprite.flipX)
            {
                AlSprite.flipX = false;
                MiSprite.flipX = false;
            }
            //float newPos = capPos(couplePos.x + walkingSpeed);
            alekseiAnimator.SetBool("isRunning", true);
            michelleAnimator.SetBool("isRunning", true);
            Couple.transform.position = new Vector3(couplePos.x + walkingSpeed, couplePos.y, couplePos.z);
            checkEnd(Couple.transform.position.x);
        }
        else if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            if(!AlSprite.flipX)
            {
                AlSprite.flipX = true;
                MiSprite.flipX = true;
            }
            float newPos = capPos(couplePos.x - walkingSpeed);
            if(newPos != -2.5)
            {
                alekseiAnimator.SetBool("isRunning", true);
                michelleAnimator.SetBool("isRunning", true);
            }
            else
            {
                alekseiAnimator.SetBool("isRunning", false);
                michelleAnimator.SetBool("isRunning", false);

            }
            Couple.transform.position = new Vector3(newPos, couplePos.y, couplePos.z);
        }
        else
        {
            alekseiAnimator.SetBool("isRunning", false);
            michelleAnimator.SetBool("isRunning", false);
        }
    }

    float capPos(float position)
    {
        float newPos;
        if (position < -2.5f)
        {
            newPos = -2.5f;
        }
        else
        {
            newPos = position;
        }
        return newPos;
    }

    void checkEnd(float position)
    {
        if(position > 19f)
        {
            exploreManager.increaseIndex();
            if (!exploreManager.checkForMaxIndex())
            {
                reachedEnd();
            }
            else
            {
                resetCouple();
            }
        }
       
    }

    void resetCouple()
    {
        Couple.transform.position = coupleOgPos;
    }

    void reachedEnd()
    {
        enableMove = false;
        Aleksei.SetActive(false);
        Michelle.SetActive(false);
        exploreManager.reachedEnd();
    }


}
