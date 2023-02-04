using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullrt : MonoBehaviour
{
    // Start is called before the first frame update
    public float m_speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    
    void Update()
    {
        transform.Translate(new Vector3(m_speed, 0, 0));
        
    }
}
