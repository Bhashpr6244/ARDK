using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class JoistickPlayer : MonoBehaviour
{
    public Team payerteam;
   
    public float speed;
    public FixedJoystick joystick;
    private Rigidbody rb;
    public float player_gravity;
    private bool isjump;

    // Start is called before the first frame update
    void Start()
    {
        
        player_gravity = Random.Range(1, 10);
        rb = GetComponent<Rigidbody>();

    }
    public bool isGrounded;
    public float offset = 0.1f;
    public Vector3 surfacePosition;
    ContactFilter2D filter;
    Collider[] results = new Collider[1];
    // Update is called once per frame
    void FixedUpdate()
    {
       
        Movejoystick();
       
       

    }

    public void Movejoystick()
    {

        rb.velocity = new Vector3(joystick.Horizontal * speed,rb.velocity.y,joystick.Vertical * speed);
    
    }
   
    public void jump()
    {

       
        if (isjump)
        {
            rb.velocity = new Vector3(0f, 10f, 0f);
            //rb.AddForce(Vector3.up * 150f, ForceMode.Acceleration);
            isjump = false;
            transform.eulerAngles = new Vector3(20f, 0f, 0f);
        
        }

    }


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "BlueTeamFloor")
        {

            isjump = true;
            transform.eulerAngles = Vector3.zero;

        }

    }

}
