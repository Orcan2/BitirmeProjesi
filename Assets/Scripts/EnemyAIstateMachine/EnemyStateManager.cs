using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public GameObject targetPlayer;
    public LayerMask GunStand,Enemy;
    public EnemyBaseState currentState;
    public EnemyWalkState walkState=new EnemyWalkState();
    public EnemyAttackState attackState = new EnemyAttackState();
    public EnemyHitStatemachine beingHitState = new EnemyHitStatemachine();
    public EnemyDeathState deathState = new EnemyDeathState();
    public Animator anim;
    public int HP;
    Collider[] colliders;
    //public bool detected=false;
    void Start()
    {
        colliders = GetComponentsInChildren<Collider>();
        foreach (Collider collider in colliders)
        {
            collider.isTrigger = true;
        }
        
        gameObject.GetComponent<Collider>().isTrigger = false;
        Debug.Log("anan");
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
                targetPlayer=nearbyObject;
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
