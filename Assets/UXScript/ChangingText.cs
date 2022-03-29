using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
//using Random = UnityEngine.Random;

public class ChangingText : MonoBehaviour
{
    public TMP_Text usd;

    //public virtual float Next(float minValue, float maxValue);

    // Update is called once per frame
    void Update()
    {
        //Random r = new Random();
        float randnum = UnityEngine.Random.Range(500.22f, 502.39f);
        
        usd.text = randnum.ToString("0.00") + "USD";
    }
}
