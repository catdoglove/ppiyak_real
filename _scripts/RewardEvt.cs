using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RewardEvt : MonoBehaviour {

	public Sprite[] reward_spr_u,reward_spr_l,reward_spr_r,reward_spr_b;
	public GameObject[] reward_obj, success_obj;
	public Button[] reward_btn;
	public int[] coin_i;

	public int rewardIndex_i;

	public GameObject GM, rewardWindow;
    

    public void opienWindow()
    {
        rewardWindow.SetActive(true);
    }


    public void closenWindow()
    {
        rewardWindow.SetActive(false);
    }

    public void openReward(){
		//예능
		if(PlayerPrefs.GetInt ("reward1",0)==4){
			
		}else if (PlayerPrefs.GetInt ("basic_book" + 2, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 1, 2);
			if (PlayerPrefs.GetInt ("basic_book" + 4, 0) == 1) {
				PlayerPrefs.SetInt ("reward" + 1, 1);
			}
		} else if(PlayerPrefs.GetInt ("basic_book" + 4, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 1, 3);
		}
		//사막
		if(PlayerPrefs.GetInt ("reward2",0)==4){

		}else if (PlayerPrefs.GetInt ("good_book" + 1, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 2, 2);
			if (PlayerPrefs.GetInt ("good_book" + 2, 0) == 1) {
				PlayerPrefs.SetInt ("reward" + 2, 1);
			}
		} else if(PlayerPrefs.GetInt ("good_book" + 2, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 2, 3);
		}
		//야근
		if(PlayerPrefs.GetInt ("reward3",0)==4){

		}else if (PlayerPrefs.GetInt ("basic_book" + 3, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 3, 2);
			if (PlayerPrefs.GetInt ("good_book" + 6, 0) == 1) {
				PlayerPrefs.SetInt ("reward" + 3, 1);
			}
		} else if(PlayerPrefs.GetInt ("good_book" + 6, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 3, 3);
		}
		//바캉
		if(PlayerPrefs.GetInt ("reward4",0)==4){

		}else if (PlayerPrefs.GetInt ("good_book" + 4, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 4, 2);
			if (PlayerPrefs.GetInt ("awesome_book" + 3, 0) == 1) {
				PlayerPrefs.SetInt ("reward" + 4, 1);
			}
		} else if(PlayerPrefs.GetInt ("awesome_book" + 3, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 4, 3);
		}
		//달콤
		if(PlayerPrefs.GetInt ("reward5",0)==4){

		}else if (PlayerPrefs.GetInt ("good_book" + 3, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 5, 2);
			if (PlayerPrefs.GetInt ("awesome_book" + 4, 0) == 1) {
				PlayerPrefs.SetInt ("reward" + 5, 1);
			}
		} else if(PlayerPrefs.GetInt ("awesome_book" + 4, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 5, 3);
		}
		//추워
		if(PlayerPrefs.GetInt ("reward6",0)==4){

		}else if (PlayerPrefs.GetInt ("awesome_book" + 0, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 6, 2);
			if (PlayerPrefs.GetInt ("awesome_book" + 1, 0) == 1) {
				PlayerPrefs.SetInt ("reward" + 6, 1);
			}
		} else if(PlayerPrefs.GetInt ("awesome_book" + 1, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 6, 3);
		}
		//단칸

		if(PlayerPrefs.GetInt ("reward7",0)==4){

		}else if (PlayerPrefs.GetInt ("good_book" + 7, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 7, 2);
			if (PlayerPrefs.GetInt ("awesome_book" + 6, 0) == 1) {
				PlayerPrefs.SetInt ("reward" + 7, 1);
			}
		} else if(PlayerPrefs.GetInt ("awesome_book" + 6, 0) == 1) {
			PlayerPrefs.SetInt ("reward" + 7, 3);
		}

		PlayerPrefs.Save ();
		
		for (int i = 0; i < 8; i++) {
			//reward_btn [i].GetComponent<Button> ().interactable = true;
			if (PlayerPrefs.GetInt ("reward" + i, 0) == 4) {
				reward_obj [i].GetComponent<Image> ().sprite = reward_spr_b [i];
				reward_btn [i].GetComponent<Button> ().interactable = false;
                success_obj[i].SetActive(true);
            } else if (PlayerPrefs.GetInt ("reward" + i, 0) == 1){
				reward_obj [i].GetComponent<Image> ().sprite = reward_spr_b [i];
				reward_btn [i].GetComponent<Button> ().interactable = true;
			} else if (PlayerPrefs.GetInt ("reward" + i, 0) == 2){
				reward_obj [i].GetComponent<Image> ().sprite = reward_spr_l [i];
				reward_btn [i].GetComponent<Button> ().interactable = false;
                
            } else if (PlayerPrefs.GetInt ("reward" + i, 0) == 3){
				reward_obj [i].GetComponent<Image> ().sprite = reward_spr_r [i];
				reward_btn [i].GetComponent<Button> ().interactable = false;
                
            }
		}

	}

	public void getReward(){
		reward_btn [rewardIndex_i].GetComponent<Button> ().interactable = false;
        success_obj[rewardIndex_i].SetActive(true);
        string str = PlayerPrefs.GetString ("code", "");
		GM.GetComponent<GameBtnEvt> ().gameCoin_i = PlayerPrefs.GetInt (str, 0);
		GM.GetComponent<GameBtnEvt> ().gameCoin_i = GM.GetComponent<GameBtnEvt> ().gameCoin_i + coin_i[rewardIndex_i];
		PlayerPrefs.SetInt (str, GM.GetComponent<GameBtnEvt> ().gameCoin_i);
		PlayerPrefs.SetInt ("reward" + rewardIndex_i, 4);
		PlayerPrefs.Save ();
	}

	//업적리워드번호숨겨놓음
	#region
	public void getIndex0(){
		rewardIndex_i = 0;
	}

	public void getIndex1(){
		rewardIndex_i = 1;
	}

	public void getIndex2(){
		rewardIndex_i = 2;
	}

	public void getIndex3(){
		rewardIndex_i = 3;
	}

	public void getIndex4(){
		rewardIndex_i = 4;
	}

	public void getIndex5(){
		rewardIndex_i = 5;
	}

	public void getIndex6(){
		rewardIndex_i = 6;
	}

	public void getIndex7(){
		rewardIndex_i = 7;
	}

	#endregion

}
