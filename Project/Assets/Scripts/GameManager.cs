using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager> 
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
			/*case 1: 
				type = "grayPlane";
				break;
			case 2: 
				type = "ninjaEnemy";
				break;*/
		}

		
		Monster monster = Pool.GetObject(type).GetComponent<Monster>();
		monster.Spawn();
		yield return new WaitForSeconds(2.5f);
	}
	
}
