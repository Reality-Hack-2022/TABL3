using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using OVRTouchSample;
using System;

public class CustomOculusControls : MonoBehaviour
{
    
    public GameObject player;
    
    public LineRenderer laser;
    private void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.B))
            if(player.transform.localScale.x <=50)
                player.transform.localScale += player.transform.localScale / 7;
        if (OVRInput.GetDown(OVRInput.RawButton.A))
            if (player.transform.localScale.x >=0.5f)
                player.transform.localScale -= player.transform.localScale/8;
        /*
        if (Input.GetKeyDown("space"))

        if (OVRInput.Get(OVRInput.RawAxis1D.LIndexTrigger) > 0.5f)
                
        if (OVRInput.GetDown(OVRInput.RawButton.B))
        if (OVRInput.GetDown(OVRInput.RawButton.A))
        
        if (OVRInput.GetDown(OVRInput.RawButton.Y)||Input.GetKeyDown("e"))
        if (OVRInput.GetDown(OVRInput.RawButton.X) || Input.GetKeyDown("q"))
        if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger)>0.5f || Input.GetKey("w"))
        if (OVRInput.Get(OVRInput.RawAxis1D.LHandTrigger) > 0.5f || Input.GetKey("s"))
        if (OVRInput.GetDown(OVRInput.RawButton.RThumbstick)||Input.GetKeyDown("r"))
        if (OVRInput.GetDown(OVRInput.RawButton.LThumbstick)||Input.GetKeyDown("z"))
        */
    }
}
