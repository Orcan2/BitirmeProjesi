
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class EnemyAttackState : EnemyBaseState
{
    Rigidbody rb;
    EnemyStateManager stateManager;
    Vector3 targetTr;
    PlayerHealth playerHealth;




    float dir;

    public override void EnterState(EnemyStateManager enemy)
    {
        stateManager = enemy;
        enemy.anim.SetInteger("param", 1);
        Debug.Log("Enemy Attack State!!!");
        rb = enemy.GetComponent<Rigidbody>();
      
        rb.transform.rotation = new Quaternion(0, 180, 0, 0);

        // Player karakterinin sağlık bileşenine erişim sağla
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
    }

    


    public override void UpdateState(EnemyStateManager enemy)
    {
        targetTr = stateManager.targetPos;
        dir = (rb.transform.position - targetTr).magnitude;
            if (dir <= 10 && dir > 3)
            {
                rb.transform.LookAt(targetTr);
                Vector3 direction = (rb.transform.position - targetTr).normalized;
                rb.transform.Translate(10 * Time.deltaTime * direction);
                enemy.anim.SetInteger("param", 1);
               
                if (dir <= 5)
                {
                    Debug.Log("attackkkkk");
                    AttackPlayer();
                    enemy.anim.SetInteger("param", 2);
                }
            }
            else if (dir > 10)
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
        
        if (collision.collider.CompareTag("bullet"))
        {
            enemy.SwitchState(enemy.beingHitState);
        }
        if (collision.collider.CompareTag("Enemy"))
        {
            rb.transform.Translate(new Vector3((collision.gameObject.transform.position.x - rb.transform.position.x) * 0.1f, 0, 0));
            Debug.Log("enemy temas");
            AttackPlayer();

        }


    }
    void AttackPlayer()
    {
        // Oyuncuya hasar verme
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(1); //  1 hasar ver
        }
    }


}
