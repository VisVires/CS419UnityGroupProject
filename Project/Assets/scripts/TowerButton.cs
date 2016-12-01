﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour {

	[SerializeField]
	private GameObject towerPrefab;
	
	[SerializeField]
	private Sprite sprite;
	
	[SerializeField]
	private int price;
	
	[SerializeField]
	private Text priceText;

	[SerializeField]
	private Stat health;

	void Awake(){
		health.Initialize ();
	}
	
	public GameObject TowerPrefab
	{
		get
		{
			return towerPrefab;
		}
	}
	
	public Sprite Sprite
	{
		get
		{
			return sprite;
		}
	}
	
	public int Price
	{
		get
		{
			return price;
		}
	}
	
	private void Start()
	{
		priceText.text = "$" + price;
	}
}
