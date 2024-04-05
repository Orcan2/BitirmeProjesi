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
        enemy.transform.position=new Vector3(enemy.transform.position.x,enemy.transform.position.y+2,enemy.transform.position.z);
    
        foreach (Collider collider in colliders)
        {
            collider.isTrigger = false;
        }
        

    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {
        
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        
        if (counter <= 2)
        {
            counter+=Time.deltaTime;
        }
        else
        {
          
           Object.Destroy(enemy.gameObject);
        }
    }
    
}
