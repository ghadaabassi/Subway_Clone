using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class doubleMony : MonoBehaviour
{
   // int money = 0;
    public TMP_Text text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // money = int.Parse(text.text);

    }

    public void OnCollisionEnter(Collision other)
    {
        /*if (other.gameObject.tag == "player")
        {
            Debug.Log("+10");
            money += 10;
            text.text = money.ToString();
            Destroy(this.gameObject);
        }
    */
        }


    private void OnTriggerEnter(Collider other)
    {
    }
}
