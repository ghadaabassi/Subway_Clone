using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movesubway : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 260f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.back * speed * Time.deltaTime;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "player")
        {
            speed = 0;

        }
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
