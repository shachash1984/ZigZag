using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public static bool gameOver;
    public GameObject particle;
    [SerializeField]
    private float speed;
    bool started;
    Rigidbody rb;
    
    

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // rb.constraints = RigidbodyConstraints.FreezePositionY;
        gameOver = false;

    }
	
	void Start () {
        started = false;
        
	}
	 
	
	void Update () {
        if (!started)
        {
            if(Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
                GameManager.GMInstance.StartGame();
            }
        } 

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if(!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            GameManager.GMInstance.GameOver();
            rb.velocity = new Vector3(0, -25f, 0);
            rb.constraints = RigidbodyConstraints.None;
            
        }

        if(Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
	}

    void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        if(coll.gameObject.tag == "Diamond")
        {
            GameObject part =  Instantiate(particle, coll.gameObject.transform.position, Quaternion.identity);
            Destroy(coll.gameObject);
            Destroy(part, 1f);
            
        }
    }
}
