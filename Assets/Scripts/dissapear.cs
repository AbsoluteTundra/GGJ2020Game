using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissapear : MonoBehaviour
{
    bool start;

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<SpriteRenderer>().enabled && !start)
        {
            Invoke("Dissable", 10);
            start = true;
        }
    }

    void Dissable()
    {
        start = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }
}
