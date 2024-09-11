using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    public Text pointsText;
    // Start is called before the first frame update
 public void setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString();
    }
}
