using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cursor : MonoBehaviour
{
    public GameObject cursor,bullet, GunStand;
    RectTransform rectr;
    public Guns currentGunIndex;  
    public float speed;
    public float valY;
    public MarketPopulating items;
    //float fireRate;
    public CursorTouch isTouch;
    float dir;
    float startposX,startposY;
    
 
    bool readyTofire = true;
    void Start()
    {
        rectr = cursor.GetComponent<RectTransform>();
        startposX = cursor.transform.position.x;
        startposY= cursor.transform.position.y;
        //fireRate = 0.4f;

    }

    void Update()
    {
        
        if (isTouch.touching) { 
        rectr.transform.position = new Vector3(Mathf.Clamp(Input.mousePosition.x, 350, 750), Mathf.Clamp(Input.mousePosition.y, startposY - valY, startposY), cursor.transform.position.z);
           
            dir = rectr.transform.position.x - startposX;
            
            GunStand.transform.position = new Vector3(speed * dir, GunStand.transform.position.y, GunStand.transform.position.z);
            
        }
        else
        {
            rectr.transform.position = new Vector3(rectr.transform.position.x, startposY, rectr.transform.position.z);
            
        }
        if (Input.GetKeyDown(KeyCode.Space)||rectr.transform.position.y<=79.5f)
        {
            Fire();
        }
      
        

    }

    void Fire()
    {
        if (readyTofire)
        {
           
            
            Instantiate(bullet, GunStand.transform.GetChild(currentGunIndex.currentGunIndex).Find("barrel").transform.position, Quaternion.identity);
            //Play gun sound
            GunStand.transform.GetChild(currentGunIndex.currentGunIndex).GetComponent<AudioSource>().Play();
            readyTofire = false;
            StartCoroutine(waitTofire());
   
        }
    }
   
    IEnumerator waitTofire()
    {
        Debug.Log(currentGunIndex.currentGunIndex);
        yield return new WaitForSeconds(items.Items[currentGunIndex.currentGunIndex].itemFireRate);      
        readyTofire = true;
    }
   
}
