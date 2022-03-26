using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockAgent : MonoBehaviour
{
    public int address;
    public int count=0;
    public float freq;
    public float portion;
    public GameObject parent;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        portion=(float)count/100.0f;
        if(count<=(int)(60.0f*freq))
        {
            transform.localScale = new Vector3(portion,portion,portion);
        }
        if(count%(int)(60.0f*freq) == 0)
        {
            address++;
            transform.position += new Vector3(0,0.1f*freq,0);
        }
    }
}
