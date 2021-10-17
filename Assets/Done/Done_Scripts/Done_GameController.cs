using UnityEngine;
using System.Collections;
using System.IO;
using UnityEngine.SceneManagement;

public class Done_GameController : MonoBehaviour
{
	public GameObject[] hazards;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	
	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
    public GUIText quitText;
    public GUIText powerText;
    public GUIText powerText2;
    private bool powerTextvar;
    private bool quit;
	delegate void pw();
	pw myPw;
	private bool gameOver;
	private bool restart;
	static int score;
	private string path ="Assets/score.txt";
    public static bool scorePowerUp = false;
    public static bool powerupactive = false;
    private bool SecondLevel = false;
    public static bool Powerup2 = false;
	
	void Start ()
	{
		gameOver = false;
		restart = false;
        quit = false;
        powerText.text = "";
		restartText.text = "";
        quitText.text = "";
		gameOverText.text = "";
        powerText2.text = "";

        if (SceneManager.GetActiveScene().name.Equals("SecondLevel")){
            SecondLevel = true;
            Debug.Log(SecondLevel);
            StreamReader reader = new StreamReader("Assets/ScoreLevel1.txt");
            Done_GameController.score = int.Parse(reader.ReadLine());
            reader.Close();
        }
		UpdateScore ();
		StartCoroutine (SpawnWaves ());
	}
	
	void Update ()
	{
        if (Powerup2)
        {
            powerText2.text = "Fire Power Up \nActive!";
            Done_GameController.Powerup2 = false;
            StartCoroutine(powerup2());

        }
    

        if (powerupactive)
        {
            powerText.text = "Score Power Up \nActive!";

        }
		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}
			
		}
        //add delegates
        if (!SecondLevel)
        {
            if (score >= 300)
            {
                File.Create("Assets/ScoreLevel1.txt").Close();
                StreamWriter writer = new StreamWriter("Assets/ScoreLevel1.txt", true);
                writer.Write(score);
                writer.Close();
                SceneManager.LoadScene("SecondLevel");


                //	myPw += Turned;
            }
        }

        if (Input.GetKey(KeyCode.Q))
        {
            quit = true;
            quitText.text = "Quitting...";

            Application.Quit();
        }
    }
	
	IEnumerator SpawnWaves ()
	{
		yield return new WaitForSeconds (startWait);
		while (true)
		{
			for (int i = 0; i < hazardCount; i++)
			{
				GameObject hazard = hazards [Random.Range (0, hazards.Length)];
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
			
			if (gameOver)
			{
				restartText.text = "Press 'R' for Restart";
				restart = true;
				break;
			}
		}
	}
	
	public void AddScore (int newScoreValue)
	{
        if (scorePowerUp)
        {
            if (powerupactive)

            {
                
               
                StartCoroutine(powerup1());
                powerupactive = false;
                
            }
            score += (newScoreValue * 2);
        }
        else
            score += newScoreValue;

        UpdateScore ();
	}
	
	void UpdateScore ()
	{
		scoreText.text = "Score: " + score;
	}
	
	public void GameOver ()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
		StreamWriter writer = new StreamWriter (path, true);
		writer.WriteLine (score);
		writer.Close ();
	}

    IEnumerator powerup1()
    {

        yield return new WaitForSeconds(4);
        Done_GameController.scorePowerUp = false;
        powerText.text = "";
    }


    IEnumerator powerup2()
    {

        yield return new WaitForSeconds(4);
        Controller.fire = (float)0.25;
        powerText2.text = "";
    }

}