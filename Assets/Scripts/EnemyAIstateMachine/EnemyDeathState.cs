using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{

    
    Collider[] colliders;
    float counter;
    public override void EnterState(EnemyStateManager enemy)
    {
       
        enemy.GetComponent<Animator>().enabled = false;
        Debug.Log("death state");
        counter = 0;
        colliders = enemy.GetComponentsInChildren<Collider>();
        
    
        foreach (Collider collider in colliders)
        {
            collider.isTrigger = false;
        }
        

    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {
        Debug.Log("öldüm yerdeyim");
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        
        if (counter <= 10)
        {
            counter+=Time.deltaTime;
        }
        else
        {
           Object.Destroy(enemy.gameObject);
        }
    }
    
}
