using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionEvt : MonoBehaviour {

	public GameObject option_obj;
	public GameObject GM;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void optionOpen(){
		GM.GetComponent<OptionEvt> ().option_obj.SetActive (true);
	}

	public void optionClose(){
		GM.GetComponent<OptionEvt> ().option_obj.SetActive (false);
	}
}
