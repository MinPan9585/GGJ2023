using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class daojishi : MonoBehaviour
{
    public float timestart;
    public Text daojishiadad;
    void Start()
    {
        daojishiadad.text = "Left time:"+timestart.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timestart -= Time.deltaTime;
        daojishiadad.text = "Left time:" + timestart.ToString();
    }
}
