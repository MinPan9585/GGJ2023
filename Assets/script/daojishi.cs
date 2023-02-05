using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class daojishi : MonoBehaviour
{
    public float gameTime;
    public Text daojishiadad;

    private void Start()
    {
        StartCoroutine("Daojishi");
    }

    IEnumerator Daojishi()
    {
        while (gameTime > 0)
        {
            yield return new WaitForSeconds(1);
            gameTime--;
            daojishiadad.text = "Left time:" + gameTime.ToString();
            

        } 
    }
}
