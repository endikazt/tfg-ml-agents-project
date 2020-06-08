using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentController : MonoBehaviour
{
    PlayerController player;
    private Rigidbody rb;
    public GameObject lifeCube;
    public Transform shootPoint;
    public float moveSpeed = 2f;
    public float rotateSpeed = 5f;
    public float lookRadius = 3f;
    private bool hasLifeCube;

    void Start()
    {

        this.rb = GetComponent<Rigidbody>();
        this.hasLifeCube = false;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.B))
        {
            if(hasLifeCube)
            {
                ThrowLifeCube();
                this.hasLifeCube = false;
            }
        }
        
    }

    void FixedUpdate() {

        Vector3 moveDir =  Vector3.forward * Input.GetAxis("Vertical");
        Vector3 move = moveDir * this.moveSpeed * Time.deltaTime;
        transform.Translate(move);
        
        Vector3 rotateDir =  Vector3.up * Input.GetAxis("Horizontal");
        Vector3 rotate = rotateDir * this.rotateSpeed * Time.deltaTime;
        transform.Rotate(rotate);

    }

     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Life Cube") && this.hasLifeCube == false)
        {
            other.gameObject.SetActive(false);
            this.hasLifeCube = true;
        }

        if(other.gameObject.CompareTag("Wall"))
        {
            this.rb.isKinematic = false;
        }
        
    }

    void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            this.rb.isKinematic = true;
        }

         if(other.gameObject.CompareTag("ground"))
        {
            this.rb.isKinematic = false;
        }
    }

    private void ThrowLifeCube ()
    {
        GameObject lifeCubeInstance = Instantiate (this.lifeCube, shootPoint.position, shootPoint.rotation) as GameObject;	
        Rigidbody lifeCubetIntanceRigidbody = lifeCubeInstance.GetComponent<Rigidbody>();
        lifeCubetIntanceRigidbody.AddForce(Vector3.forward * 7f);	
        lifeCubetIntanceRigidbody.velocity = transform.forward * 7f;
    }
     void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, this.lookRadius);
    }
}
