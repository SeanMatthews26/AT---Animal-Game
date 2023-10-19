using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animal : MonoBehaviour
{
    private float deleteTime = 10f;
    private Vector2 mousePos;
    private BoxCollider2D boxCollider2D;
    private float animalSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Movement
        if(transform.position.y > 6.4f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -animalSpeed);
        }

        if (transform.position.y < -6.4f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, animalSpeed);
        }

        if (transform.position.x < -9.9f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(animalSpeed, 0);
        }

        if (transform.position.x > 9.9f)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-animalSpeed, 0);
        }

        //StartCoroutine(DeleteAfterTime());
    }

    private void OnEnable()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private IEnumerator DeleteAfterTime()
    {
        WaitForSeconds wait = new WaitForSeconds(deleteTime);

        yield return wait;

        Destroy(gameObject);
    }

    public void Catch()
    {
        if(boxCollider2D == null)
        {
            Debug.Log("NoCollider");
            return;
        }

        if(boxCollider2D.OverlapPoint(mousePos))
        {
            Debug.Log("Overlap");
            Destroy(gameObject);
        }
    }

}
