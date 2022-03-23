using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class Parsers : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
           SolResponse response = JsonConvert.DeserializeObject<SolResponse>("response.txt");
            Debug.Log("ID SHOULD BE HERE: "+response.id);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}




[System.Serializable]
public class SolResponse
{
    public string jsonrpc;
    public SolResponseResult result;
    public int id;
}

public class SolResponseResult
{
    public ResultContext context;
    public ResultValue value;

}
public class ResultContext
{
    public int slot;

}
public class ResultValue
{
    public string[] data;
    public bool executionable;
    public int lamports;
    public string owner;
    public int rentEpoch;

}
/*
{
  "jsonrpc": "2.0",
  "result": {
    "context": {
      "slot": 1
    },
    "value": {
      "data": [
        "11116bv5nS2h3y12kD1yUKeMZvGcKLSjQgX6BeV7u1FrjeJcKfsHRTPuR3oZ1EioKtYGiYxpxMG5vpbZLsbcBYBEmZZcMKaSoGx9JZeAuWf",
        "base58"
      ],
      "executable": false,
      "lamports": 1000000000,
      "owner": "11111111111111111111111111111111",
      "rentEpoch": 2
    }
  },
  "id": 1
}
*/