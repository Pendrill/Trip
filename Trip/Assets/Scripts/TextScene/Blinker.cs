using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blinker : MonoBehaviour
{

    float currentTime = 0.0f;
    float speed = 1f;
    Image blinkerImage;
    int index = 1;
    // Start is called before the first frame update
    void Start()
    {
        blinkerImage = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime * speed;
        if (currentTime > 0.5)
        {
            blinkerImage.enabled = (index % 2 == 0);
            currentTime = 0;
            index += 1;
        }
    }
}
