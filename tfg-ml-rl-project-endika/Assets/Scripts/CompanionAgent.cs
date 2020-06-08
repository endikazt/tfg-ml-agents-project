using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MLAgents;
using MLAgents.Sensors;

public class CompanionAgent : Agent
{

    Rigidbody rb;
    CompanionArea area;
    public Transform startPoint;
    public GameObject player;
    public GameObject firstEnemy;
    public GameObject secondEnemy;
    public GameObject lifeCube;
    public GameObject lifeCubePrefab;
    public Transform shootPoint;
    public float moveSpeed = 12f;
    public float rotateSpeed = 180f;
    private bool hasLifeCube;
    Quaternion originalRotation;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.position = startPoint.transform.position;
        originalRotation = rb.transform.rotation;
        area = GetComponentInParent<CompanionArea>();
        
    }

    public override void OnEpisodeBegin() 
    {
        area.ResetArea();
        this.transform.rotation = originalRotation;
        transform.position = startPoint.transform.position;
    }

    void FixedUpdate() {

        if(Vector3.Distance(transform.position, player.transform.position) < 3 && hasLifeCube == true)
        {
            ThrowLifeCube();
        }
        
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        
        // 4 valores
        sensor.AddObservation(hasLifeCube);
        sensor.AddObservation(area.playerLifePoints);
        sensor.AddObservation(area.score);
        sensor.AddObservation(area.enemyKilledCounter);

        // La posicion del jugador, agente, enemigos y el cubo de vida (7 valores)
        sensor.AddObservation(Vector3.Distance(lifeCube.transform.position, transform.position));
        sensor.AddObservation((lifeCube.transform.position - transform.position).normalized);
        sensor.AddObservation(this.transform.forward);

        // Velocidad del agente y rotacion
        sensor.AddObservation(this.rb.velocity.x); // 1 valor
        sensor.AddObservation(this.rb.rotation.y); // 1 valor

        //Total 13 valores
    }

    public override void OnActionReceived(float[] vectorAction)
    {

        // Se convierte la primera accion para moverse para adelante
        float forwardAmount = vectorAction[0];

        // Se convierte la segunda accion para moverse a la izquierda o la derecha
        float turnAmount = 0f;
        if (vectorAction[1] == 1f)
        {
            turnAmount = -1f;
        }
        else if (vectorAction[1] == 2f)
        {
            turnAmount = 1f;
        }

        // Se aplica el movimiento
        rb.MovePosition(transform.position + transform.forward * forwardAmount * moveSpeed * Time.fixedDeltaTime);
        transform.Rotate(transform.up * turnAmount * rotateSpeed * Time.fixedDeltaTime);

        // Se aplica un recompensa negativa en cada paso para animarle a que se mueva
        if (maxStep > 0) AddReward(-1f / maxStep);

        // Llega al objetivo
        if(area.score >= 3)
        {
            SetReward(100.0f);
            EndEpisode();
        }

        if(area.playerLifePoints <= 0)
        {
            SetReward(-100.0f);
            EndEpisode();
        }

        if(area.playerLifePoints < area.lastPlayerLifePoints)
        {
            AddReward(-1.0f);
        }

        if(area.playerLifePoints > area.lastPlayerLifePoints)
        {
            AddReward(1.0f);
        }

        if(area.enemyKilledCounter > area.lastEnemyKilledValue)
        {
            AddReward(1.0f);
        }

        if(this.transform.rotation.x > 80 ||  this.transform.rotation.x < -80 || this.transform.rotation.z > 80|| this.transform.rotation.z < -80)
        {
           SetReward(-100f);
           EndEpisode();
        }

        if(Vector3.Distance(player.transform.position, firstEnemy.transform.position) > 5)
        {
            AddReward(1.0f);
        }

        
         if(Vector3.Distance(player.transform.position, secondEnemy.transform.position) > 5)
        {
            AddReward(1.0f);
        }

        //Si se cae de la plataforma
        if(this.transform.position.y < 0f) 
        {
            SetReward(-100f);
            EndEpisode();
        }

        //Si colisiona con un obejto y se levanta del suelo del entorno
        if(this.transform.position.y > 2f) 
        {
           SetReward(-100f);
           EndEpisode();
        }
    }

    public override float[] Heuristic()
    {

        float forwardAction = 0f;
        float turnAction = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            // moverse hacia adelante
            forwardAction = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            // moverse hacia la izquierda
            turnAction = 1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            // moverse hacia la derecha
            turnAction = 2f;
        }

        // Se ponen todos las acciones en un array y se devuleve
        return new float[] { forwardAction, turnAction };
    }

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Life Cube") && this.hasLifeCube == false){
            other.gameObject.SetActive(false);
            this.hasLifeCube = true;
        }

        if (other.gameObject.CompareTag("Hole")) 
        {
           SetReward(-100f);
           EndEpisode();
        }
        
    }

    private void OnTriggerStay(Collider other) {
        
         if (other.gameObject.CompareTag("Wall")) 
        {
           SetReward(-100f);
           EndEpisode();
        }

    }

    void OnTriggerExit(Collider other)
    {

         if (other.gameObject.CompareTag("Area")) {
           SetReward(-100f);
           EndEpisode();
        }
        
    }


    void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Player")) 
        {
          ThrowLifeCube();
        }

         if (other.gameObject.CompareTag("Wall") && Vector3.Distance(other.gameObject.transform.position, transform.position) <= 2) 
        {
           SetReward(-1f);
        }

         if (other.gameObject.CompareTag("Hole") && Vector3.Distance(other.gameObject.transform.position, transform.position) <= 2) 
        {
           AddReward(-1f);
        }

         if (other.gameObject.CompareTag("Enemy") && Vector3.Distance(other.gameObject.transform.position, transform.position) < 1) 
        {
           AddReward(1f);
        }
    }

    private void ThrowLifeCube ()
    {

        if(!hasLifeCube) return;
        hasLifeCube = false;

        GameObject lifeCubeInstance = Instantiate (lifeCubePrefab, shootPoint.position, shootPoint.rotation) as GameObject;	
        Rigidbody lifeCubetIntanceRigidbody = lifeCubeInstance.GetComponent<Rigidbody>();
        lifeCubetIntanceRigidbody.AddForce(Vector3.forward * 7f);	
        lifeCubetIntanceRigidbody.velocity = transform.forward * 7f;
    }    

}
