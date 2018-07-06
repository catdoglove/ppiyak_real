using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopEvt : MonoBehaviour {

	public GameObject shop_obj;
	public GameObject GM;

	public GameObject back_obj,bottom_obj,incubator_obj;

	int shopIndex_i;

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

	public void buyShopBack0(){
		shopIndex_i = 0;
	}
	public void buyShopBack1(){
		shopIndex_i = 1;
	}
	public void buyShopBack2(){
		shopIndex_i = 2;
	}
	public void buyShopBack3(){
		shopIndex_i = 3;
	}
	public void buyShopBack4(){
		shopIndex_i = 4;
	}
	public void buyShopBack5(){
		shopIndex_i = 5;
	}
	public void buyShopBack6(){
		shopIndex_i = 6;
	}
	public void buyShopBack7(){
		shopIndex_i = 7;
	}
	public void buyShopBack8(){
		shopIndex_i = 8;
	}
	public void buyShopBack9(){
		shopIndex_i = 9;
	}
	public void buyShopBack10(){
		shopIndex_i = 10;
	}
	public void buyShopBack11(){
		shopIndex_i = 11;
	}
	public void buyShopBack12(){
		shopIndex_i = 12;
	}
	public void buyShopBack13(){
		shopIndex_i = 13;
	}
	public void buyShopBack14(){
		shopIndex_i = 14;
	}
	public void buyShopBack15(){
		shopIndex_i = 15;
	}
	public void buyShopBack16(){
		shopIndex_i = 16;
	}
	public void buyShopBack17(){
		shopIndex_i = 17;
	}
	public void buyShopBack18(){
		shopIndex_i = 18;
	}

	public void buyShopBack(){
		if (PlayerPrefs.GetInt ("back" + shopIndex_i, 0) == 1) {
			
		}
	}

	public void buyShopBottom(){

	}
		
	public void buyShopIncubator(){

	}
}
