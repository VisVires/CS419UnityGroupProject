using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> 
{
	public TowerButton ClickedBtn { get; set; }

	private int currency;
	public float secondsBetweenMonsters = 10.0f;
	private bool newMonster = true;
	[SerializeField]
	private Text currencyTxt;
	//public Text timerText;
	public float myTimer = 10;
	public ObjectPool Pool { get; set; }

	public int Currency
	{
		get
		{
			return currency;
		}

		set
		{
			this.currency = value;
			this.currencyTxt.text = "<color=lime>$</color>" + value.ToString();
		}
	}


	private void Awake()
	{
		Pool = GetComponent<ObjectPool>();

	}

	// Use this for initialization
	void Start () 
	{
		//timerText = GetComponent<Text> ();
		Currency = 420;
	}

	// Update is called once per frame
	void Update () 
	{
		HandleEscape();

		if (newMonster) {
			StartCoroutine (SpawnWave());
		}

		/*myTimer -= Time.deltaTime; 
		//Debug.Log ("Timer Text before To String: " + timerText.text);
		//timerText.text = myTimer.ToString ("f0");
		//Debug.Log ("timerText.text: " + timerText.text);
		//Debug.Log ("My Timer: " + myTimer);
		//Debug.Log ("My Timer To String; " + myTimer.ToString ("f0"));
		//print (myTimer);
		if (myTimer <= 1) {
			//myTimer = 0;
			//timerText.text = "Time's up!"; 
		}*/

		GoToNextLevel ();
	}

	private void GoToNextLevel() {
		if (myTimer <= 0) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}

	public void PickTower(TowerButton towerButton)
	{
		if (Currency >= towerButton.Price)
		{
			this.ClickedBtn = towerButton;

			Hover.Instance.Activate(towerButton.Sprite);
		}
	}

	public void BuyTower()
	{
		if (currency >= ClickedBtn.Price)
		{
			Currency -= ClickedBtn.Price;

			Hover.Instance.Deactivate();
		}

	}

	private void HandleEscape()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Hover.Instance.Deactivate();
		}
	}

	public void StartWave()
	{
			StartCoroutine(SpawnWave());
	}	

	/*private IEnumerator SpawnWave()
	{
		newMonster = false;
		Completed.BoardManager.Instance.GeneratePath();
		int monsterIndex = Random.Range(0, 0);

		string type = string.Empty;
		//print (monsterIndex);
		switch(monsterIndex)
		{
		case 0:
			type = "greenPlane";
			break;
		case 1: 
			type = "grayPlane";
			break;
		case 2: 
			type = "ninjaEnemy";
			break;
		}


		Monster monster = Pool.GetObject(type).GetComponent<Monster>();
		monster.Spawn();
		yield return new WaitForSeconds(2.5f);
		newMonster = true;
	}*/

	private IEnumerator SpawnWave()
	{
		newMonster = false;	
		Completed.BoardManager.Instance.GeneratePath();
		float fmonsterIndex = Random.Range(0.0f, 2.99f);
		int monsterIndex = (int)fmonsterIndex;
		string type = string.Empty;
		Debug.Log (monsterIndex);
		switch(monsterIndex)
		{
		//case 0:
			//type = "greenPlane";
			//break;

			case 0:
				type = "Ninja";
				break;
			case 1: 
				type = "Golem";
				break;
			case 2: 
				type = "Zombie";
				break;
		}


		Monster monster = Pool.GetObject(type).GetComponent<Monster>();
		monster.Spawn();
		yield return new WaitForSeconds(secondsBetweenMonsters);
		newMonster = true;
	}

}


/*public class GameManager : Singleton<GameManager> 
{
	public TowerButton ClickedBtn { get; set; }

	private int currency;
	
	[SerializeField]
	private Text currencyTxt;
	
	public ObjectPool Pool { get; set; }
	
	public int Currency
	{
		get
		{
			return currency;
		}
		
		set
		{
			this.currency = value;
			this.currencyTxt.text = "<color=lime>$</color>" + value.ToString();
		}
	}
	
	
	private void Awake()
	{
		Pool = GetComponent<ObjectPool>();

	}

	// Use this for initialization
	void Start () 
	{
		Currency = 420;
	}
	
	// Update is called once per frame
	void Update () 
	{
		HandleEscape();
	}
	
	public void PickTower(TowerButton towerButton)
	{
		if (Currency >= towerButton.Price)
		{
			this.ClickedBtn = towerButton;
			
			Hover.Instance.Activate(towerButton.Sprite);
		}
	}
	
	public void BuyTower()
	{
		if (currency >= ClickedBtn.Price)
		{
			Currency -= ClickedBtn.Price;
			
			Hover.Instance.Deactivate();
		}
		
	}
	
	private void HandleEscape()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Hover.Instance.Deactivate();
		}
	}

	public void StartWave()
	{
			StartCoroutine(SpawnWave());
	}	
	
	
	private IEnumerator SpawnWave()
	{
		Completed.BoardManager.Instance.GeneratePath();
		int monsterIndex = Random.Range(0, 0);
		
		string type = string.Empty;
		//print (monsterIndex);
		switch(monsterIndex)
		{
			case 0:
				type = "greenPlane";
				break;
			case 1: 
				type = "grayPlane";
				break;
			case 2: 
				type = "ninjaEnemy";
				break;
		}

		
		Monster monster = Pool.GetObject(type).GetComponent<Monster>();
		monster.Spawn();
		yield return new WaitForSeconds(2.5f);
	}
	
}*/
