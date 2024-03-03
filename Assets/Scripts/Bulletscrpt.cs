using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletscrpt : MonoBehaviour
{
    public Vector3 force;
    private void Start()
    {
        Destroy(gameObject,5f);
    }
    void Update()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(force);
    }
}
