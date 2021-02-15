using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class enemy : MonoBehaviour
{
    public static enemy isBusy;

    public Transform player;

    public Transform castPoint;

    Quaternion q;

    public float radius =50;

    public float agroRange =30;

    public float moveSpeed =7;

    public Rigidbody2D rb2d;

    Vector3 direction;

    IAstarAI ai;

    


    void Start()
    {
        ai = GetComponent<IAstarAI>();
        rb2d = GetComponent<Rigidbody2D>();
        direction = transform.up;
        Quaternion q = Quaternion.AngleAxis(Vector2.SignedAngle(castPoint.position, player.position) * 2, Vector3.forward);
        direction = q * direction;

    }
    void Update()
    {
        
        if (!ai.pathPending && (ai.reachedEndOfPath || !ai.hasPath)) 
        {
                   ai.destination = PickRandomPoint();
                   ai.SearchPath();
        }
        
        if (canSeePlayer(agroRange))
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
           
        }
       

    }
    public bool canSeePlayer(float distance)
    {
        bool val = false;
        
        Vector2 endPos = castPoint.position + direction * distance;
        RaycastHit2D hit = Physics2D.Linecast(castPoint.position, endPos, 1 << LayerMask.NameToLayer("Action"));
       
        if(hit.collider != null)
        {
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                //Lets Aggro the Enemy
                val = true;
               
            }
            else
            {
                Quaternion q = Quaternion.AngleAxis(Vector2.SignedAngle(castPoint.position, player.position) * 2, Vector3.forward);
                direction = q * direction;
                val = false;
                
            }
        }
        else
        {
            Quaternion q = Quaternion.AngleAxis(Vector2.SignedAngle(castPoint.position, player.position) * 2, Vector3.forward);
            direction = q * direction;
        }

        //For raycast to work! set player(Tag:Player , Layer:Action) enemy(s)(Tag:Enemy, Layer:Default)
        return val;
    }
    void ChasePlayer()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }
    public bool StopChasingPlayer()
    {
        if (canSeePlayer(agroRange) == false)
        {
            return true;
        }
        return false;
    }
     Vector3 PickRandomPoint () {
        var point = Random.insideUnitSphere * radius;
        point.y = 0;
        point += ai.position;
        return point;
    }
}

