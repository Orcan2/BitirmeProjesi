using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cursor : MonoBehaviour
{
    public GameObject cursor,bullet, GunStand;
    RectTransform rectr;
    Transform shotPoint;
    public float speed;
    public float valY;
  
    public CursorTouch isTouch;
    float dir;
    float startposX,startposY;
    public GameObject[] guns = new GameObject[4];
    int currentGunIndx = 0;
    float fireRate = 0.1f;
    bool readyTofire = true;
    void Start()
    {
        rectr = cursor.GetComponent<RectTransform>();
        startposX = cursor.transform.position.x;
        startposY= cursor.transform.position.y;
        guns[currentGunIndx].SetActive(true);

    }

    void Update()
    {
        if (isTouch.touching) { 
        rectr.transform.position = new Vector3(Input.mousePosition.x,Mathf.Clamp(Input.mousePosition.y, startposY - valY, startposY), cursor.transform.position.z);
           
            dir = rectr.transform.position.x - startposX;
            //if (/*silahýn sýnýrlarý buraya gelecek*/true) {
                GunStand.transform.position = new Vector3(speed * dir, GunStand.transform.position.y, GunStand.transform.position.z);
            //}
        }
        else
        {
            rectr.transform.position = new Vector3(rectr.transform.position.x, startposY, rectr.transform.position.z);
            
        }
        if (Input.GetKeyDown(KeyCode.Space)||rectr.transform.position.y<=79.5f)
        {
            Fire();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            changeGun();
        }

    }

    void Fire()
    {
        if (readyTofire)
        {
            shotPoint = guns[currentGunIndx].transform.GetChild(0);
            Instantiate(bullet, shotPoint.position, Quaternion.identity);
            readyTofire = false;
            StartCoroutine(waitTofire());

        }
    }
    void changeGun()
    {
        guns[currentGunIndx].SetActive(false);
        currentGunIndx++;
        if (currentGunIndx >= guns.Length) { currentGunIndx = 0; }
        guns[currentGunIndx].SetActive(true);
    }
    IEnumerator waitTofire()
    {
        yield return new WaitForSeconds(fireRate);
        readyTofire = true;
    }
   
}
