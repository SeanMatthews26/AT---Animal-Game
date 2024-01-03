using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 2;
    private float deleteTime = 10f;
    private Vector2 speedVector;

    // Start is called before the first frame update
    void Start()
    {
        SetSpeed();

        StartCoroutine(DeleteAfterTime());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetSpeed()
    {
        float randomFactor = Random.Range(-1f, 1f);

        //Movement
        if (transform.position.y > 6.4f)
        {
            speedVector = new Vector2(randomFactor, -1f);
            GetComponent<Rigidbody>().velocity = speedVector.normalized * speed;
        }

        if (transform.position.y < -6.4f)
        {
            speedVector = new Vector2(randomFactor, 1);
        }

        if (transform.position.x < -9.9f)
        {
            speedVector = new Vector2(1, randomFactor);
        }

        if (transform.position.x > 9.9f)
        {
            speedVector = new Vector2(-1, randomFactor);
        }

        GetComponent<Rigidbody>().velocity = speedVector.normalized * speed;
    }


    private IEnumerator DeleteAfterTime()
    {
        WaitForSeconds wait = new WaitForSeconds(deleteTime);

        yield return wait;

        Destroy(gameObject);
    }
}
