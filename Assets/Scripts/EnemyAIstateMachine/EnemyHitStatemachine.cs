
using UnityEngine;

public class EnemyHitStatemachine : EnemyBaseState
{
    EnemyStateManager target;
    float dir;
    Rigidbody rb;
    float counter=0;
    Items items;
    public override void EnterState(EnemyStateManager enemy)
    {
        Debug.Log("vuruldum");
        enemy.HP--;
        enemy.anim.SetInteger("param", 3);
        rb=enemy.GetComponent<Rigidbody>();
        target = enemy;
        rb.transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {
        
        if (collision.collider.CompareTag("bullet"))
        {
            enemy.HP--;
            enemy.transform.Translate(Vector3.back * 10 * Time.deltaTime);
        }
        
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if(enemy.HP <= 0) {
            enemy.SwitchState(enemy.deathState);    
        }
        dir = (rb.position - target.targetPos).magnitude;
        if (counter > 1.3f)
        {
            counter = 0;
            enemy.SwitchState(dir <= 5 ? enemy.attackState : enemy.walkState);
        }
        else
        {
            counter += Time.deltaTime;
        }
        
    }
}
