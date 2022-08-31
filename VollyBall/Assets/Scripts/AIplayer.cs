using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIplayer  : MonoBehaviour

{
   
    public Team payerteam;   
    public float player_gravity;
    public int score;
    public Vector3 currentpos;
    public float speed;
    public bool ismove;
    private Rigidbody rb;
    private bool isjump;
    // Start is called before the first frame update
   public void Start()
    {
        isjump = true;
        speed =Random.Range(5, 12);
        player_gravity =Random.Range(1, 10);
        currentpos = transform.position;
        rb = GetComponent<Rigidbody>();
    }
    
    // Update is called once per frame
    void Update()
    {

      
        if(ismove && VolleyBallEvent.Instance.isstartgame)
        {
           
             MoveTowards();

        }
       
    }

    public void MoveTowards(){
        
        var step = speed * Time.deltaTime; // calculate distance to move                                   
        Vector3 targetpos = new Vector3(VolleyBallEvent.Instance.ball.transform.position.x, 0.5f, VolleyBallEvent.Instance.ball.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetpos, step);

    }

    public void jump()
    {
        if (isjump)
        {
            
            rb.AddForce(Vector3.up * 250f, ForceMode.Acceleration);
            isjump = false;
            transform.eulerAngles = new Vector3(-20f, 0f, 0f);

        }

    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "RedTeamFloor")
        {

            isjump = true;
            transform.eulerAngles = Vector3.zero;
            
        }
    
    }

}
