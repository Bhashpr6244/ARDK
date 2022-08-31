using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VolleyballController : MonoBehaviour
{

    public static VolleyballController Instance; 
    
    [HideInInspector]
    public VolleyBallEvent envController;

    public Team curenthitball;
    public Text txtballdistance;


    private void Awake()
    {

        singleton();

    }

    public void singleton()
    {
        if (Instance == null)
        {
            Instance = this;
        }
            
    }


    // Start is called before the first frame update
    void Start()
    {
        envController = GetComponentInParent<VolleyBallEvent>();
       
      

    }
    private void Update()
    {
        Vector3 dist = VolleyBallEvent.Instance.target - transform.position;
        txtballdistance.text = dist.ToString();
    }

    void OnTriggerEnter(Collider other)
    {

      
       if (other.gameObject.name == "Net_Boundry")
        {
                      
            envController.isboolvalue();
           
       }
             
    }

    void OnCollisionEnter(Collision other)
    {
       
            if (other.gameObject.name == "BlueTeamFloor")
            {

                StartCoroutine(checkscore("Blue"));


            }
            else if (other.gameObject.name == "RedTeamFloor")
            {


                StartCoroutine(checkscore("Red"));


            }
            //BLUETeam 
            else if (other.gameObject.CompareTag(Team.Blue.ToString()))
            {
                
                envController.ball.isKinematic = false;
                envController.ResolveEvent(Event.HitRedGoal);
                envController.hitplayer_gravity = other.gameObject.GetComponent<JoistickPlayer>().player_gravity;
                curenthitball = Team.Blue;

            }
            else if (other.gameObject.CompareTag(Team.Red.ToString()))
            {
              
                envController.teamplayer[0].gameObject.GetComponent<AIplayer>().ismove = false;               
                envController.ResolveEvent(Event.HitBlueGoal);
                envController.hitplayer_gravity = other.gameObject.GetComponent<AIplayer>().player_gravity;
                curenthitball = Team.Red;

            }
        
    }
    public IEnumerator checkscore(string floorname)
    {
        if (envController.isstartgame)
        {
            gameObject.GetComponent<Rigidbody>().mass = 8f;
            envController.isstartgame = false;

            yield return new WaitForSeconds(0.5f);

            if (curenthitball.ToString() == "Blue" && floorname == "Blue" || curenthitball.ToString() == "Red" && floorname == "Blue")
            {
                Teamscore.Instance.TeamRedscore++;
                envController.SetBallPlayerturn(Event.HitRedGoal);

            }
            else if (curenthitball.ToString() == "Red" && floorname == "Red" || curenthitball.ToString() == "Blue" && floorname == "Red")
            {
                Teamscore.Instance.TeamBluescore++;
                envController.SetBallPlayerturn(Event.HitBlueGoal);

            }
        }
    }

}
