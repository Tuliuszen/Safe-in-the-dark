using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public EnemySO enemyScriptableObject;
    public GameManager manager;
    public Projectile projectile;
    public float bulletSpeed;
    public Transform shootingPoint;
    EnemyMovement enemyMovement;

    float enemySpeed;
    Type enemyType;
    bool shooter;
    //bool attacker = false;

    PlayerController player;
    public float distanceToMove = 30f;
    public float shootDistance = 20f;
    public float attackDistance = 3f;
    bool seesPlayer;

    public GameObject tester;

    public bool canShoot = true;

    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerController>();
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        enemyMovement = GetComponent<EnemyMovement>();

        shooter = enemyScriptableObject.shooter;
        enemySpeed = enemyScriptableObject.speed;
        enemyType = enemyScriptableObject.type;

        enemyMovement.GetComponent<NavMeshAgent>().speed = enemySpeed;
    }

    // TO CORRECT ONE DAY hope its correct now
    void Update()
    {
        if (enemyType == Type.sad)
        {
            NormalBehaviour();
        }
        else
        {           
            GuardBehaviour();
        }
    }

    void NormalBehaviour()
    {
        if (IsPlayerInLight())
        {
            if (CanMove())
            {
                enemyMovement.MoveToPlayer(player.transform);
            }
            //else if near player to add
            else if (enemyMovement.paths.Length != 0)
            {
                enemyMovement.isPatroling = true;
            }
            else
            {
                enemyMovement.StayStill();
            }

        }
    }

    void GuardBehaviour()
    {
        if (IsPlayerInLight())
        {
            if (CanShoot() && manager.revenge)
            {
                if (!canShoot)
                    return;
                transform.LookAt(player.transform);
                StartCoroutine(Shoot());
            }
            else if (CanAttack() && manager.revenge)
            {
                Attack();
            }
            else if (CanMove() && manager.revenge)
            {
                enemyMovement.MoveToPlayer(player.transform);
            }
            else
            {
                enemyMovement.isPatroling = true;
            }
        }
        else
        {
            enemyMovement.isPatroling = true;
        }
        
    }

    bool IsPlayerInLight()
    {
        if (player.inLight)
            seesPlayer = true;
        else
            seesPlayer = false;

        return seesPlayer;
    }

    float CalculateDistanceToPlayer()
    { 
        return Vector3.Distance(this.transform.position, player.transform.position);
    }

    bool CanMove()
    {
        if (CalculateDistanceToPlayer() <= distanceToMove)
            return true;
        else
            return false;
    }

    bool CanAttack()
    {
        if (CalculateDistanceToPlayer() <= attackDistance)
            return true;
        else
            return false;
    }

    bool CanShoot()
    {
        if (shooter)
        {
            if (CalculateDistanceToPlayer() <= shootDistance)
                return true;
            else
                return false;
        }
        else
        {
            return false;
        }
    }

    void Attack()
    { 
        
    }

    public void Die()
    {
        manager.killedEnemy = true;
        manager.revenge = true;
        manager.killCount++;
        manager.SetDarknessValues();
        FindObjectOfType<SFXManager>().GetComponent<SFXManager>().EnemyDeath();
        Destroy(this.gameObject);
    }

    public IEnumerator Shoot()
    {
        canShoot = false;

        Projectile bullet = Instantiate(projectile, shootingPoint.position, Quaternion.identity);
        bullet.transform.LookAt(player.transform);
        //bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed, ForceMode.Impulse);
        yield return new WaitForSeconds(2f);
        canShoot = true;
    }
}
