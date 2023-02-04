using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bloodblue : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider Hp;
    void Start()
    {
        Hp.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) {
            Hp.value = Hp.value - 0.1f;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            Hp.value = Hp.value + 0.1f;
        }
    }
}
