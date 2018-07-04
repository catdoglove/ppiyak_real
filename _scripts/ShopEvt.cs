using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEvt : MonoBehaviour {

	public GameObject shop_obj;
	public GameObject GM;

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
}
