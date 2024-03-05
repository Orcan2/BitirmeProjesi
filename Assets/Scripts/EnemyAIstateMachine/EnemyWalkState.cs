using UnityEngine;


public class EnemyWalkState : EnemyBaseState
{
    
    Rigidbody rb;
    Vector3 targetTr;
    EnemyStateManager stateManager;
    Vector3 dir;
    Animator animm;
    
    public override void EnterState(EnemyStateManager enemy)
    {
         
        animm=enemy.anim;
        animm.SetInteger("param", 0);
        Debug.Log("Enemy Walk State!!!");
        rb =enemy.GetComponent<Rigidbody>();
        stateManager = enemy;
        rb.transform.rotation = new Quaternion(0,180,0,0);
        
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {
        if (collision.collider.CompareTag("bullet"))
        {
            enemy.SwitchState(enemy.beingHitState);
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            rb.transform.Translate(new Vector3((collision.gameObject.transform.position.x-rb.transform.position.x)*0.5f, 0,0));
            Debug.Log("enemy temas");
        }
    }

    

    public override void UpdateState(EnemyStateManager enemy)
    {
        targetTr = stateManager.targetPos;
        dir = rb.transform.position - targetTr;
      
            if (dir.magnitude >= 10)
            {
                rb.transform.Translate(Vector3.forward * 10 * Time.deltaTime);
            }
            else
            {
                enemy.SwitchState(enemy.attackState);
            }
    }
        
    
}
