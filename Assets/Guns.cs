using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Guns : MonoBehaviour
{
    public List<GameObject> silahlar;
    public MarketPopulating marketPopulating;
    public int currentGunIndex=0;

    private void Start()
    {
        marketPopulating.Buy(0);
        silahlar[0].SetActive(true);
        currentGunIndex = 0;
    }

    public void guncel()
    {
        foreach(Transform child in gameObject.transform)
        {
            if (!silahlar.Contains(child.gameObject)) { 
            silahlar.Add(child.gameObject);
                currentGunIndex++;    
            }            
        }
        changeGun();
    }
   void changeGun()
    {
        for (int i = 0; i < silahlar.Count; i++)
        {
            if (i != currentGunIndex)
            {
                silahlar[i].SetActive(false);
            }
            else
            {
                silahlar[i].SetActive(true);
            }
        }
    }
    public void changeGunviaIndex()
    {
        currentGunIndex=(currentGunIndex+1)%silahlar.Count;
        changeGun();
        Debug.Log(currentGunIndex);
    }
}
