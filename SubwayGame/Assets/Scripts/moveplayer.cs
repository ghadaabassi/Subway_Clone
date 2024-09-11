using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveplayer : MonoBehaviour
{
    public Rigidbody rg;
    float speed = 30.0f;
    void Start()
    {
       rg= GetComponent<Rigidbody>();
    }

    void Update()
    {
        float mvh = Input.GetAxis("Horizontal");
        float mvv = Input.GetAxis("Vertical");
        Vector3 mvr = new Vector3(mvh, 0, mvv);
        rg.AddForce(mvr * speed * Time.deltaTime);

    }
}
