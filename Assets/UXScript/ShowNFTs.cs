using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNFTs : MonoBehaviour
{

    public GameObject NFT;

    public void Display()
    {
        NFT.SetActive(true);
    }

    public void Hide()
    {
        NFT.SetActive(false);
    }
}
