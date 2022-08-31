using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teamscore : MonoBehaviour
{
	public static Teamscore Instance;
	public Text UiteamScore;
	public Text UITeamRedgravity, UiTeamBluegravity;
	public Text UIwintext;
	public Text UIRedscore, UIBluescore;

	public GameObject UIWindScoreBoard;

	public int TeamBluescore, TeamRedscore;

	



	// Start is called before the first frame update
	void Start()
    {
		singleton();
		Scorecount();
		TeamBluescore = 0;
		TeamRedscore = 0;
	}

	public void singleton()
	{
		if (Instance == null)
		{
			Instance = this;
		}
	}

	public bool isTeamscore()
	{
		
		UiteamScore.text = "Blue : " + TeamBluescore + " Red : " + TeamRedscore.ToString();
		UIBluescore.text = "Blue Score" + TeamBluescore;
		UIRedscore.text = "Red Score" + TeamRedscore;
		
		bool iswinmatch = true;		
		if (TeamBluescore >= 4)
		{
			
			UIwintext.text = "Win Team Blue";
			UIWindScoreBoard.SetActive(true);
			iswinmatch = false;
		
		}

		else if (TeamRedscore >= 4)
		{
			
			UIwintext.text = "Win Team Red";
			UIWindScoreBoard.SetActive(true);			
			iswinmatch = false;
			
		}

		Scorecount();
		UiTeamBluegravity.text = VolleyBallEvent.Instance.teamplayer[1].GetComponent<JoistickPlayer>().player_gravity.ToString();
		UITeamRedgravity.text = VolleyBallEvent.Instance.teamplayer[0].GetComponent<AIplayer>().player_gravity.ToString();

		return iswinmatch;
	
	}

	public void Scorecount()
	{

		UiteamScore.text = "Blue : " + TeamBluescore.ToString() + " Red : " + TeamRedscore.ToString();

	}
}
