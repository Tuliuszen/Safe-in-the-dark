using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent enemyAgent;
    public Transform playerTransform;
    public Animator animController;
    public Transform[] paths;
    public bool isPatroling = true;
    int wayPointIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        animController = GetComponent<Animator>();
        wayPointIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPatroling)
            WaypointMover();
    }

    public void MoveToPlayer(Transform targetPos)
    {
        if (this.transform.position == targetPos.position)
            return;
        
        enemyAgent.SetDestination(targetPos.position);
        //transform.LookAt(playerTransform);
        if (animController != null)
            animController.SetTrigger("isWalking");
    }

    public void StayStill()
    {


    }

    void WaypointMover()
    {
        if (paths.Length != 0)
        {
            enemyAgent.SetDestination(paths[wayPointIndex].position);
            if (transform.position.x == paths[wayPointIndex].position.x && transform.position.z == paths[wayPointIndex].position.z)
                wayPointIndex++;

            
            if (wayPointIndex == paths.Length)
                wayPointIndex = 0;
        }
        else
        {
            return;
        }
    }
}
