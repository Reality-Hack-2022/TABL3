using UnityEngine;
using System;
using System.Globalization;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine.Networking;
using Newtonsoft.Json;


public class DepthChart : MonoBehaviour
{
    public string httpString;
    public LineRenderer bidLineRenderer;
    public LineRenderer askLineRenderer;
    private float width= 0.01f;
    private float xScale;
    float bidFront = 0;
    float askFront = 0;

    public float askTop;
    public float askBottom;
    public float askRange;
    public float askStD;
    public float bidTop;
    public float bidBottom;
    public float bidRange;
    public float range;


    async void Start()
    {
        StartCoroutine(GetText());
        bidLineRenderer.useWorldSpace = false;
        askLineRenderer.useWorldSpace = false;
        
        bidLineRenderer.startWidth = width;
        bidLineRenderer.endWidth = width;
        askLineRenderer.startWidth = width;
        askLineRenderer.endWidth = width;
    }

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get(httpString);
        yield return www.SendWebRequest();
        OrderBook response = JsonConvert.DeserializeObject<OrderBook>(www.downloadHandler.text);
        Debug.Log(response.timestamp);
        askLineRenderer.positionCount = response.asks.Count;
        bidLineRenderer.positionCount = response.bids.Count;
        
        List<float> askValues = new List<float>();
        List<float> askQuants = new List<float>();

        for (int i = 0;i<response.asks.Count;i++)
        {
            askValues.Add((float)Convert.ToDouble(response.asks[i][0]));
            askQuants.Add((float)Convert.ToDouble(response.asks[i][1]));
        }

        float askAvg = askValues.Average();
        float askSum = (float)askValues.Sum(d => Math.Pow(d - askAvg, 2));
        //askStD = (float)Math.Sqrt((askSum)/askValues.Count());

        askTop = (float)Convert.ToDouble(response.asks.Last()[0]);
        askBottom = (float)Convert.ToDouble(response.asks.First()[0]);
        bidTop = (float)Convert.ToDouble(response.bids.First()[0]);
        bidBottom = (float)Convert.ToDouble(response.bids.Last()[0]);
        askRange = askTop-askBottom;
        bidRange = bidTop-bidBottom;
        range = askTop-bidBottom;

        float value = 0.0f;
        float quantity = 0.0f;

        for (int i = 0;i<response.asks.Count;i++)
        {
            value += (float)Convert.ToDouble(response.asks[i][0]);
            quantity += (float)Convert.ToDouble(response.asks[i][1]);
            askLineRenderer.SetPosition(i,new Vector3((range-value)/range,(quantity-bidBottom)/100.0f,0));
        }
        value = 0.0f;
        for (int i = 0;i<response.bids.Count;i++)
        {
            value += (float)Convert.ToDouble(response.bids[i][0]);
            quantity += (float)Convert.ToDouble(response.bids[i][1]);
            bidLineRenderer.SetPosition(i,new Vector3(-(range-value)/range,(quantity-bidBottom)/100.0f,0));
        }
        value = 0.0f;

    }
}