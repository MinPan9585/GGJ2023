using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bloodred : MonoBehaviour
{
    public Slider Hp;
    void Start()
    {
        Hp.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            Hp.value = Hp.value - 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Hp.value = Hp.value + 0.1f;
        }
    }
}
