using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionEvt : MonoBehaviour {

	public GameObject option_obj;
	public GameObject GM;

	//아이디

	public Text id_txt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void optionOpen(){
		GM.GetComponent<OptionEvt> ().option_obj.SetActive (true);
		string str = PlayerPrefs.GetString ("code", "");
		id_txt.text = str;
	}

	public void optionClose(){
		GM.GetComponent<OptionEvt> ().option_obj.SetActive (false);
	}
}
