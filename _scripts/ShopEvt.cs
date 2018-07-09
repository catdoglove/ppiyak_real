using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopEvt : MonoBehaviour {

	public GameObject shop_obj, shop_btn_bg, shop_btn_under, shop_btn_nest;
	public GameObject GM;
    public Sprite [] btnSpr; //0,3 1,4 2,5

	public GameObject back_obj,bottom_obj,incubator_obj;

	int shopIndex_i;
    

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
        shop_btn_bg.GetComponent<Image>().sprite = btnSpr[0];
        shop_btn_under.GetComponent<Image>().sprite = btnSpr[4];
        shop_btn_nest.GetComponent<Image>().sprite = btnSpr[5];

    }
	public void shopChangeBottom(){
		back_obj.SetActive (false);
		bottom_obj.SetActive (true);
		incubator_obj.SetActive (false);
        shop_btn_bg.GetComponent<Image>().sprite = btnSpr[3];
        shop_btn_under.GetComponent<Image>().sprite = btnSpr[1];
        shop_btn_nest.GetComponent<Image>().sprite = btnSpr[5];
    }
	public void shopChangeincubator(){
		back_obj.SetActive (false);
		bottom_obj.SetActive (false);
		incubator_obj.SetActive (true);
        shop_btn_bg.GetComponent<Image>().sprite = btnSpr[3];
        shop_btn_under.GetComponent<Image>().sprite = btnSpr[4];
        shop_btn_nest.GetComponent<Image>().sprite = btnSpr[2];
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
		//if (PlayerPrefs.GetInt ("back" + shopIndex_i, 0) == 1) {
			GM.GetComponent<GameBtnEvt> ().gameBack_obj.GetComponent<Image> ().sprite = GM.GetComponent<GameBtnEvt> ().back_spr [shopIndex_i+1];
		//} else {
		//}
	}

	public void buyShopBottom(){
		//if (PlayerPrefs.GetInt ("bottom" + shopIndex_i, 0) == 1) {
		GM.GetComponent<GameBtnEvt> ().gameBottom_obj.GetComponent<Image> ().sprite = GM.GetComponent<GameBtnEvt> ().bottom_spr [shopIndex_i+1];
		//} else {
		//}
	}
		
	public void buyShopIncubator(){
		//if (PlayerPrefs.GetInt ("incubator" + shopIndex_i, 0) == 1) {
		GM.GetComponent<GameBtnEvt> ().gameIncubator1_obj.GetComponent<Image> ().sprite = GM.GetComponent<GameBtnEvt> ().incubator_spr [shopIndex_i+1];
		GM.GetComponent<GameBtnEvt> ().gameIncubator2_obj.GetComponent<Image> ().sprite = GM.GetComponent<GameBtnEvt> ().incubator_spr [shopIndex_i+1];
		//} else {
		//}
	}
}
