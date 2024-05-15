using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MarketPopulating : MonoBehaviour
{
    public List<Items> Items;
    public Guns gunList;
    public GameObject slot;
    public int money;
    public GameObject gunStand;
 
    GameObject tmp; 
    void Start()
    {
      
        RunMarket();      
    }
    
    public void RunMarket()
    {
        
        for(int i = 1; i < Items.Count; i++)
        {
            GameObject cogalanslot = Instantiate(slot, transform);
            cogalanslot.GetComponent<Image>().sprite = Items[i].itemPic;
            cogalanslot.transform.Find("PRICE").GetComponent<TextMeshProUGUI>().SetText("PRICE \t"+Items[i].itemPrice.ToString()+"$");
            int temp = i;
            cogalanslot.transform.Find("BUY").GetComponent<Button>().onClick.AddListener(() => Buy(temp));
            
        }
    }
    public void Buy(int id)
    {
        if (money >= Items[id].itemPrice)
        {
            money -= Items[id].itemPrice;
            
            tmp = Items[id].itemSelf ;
            
            Instantiate(tmp, gunStand.transform.position + new Vector3(0, 1, 0), Quaternion.identity, gunStand.transform);
            gunList.guncel();    
        }
        else
        {
            Debug.Log("para yok");
        }
    }
}
[System.Serializable]
public class Items
{
    public string itemName;
    public Sprite itemPic;
    public int itemPrice;
    public GameObject itemSelf;
    public float itemFireRate;
    public float itemDamage;

    public Items(string itemName, Sprite itemPic, int itemPrice, GameObject itemSelf, float itemFireRate,float itemDamage)
    {
        this.itemName = itemName;
        this.itemPic = itemPic;
        this.itemPrice = itemPrice;
        this.itemSelf = itemSelf;
        this.itemFireRate = itemFireRate;
        this.itemDamage = itemDamage;
    }
}
