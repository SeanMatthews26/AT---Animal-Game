using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    float deleteTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        if(transform.position.y > 6.4f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -3f);
        }

        if (transform.position.y < -6.4f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 3f);
        }

        if (transform.position.x < -9.9f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 0);
        }

        if (transform.position.x > 9.9f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, 0);
        }

        StartCoroutine(Delete());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Delete()
    {
        WaitForSeconds wait = new WaitForSeconds(deleteTime);

        yield return wait;

        Destroy(gameObject);
    }


}
