using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meteor : MonoBehaviour
{
    public bool start;
    float t;

    // Update is called once per frame
    void Update()
    {
        if (start)
        {
            t += Time.deltaTime/3f;

            transform.localPosition = Vector3.Lerp(new Vector3 (1000, 1500, 0), new Vector3(0,0,0), t);
            transform.localScale = Vector3.Lerp(new Vector3 (0,0,0), new Vector3(2,2,2), t);
            if (Vector3.Distance(transform.localPosition, new Vector3(0,0,0)) < 10)
            {
                start = false;
                transform.localPosition = new Vector3(1000,1500,0);
                transform.localScale = new Vector3(0,0,0);
            }
        }
    }
}
