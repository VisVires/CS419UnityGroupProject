using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> 
{
	public TowerButton ClickedBtn { get; set; }

	[SerializeField]
	public int currency;
	public float secondsBetweenMonsters = 10.0f;
	private bool newMonster = true;
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
			//this.currencyTxt.text = "<color=lime>$</color> " + value.ToString();
			if (value <= 50) {
				this.currencyTxt.text = "<color=red>$</color> " + value.ToString();
				this.currencyTxt.color = new Color (1, 0, 0, 1);
			} else {
				this.currencyTxt.text = "<color=lime>$</color> " + value.ToString();
			}
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

		if (newMonster) {
			StartCoroutine (SpawnWave());
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


