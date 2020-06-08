using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    public GameObject[] moveSpots;
    CompanionArea area;
    List<GameObject> moveSpotsCopy;
    public int destinationSpot;
    NavMeshAgent agent;
    public float lookRadius = 1f;

    void Start()
    {
        area = GetComponentInParent<CompanionArea>();
        moveSpotsCopy = new List<GameObject>();

        // for (int i = 0; i < moveSpots.Length; i++)
        // {
        //     moveSpotsCopy.Add(moveSpots[i]);
        // }

        // destinationSpot = Random.Range(0,moveSpotsCopy.Count);
        
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GoToNextPoint();
        
    }

    void GoToNextPoint() 
    {

        // if (moveSpotsCopy.Count > 0)
        // {

        //     agent.destination = moveSpotsCopy[destinationSpot].transform.position;  // establce como destino la posicion del elemento del array
        //     moveSpotsCopy.RemoveAt(destinationSpot);    // elimina la posicion del array de posicion a visitar   

        //     if(moveSpotsCopy.Count == 1)
        //     {
        //         destinationSpot = 0;

        //     } else {

        //         destinationSpot = Random.Range(0, moveSpotsCopy.Count);
        //     }

        // } else {

        //     if(area.score >= 3)
        //     {
        //         moveSpotsCopy = new List<GameObject>();

        //         for (int i = 0; i < moveSpots.Length; i++)
        //         {
        //             moveSpotsCopy.Add(moveSpots[i]);
        //         }

        //          agent.isStopped = true;
        //     }
            
        // }

        agent.destination = GameObject.FindGameObjectWithTag("Pick Up").transform.position;

    }

    // Update is called once per frame
    void Update()
    {

        if (!agent.pathPending && agent.remainingDistance < 0.2f)
        {
            GoToNextPoint();
        }
        
    }

     void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.CompareTag("Enemy")){
            area.lastPlayerLifePoints = area.playerLifePoints;            
            area.playerLifePoints = area.playerLifePoints - 10;
            SetLifeText();
            if(CheckLifePoins() == false) 
            {
                // moveSpotsCopy = new List<GameObject>();
                // for (int i = 0; i < moveSpots.Length; i++)
                // {
                //     moveSpotsCopy.Add(moveSpots[i]);
                // }
                gameObject.SetActive(false);
            } 

        }

        if(other.gameObject.CompareTag("Pick Up")){  
            area.lastScore = area.score;  
            area.score++;
            SetScoreText();
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.CompareTag("Life Cube Throwable"))
        {  
            area.lastPlayerLifePoints = area.playerLifePoints;  
            area.playerLifePoints = 100;
            SetLifeText();
            Destroy(other.gameObject);
        }  
    }

    void FaceTarget()
    {
        Vector3 direction = (moveSpots[destinationSpot].transform.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    bool CheckLifePoins()
    {
        bool isAlive = true;

        if(area.playerLifePoints <= 0){
            isAlive = false;
        }

        return isAlive;
    }
    
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, this.lookRadius);
    }

    void SetLifeText()
    {
        area.playerLifeText.text = "Player Life: " + area.playerLifePoints;
    }
    void SetScoreText()
    {
        area.scoreText.text = "Collectibles: " + area.score;
    }

}
