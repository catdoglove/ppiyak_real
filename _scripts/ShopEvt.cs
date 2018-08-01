using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopEvt : MonoBehaviour {

	public GameObject shop_obj, shop_btn_bg, shop_btn_under, shop_btn_nest;
	public GameObject GM;
    public Sprite [] btnSpr; //0,3 1,4 2,5

	public GameObject back_obj,bottom_obj,incubator_obj;
	public GameObject shopBuyPopup_obj;
	public int[] backPrice_i, bottomPrice_i, incubatorPrice_i;
	public GameObject[] backLock_obj,bottomLock_obj,incubatorLock_obj;

	//효과 설명

	public string[] BackEffect_str,BottomEffect_str,incubatorEffect_str;
	public Text shopEffect_txt;

	int shopIndex_i,shopItem_i;

	public Text shopCoin_txt;
	public GameObject coinPopup_obj;

	// Use this for initialization
	void Start () {
	}
	//상점열기
	public void shopOpen(){
		GM.GetComponent<ShopEvt> ().shop_obj.SetActive (true);
		if(backLock_obj[0]==null){
			backLock_obj = GameObject.FindGameObjectsWithTag ("backlock");
		}
		for(int i=0;i<16;i++){
			if (PlayerPrefs.GetInt ("back" + i, 0) == 1) {
				backLock_obj [i].SetActive (false);
			}
		}
		string str = PlayerPrefs.GetString ("code", "");
		GM.GetComponent<GameBtnEvt> ().gameCoin_i = PlayerPrefs.GetInt (str, 0);
		shopCoin_txt.text = "" + GM.GetComponent<GameBtnEvt> ().gameCoin_i;
	}
	//상점닫기
	public void shopClose(){
		GM.GetComponent<ShopEvt> ().shop_obj.SetActive (false);
	}
	public void shopChangeBack(){
		back_obj.SetActive (true);
		bottom_obj.SetActive (false);
		incubator_obj.SetActive (false);
        shop_btn_bg.GetComponent<Image>().sprite = btnSpr[0];
        shop_btn_under.GetComponent<Image>().sprite = btnSpr[4];
        shop_btn_nest.GetComponent<Image>().sprite = btnSpr[5];
    }
	public void shopChangeBottom(){
		back_obj.SetActive (false);
		bottom_obj.SetActive (true);
		incubator_obj.SetActive (false);
		if(bottomLock_obj[0]==null){
			bottomLock_obj = GameObject.FindGameObjectsWithTag ("bottomlock");
		}
		for(int i=0;i<16;i++){
			if (PlayerPrefs.GetInt ("bottom" + i, 0) == 1) {
				bottomLock_obj [i].SetActive (false);
			}
		}
        shop_btn_bg.GetComponent<Image>().sprite = btnSpr[3];
        shop_btn_under.GetComponent<Image>().sprite = btnSpr[1];
        shop_btn_nest.GetComponent<Image>().sprite = btnSpr[5];
    }
	public void shopChangeincubator(){
		incubator_obj.SetActive (true);
		back_obj.SetActive (false);
		bottom_obj.SetActive (false);

		if(incubatorLock_obj[0]==null){
			incubatorLock_obj = GameObject.FindGameObjectsWithTag ("incubator");
		}
		for(int i=0;i<16;i++){
			if (PlayerPrefs.GetInt ("incubator" + i, 0) == 1) {
				incubatorLock_obj [i].SetActive (false);
			}
		}
        shop_btn_bg.GetComponent<Image>().sprite = btnSpr[3];
        shop_btn_under.GetComponent<Image>().sprite = btnSpr[4];
        shop_btn_nest.GetComponent<Image>().sprite = btnSpr[2];
    }
	//샵구매인덱스
	#region 

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

	#endregion

	public void buyShopBack(){
		if (PlayerPrefs.GetInt ("back" + shopIndex_i, 0) == 1) {
			GM.GetComponent<GameBtnEvt> ().gameBack_obj.GetComponent<Image> ().sprite = GM.GetComponent<GameBtnEvt> ().back_spr [shopIndex_i+1];
		PlayerPrefs.SetInt ("backset", shopIndex_i);
		} else {
		shopBuyPopup_obj.SetActive(true);
			//shopEffect_txt.text = BackEffect_str [shopIndex_i];
		shopItem_i = 1;
		}
	}

	public void buyShopBottom(){
		if (PlayerPrefs.GetInt ("bottom" + shopIndex_i, 0) == 1) {
		GM.GetComponent<GameBtnEvt> ().gameBottom_obj.GetComponent<Image> ().sprite = GM.GetComponent<GameBtnEvt> ().bottom_spr [shopIndex_i+1];
		PlayerPrefs.SetInt ("bottomset", shopIndex_i);
		} else {
		shopBuyPopup_obj.SetActive(true);
			//shopEffect_txt.text = BottomEffect_str [shopIndex_i];
		shopItem_i = 2;
		}
	}
		
	public void buyShopIncubator(){
		if (PlayerPrefs.GetInt ("incubator" + shopIndex_i, 0) == 1) {
		GM.GetComponent<GameBtnEvt> ().gameIncubator1_obj.GetComponent<Image> ().sprite = GM.GetComponent<GameBtnEvt> ().incubator_spr [shopIndex_i+1];
		GM.GetComponent<GameBtnEvt> ().gameIncubator2_obj.GetComponent<Image> ().sprite = GM.GetComponent<GameBtnEvt> ().incubator_spr [shopIndex_i+1];
		PlayerPrefs.SetInt ("incubatorset", shopIndex_i);
		} else {
		shopBuyPopup_obj.SetActive(true);
			//shopEffect_txt.text = incubatorEffect_str [shopIndex_i];
		shopItem_i = 3;
		}
	}

	public void buyYes(){
		int price = 0;
		switch (shopItem_i) {
		case 1:
			price = backPrice_i[shopIndex_i];
			break;
		case 2:
			price = bottomPrice_i[shopIndex_i];
			break;
		case 3:
			price = incubatorPrice_i[shopIndex_i];
			break;
		}
		if (GM.GetComponent<GameBtnEvt> ().gameCoin_i >= price) {
			switch (shopItem_i) {
			case 1:
				GM.GetComponent<GameBtnEvt> ().gameBack_obj.GetComponent<Image> ().sprite = GM.GetComponent<GameBtnEvt> ().back_spr [shopIndex_i+1];
				PlayerPrefs.SetInt ("backset", shopIndex_i);
				PlayerPrefs.SetInt ("back" + shopIndex_i, 1);
				backLock_obj [shopIndex_i].SetActive (false);
				break;
			case 2:
				GM.GetComponent<GameBtnEvt> ().gameBottom_obj.GetComponent<Image> ().sprite = GM.GetComponent<GameBtnEvt> ().bottom_spr [shopIndex_i+1];
				PlayerPrefs.SetInt ("bottomset", shopIndex_i);
				PlayerPrefs.SetInt ("bottom" + shopIndex_i, 1);
				bottomLock_obj [shopIndex_i].SetActive (false);
				break;
			case 3:
				GM.GetComponent<GameBtnEvt> ().gameIncubator1_obj.GetComponent<Image> ().sprite = GM.GetComponent<GameBtnEvt> ().incubator_spr [shopIndex_i+1];
				GM.GetComponent<GameBtnEvt> ().gameIncubator2_obj.GetComponent<Image> ().sprite = GM.GetComponent<GameBtnEvt> ().incubator_spr [shopIndex_i+1];
				PlayerPrefs.SetInt ("incubatorset", shopIndex_i);
				PlayerPrefs.SetInt ("incubator" + shopIndex_i, 1);
				incubatorLock_obj [shopIndex_i].SetActive (false);
				break;
			}
			string str = PlayerPrefs.GetString ("code", "");
			GM.GetComponent<GameBtnEvt> ().gameCoin_i = PlayerPrefs.GetInt (str, 0);
			GM.GetComponent<GameBtnEvt> ().gameCoin_i = GM.GetComponent<GameBtnEvt> ().gameCoin_i - price;
			shopCoin_txt.text = "" + GM.GetComponent<GameBtnEvt> ().gameCoin_i;
			PlayerPrefs.SetInt (str, GM.GetComponent<GameBtnEvt> ().gameCoin_i);
		} else {
			coinPopup_obj.SetActive (true);
		}
		PlayerPrefs.Save ();
		shopBuyPopup_obj.SetActive (false);
	}

	public void buyNo(){
		shopBuyPopup_obj.SetActive (false);
	}
	public void coinClose(){
		coinPopup_obj.SetActive (false);
	}

}
