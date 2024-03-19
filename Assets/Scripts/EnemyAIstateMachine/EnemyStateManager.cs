using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public Vector3 targetPos;
    public LayerMask GunStand,Enemy;
    public EnemyBaseState currentState;
    public EnemyWalkState walkState=new EnemyWalkState();
    public EnemyAttackState attackState = new EnemyAttackState();
    public EnemyHitStatemachine beingHitState = new EnemyHitStatemachine();
    public EnemyDeathState deathState = new EnemyDeathState();
    public Animator anim;
    public float HP;
    Collider[] colliders;

    void Start()
    {
        HP = 10;
        targetPos=new Vector3(0,0,0); 
        
        colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.isTrigger = true;
        }
        
        gameObject.GetComponent<Collider>().isTrigger = false;
     
        currentState = walkState;
        currentState.EnterState(this);
        
    }

    
    void Update()
    {
        currentState.UpdateState(this);
        Collider[] colliders = Physics.OverlapSphere(transform.position, 10f, GunStand);
        foreach (Collider collider in colliders)
        {

            GameObject nearbyObject = collider.gameObject;
            if (nearbyObject.CompareTag("Player"))
            {
                targetPos = nearbyObject.transform.position;
            }

        }

    }

    public void SwitchState(EnemyBaseState state)
    {
        currentState = state;
        state.EnterState(this);
    }
    public void OnCollisionEnter(Collision collision)
    {
       
        currentState.OnCollisionEnter(this,collision);
    }
    
}
