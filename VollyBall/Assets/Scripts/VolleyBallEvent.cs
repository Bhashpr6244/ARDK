using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolleyBallEvent : MonoBehaviour
{


	public static VolleyBallEvent Instance;		
	public Rigidbody ball;		
	[HideInInspector]
	public Vector3 target;
	private float h;	
	[HideInInspector]
	public float gravity;
	public float hitplayer_gravity;
	public GameObject[] teamplayer;	
	public Team moveballtoteam;	
	public bool isstartgame;

	
	

	private void Awake()
	{		
	
		hitplayer_gravity = 1f;
		singleton();
		isstartgame = true;
		ball.useGravity = false;
		gravity = Random.Range(-18.0f, -1.0f);
		var spawnSideList = new List<string> { "Red", "Blue" };	
		Resetball("Red");
		
	}

	public void singleton()
	{
		
		if (Instance == null)
		{
			Instance = this;
		}

	}
	void Resetball(string ballSpawnSide)
	{
				
		var randomPosX = Random.Range(-4.5f, 4f);
		var randomPosZ = Random.Range(2.5f, 8f);
		var randomPosY = Random.Range(3.1f, 8f);
		h = randomPosY;

			
		if (ballSpawnSide == "Red")
		{
			moveballtoteam = Team.Red;
			
			target = new Vector3(randomPosX, 0.5f, randomPosZ);
			
		

		}
		else if (ballSpawnSide == "Blue")
		{

			
			moveballtoteam = Team.Blue;

			target = new Vector3(randomPosX, 0.5f, -randomPosZ);
			

		}

		Launch();

	}
	

	
	public void isboolvalue()
	{
		

		if (moveballtoteam.ToString() == "Blue")
		{


			//teamplayer[1].gameObject.GetComponent<AIplayer>().ismove = true;
			

		}
		if (moveballtoteam.ToString() == "Red")
		{
			
			teamplayer[0].gameObject.GetComponent<AIplayer>().ismove = true;

						
		}
		isstartgame = true;

	}
	
	

	void Launch()
	{
		

		Physics.gravity = Vector3.up * gravity * hitplayer_gravity;
		
		ball.useGravity = true;
		ball.velocity = CalculateLaunchData().initialVelocity ;
	
	}

	LaunchData CalculateLaunchData()
	{

		
		float displacementY = target.y - ball.position.y;
		Vector3 displacementXZ = new Vector3(target.x - ball.position.x, 0, target.z - ball.position.z);
		float time = Mathf.Sqrt(-2 * h / Physics.gravity.y) + Mathf.Sqrt(2 * (displacementY - h) / Physics.gravity.y);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * Physics.gravity.y * h);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(gravity), time);

	}

	struct LaunchData
	{
		
		public readonly Vector3 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData(Vector3 initialVelocity, float timeToTarget)
		{
			
			this.initialVelocity = initialVelocity;
			this.timeToTarget = timeToTarget;

		}

	}
	public void ResolveEvent(Event triggerEvent)
	{

		var iswonteam = Teamscore.Instance.isTeamscore();
		if (!iswonteam)
		{
			return;
		}

		switch (triggerEvent)
		{

			
			case Event.HitRedGoal:
				teamplayer[0].gameObject.GetComponent<AIplayer>().jump();
				Resetball(Team.Red.ToString());				
				break;

			case Event.HitBlueGoal:
				
				Resetball(Team.Blue.ToString());				
				break;

		}
		
	}

	public void SetBallPlayerturn(Event triggerEvent)
	{
		var iswonteam = Teamscore.Instance.isTeamscore();
		

		if(iswonteam)
		{
			teamplayer[0].transform.position = teamplayer[0].GetComponent<AIplayer>().currentpos;
			

			switch (triggerEvent)
			{

				case Event.HitRedGoal:
					
					ball.transform.position = new Vector3(teamplayer[0].transform.position.x, 1.3f, teamplayer[0].transform.position.z);
					
					break;

				case Event.HitBlueGoal:
					
					ball.transform.position = new Vector3(teamplayer[1].transform.position.x, 1.4f, teamplayer[1].transform.position.z);
					ball.isKinematic = true;
					break;

			}
					
		}

	}
	
	public void Restart()
	{

		Application.LoadLevel("PlayArea");

	}

}




public enum Team
{
	Blue = 0,
	Red = 1,
	Default = 2
}

public enum Event
{
	HitRedGoal = 0,
	HitBlueGoal = 1,
	HitOutOfBounds = 2
}