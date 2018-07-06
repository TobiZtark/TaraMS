using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Playerpicki : MonoBehaviour {
	
	public AudioSource sounds;
	private int count;
	public Text Count;
	private GameObject DisplayText;
	private GameObject WinCanvas;
	private GameObject Tara;
	private GameObject Auny;
	Animator anim;
	int pickHash= Animator.StringToHash("Pick");
	// Use this for initialization
	void Awake(){
		DisplayText = GameObject.Find ("DisplayText");
		WinCanvas = GameObject.Find ("WinCanvas");
		Tara = GameObject.Find ("Tara");
		Auny = GameObject.Find ("Auny Zira");
	}
	void Start () {
		anim = GetComponent<Animator> ();
		count = 0;
		SetCount ();
		sounds = GetComponent<AudioSource> ();
		DisplayText.SetActive (true);
		WinCanvas.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (count==5) {
			WinCanvas.SetActive (true);
			DisplayText.SetActive (false);
			Tara.SetActive(false);
			Auny.SetActive(false);
			//Application.LoadLevel("Game 0");
		}
	}
	void OnTriggerEnter (Collider other)
	{
		
		if (other.gameObject.tag == "Pickable")
		{
			//anim.SetTrigger(pickHash);
			other.gameObject.SetActive(false);
			count = count +1; 
			SetCount ();
			sounds.Play ();
		}
		
	}
	
	void SetCount()
	{
		Count.text = "Score: " + count.ToString ();
	}
}
