using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEvt : MonoBehaviour {

	public GameObject shop_obj;
	public GameObject GM;

	public GameObject back_obj,bottom_obj,incubator_obj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void shopOpen(){
		GM.GetComponent<ShopEvt> ().shop_obj.SetActive (true);
	}

	public void shopClose(){
		GM.GetComponent<ShopEvt> ().shop_obj.SetActive (false);
	}

	public void shopChangeBack(){
		back_obj.SetActive (true);
		bottom_obj.SetActive (false);
		incubator_obj.SetActive (false);
	}
	public void shopChangeBottom(){
		back_obj.SetActive (false);
		bottom_obj.SetActive (true);
		incubator_obj.SetActive (false);
	}
	public void shopChangeincubator(){
		back_obj.SetActive (false);
		bottom_obj.SetActive (false);
		incubator_obj.SetActive (true);
	}
}
