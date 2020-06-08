using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{

    CompanionArea area;
    public Transform actualTarget;
    public Transform startPoint;
    NavMeshAgent agent;
    Rigidbody rb;
    public float lookRadius = 15f;
    public float lifePoints;
    float timer;
    float distanceToTarget;
    bool chaseCompanion;
    bool isDead;

    // Start is called before the first frame update
    void Start()
    {

        this.lifePoints = 100;
        this.agent = GetComponent<NavMeshAgent>();
        this.rb = GetComponent<Rigidbody>();
        this.actualTarget = GameObject.FindGameObjectWithTag("Player").transform;
        this.area = GetComponentInParent<CompanionArea>();
        this.timer = 0;
        this.chaseCompanion = false;
        this.isDead = false;
        rb.position = startPoint.position;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(isDead == false)
        {
            this.distanceToTarget = Vector3.Distance(actualTarget.position, transform.position);
    
            if(distanceToTarget <= lookRadius)
            {      
                agent.SetDestination(actualTarget.position);          
            }

            if(distanceToTarget >= 5f)
            {      
                rb.isKinematic = true;    

            } else {

                rb.isKinematic = false;
            }

            if(this.chaseCompanion)
            {
                this.timer++;
            }

            if(this.timer >= 400)
            {
                chaseCompanion = false;
                this.actualTarget = GameObject.FindGameObjectWithTag("Player").transform;
            }
        }
        
    }

    void FaceTarget()
    {
        Vector3 direction = (actualTarget.transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    private void OnCollisionEnter(Collision other) 
    {

        if(other.gameObject.CompareTag("Player") && this.lifePoints > 0)
        {
            rb.AddForce(transform.position * -75f);                    
        }

        if(other.gameObject.CompareTag("Companion") && this.lifePoints > 0)
        {

            if(this.lifePoints <= 5)
            {
                this.lifePoints = lifePoints - 5;
                isDead = true;
                area.lastEnemyKilledValue = area.enemyKilledCounter;
                area.enemyKilledCounter++;
                SetEnemyKilledText();
                RespawnEnemy();

            } else {

                this.lifePoints = lifePoints - 5;
                rb.AddForce(transform.position * -75f);   
                this.actualTarget = GameObject.FindGameObjectWithTag("Companion").transform;
                this.chaseCompanion = true;
                this.timer = 0;

            }
                                       
        }
        
    }

    private void OnTriggerEnter(Collider other) {
        
          if (other.gameObject.CompareTag("Hole")) 
        {
                isDead = true;
                area.lastEnemyKilledValue = area.enemyKilledCounter;
                area.enemyKilledCounter++;
                SetEnemyKilledText();
                RespawnEnemy();
        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, this.lookRadius);
    }

    void RespawnEnemy()
    {
        this.timer = 0;
        chaseCompanion = false;
        agent.Warp(startPoint.position);
        lifePoints = 100;
        isDead = false;
        this.actualTarget = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void SetEnemyKilledText()
    {
        area.enemyKilledText.text = "Enemy killed: " + area.enemyKilledCounter;
    }

}
