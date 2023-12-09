using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 2;
    private float deleteTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        //Movement
        if (transform.position.y > 6.4f)
        {
            GetComponent<Rigidbody>().velocity = new Vector2(0, -speed);
        }

        if (transform.position.y < -6.4f)
        {
            GetComponent<Rigidbody>().velocity = new Vector2(0, speed);
        }

        if (transform.position.x < -9.9f)
        {
            GetComponent<Rigidbody>().velocity = new Vector2(speed, 0);
        }

        if (transform.position.x > 9.9f)
        {
            GetComponent<Rigidbody>().velocity = new Vector2(-speed, 0);
        }

        StartCoroutine(DeleteAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator DeleteAfterTime()
    {
        WaitForSeconds wait = new WaitForSeconds(deleteTime);

        yield return wait;

        Destroy(gameObject);
    }
}
