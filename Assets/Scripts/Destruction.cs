using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    float timeLeft = 5;
    public GameObject world;
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime;
        if ( timeLeft < 0)
        {
            CreateDestruction();
            timeLeft = 5;
        }
    }

    
    void CreateDestruction ()
    {
        float x = 0;
        float y = 0;
        float z = 0;

        // Selects a random point of the planet 
        while (x < 500 && x > -500 || y < 500 && y > -500 || z < 500 && z > -500)
        {
            x = Random.Range(100000, -100000);
            y = Random.Range(100000, -100000);
            z = Random.Range(100000, -100000);
        }

        cube.transform.position = world.GetComponent<Collider>().ClosestPoint(new Vector3(x, y, z));

        // With that point it searches the closest objective and then spawns whatever is able to destroy that element
    }
}
