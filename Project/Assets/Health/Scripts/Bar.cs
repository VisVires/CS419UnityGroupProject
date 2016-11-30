using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class Bar : MonoBehaviour {
	[SerializeField]
	private float lerpSpeed;

	private float fillAmount;

	[SerializeField]
	private Image content;

	[SerializeField]
	private Text valueText; 

	public float MaxValue { get; set;}

	public float Value {

		set { 

			string[] tmp = valueText.text.Split (':');
			valueText.text = tmp [0] + ": " + value;

			fillAmount = Map (value, MaxValue);
		}
	}


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		HandleBar ();
	}

	private void HandleBar() {

		if (fillAmount != content.fillAmount) {
			content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
		}
	}

	private float Map (float value, float inMax) {

		return (value)/(inMax);

	}
	/*[SerializeField]
	private float lerpSpeed;

	private float fillAmount;

	[SerializeField]
	private Image content;

	[SerializeField]
	private Text valueText; 

	public float MaxValue { get; set;}

	public float Value {

		set { 

			string[] tmp = valueText.text.Split (':');
			valueText.text = tmp [0] + ": " + value;

			fillAmount = Map (value, MaxValue);
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		HandleBar ();
	}

	private void HandleBar() {

		if (fillAmount != content.fillAmount) {
			content.fillAmount = Mathf.Lerp(content.fillAmount, fillAmount, Time.deltaTime * lerpSpeed);
		}
	}

	private float Map (float value, float inMax) {
	
		return (value)/(inMax);

	}*/
}
