using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockFlower : MonoBehaviour
{
    public Blockchain chain = new Blockchain("SOL",0.4f,52000);

    private GameObject[] blocks;

    public GameObject newBlock;
    private float count = 0;
    public int active = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        count++;
        if(count%(int)(60.0f*chain.blockFrequency)==0)
        {
            GameObject temp = Instantiate<GameObject>(newBlock,transform.position,transform.rotation);
            temp.transform.parent = transform;
            temp.GetComponent<BlockAgent>().freq = chain.blockFrequency;
            blocks[active] = temp;
            //blocks[active].transform.parent = transform;
            active++;
        }
    }   
}


[System.Serializable]
public class Blockchain
{
    public string name;
    public float blockFrequency;
    public int blockTransactions;

    public Blockchain(string chainName, float freq, int trans)
    {
        name = chainName ;
        blockFrequency = freq;
        blockTransactions = trans;
    }
}
