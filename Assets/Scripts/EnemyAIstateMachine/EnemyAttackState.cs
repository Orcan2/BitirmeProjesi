
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class EnemyAttackState : EnemyBaseState
{
    Rigidbody rb;
    
    public LayerMask Player;
    //private bool playerDetected = false;
    EnemyStateManager target;
    float dir;

    public override void EnterState(EnemyStateManager enemy)
    {
        enemy.anim.SetInteger("param", 1);
        Debug.Log("Enemy Attack State!!!");
        rb = enemy.GetComponent<Rigidbody>();
        target = enemy;
        rb.transform.rotation = new Quaternion(0, 180, 0, 0);
    }

    


    public override void UpdateState(EnemyStateManager enemy)
    {
        dir = (rb.position - target.targetPlayer.transform.position).magnitude;
        if (dir <= 10 && dir > 3)
        {
            rb.transform.LookAt(target.targetPlayer.transform);
            Vector3 direction = (rb.position - target.targetPlayer.transform.position).normalized;
            rb.transform.Translate(10 * Time.deltaTime * direction);
            enemy.anim.SetInteger("param", 1);
            //Debug.Log(dir);
            if (dir <= 5)
            {
                Debug.Log("attackkkkk");
                enemy.anim.SetInteger("param", 2);
            }
        }
        else if(dir>10) 
        {
            enemy.SwitchState(enemy.walkState);
        }

        if (enemy.transform.position.y != 0.7f)
        {
            enemy.transform.position = new Vector3(enemy.transform.position.x, 0.7f, enemy.transform.position.z);
        }

    }

    public override void OnCollisionEnter(EnemyStateManager enemy, Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("attack state collision");
            //playerDetected = true;
        }
        if (collision.collider.CompareTag("bullet"))
        {
            enemy.SwitchState(enemy.beingHitState);
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            rb.transform.Translate(new Vector3((collision.gameObject.transform.position.x - rb.transform.position.x) * 0.1f, 0, 0));
            Debug.Log("enemy temas");
        }


    }
    
   
}
