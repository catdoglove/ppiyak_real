using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BookEvt : MonoBehaviour {
	public GameObject GM;
	public GameObject[] bookGM;
	string bookGM_str;

	public GameObject Book_obj,bookInfo_obj,infoImage1_obj,infoImage2_obj,infoBack_obj;
	public GameObject infoName1_obj, infoName2_obj;
	public Text infoText1_txt,infoText2_txt;
	public Sprite[] infoImage_spr,infoName_spr;

	public GameObject[] bookBasic_obj,bookGood_obj,bookAwesome_obj;

	public Sprite[] spr;

	List<Dictionary<string,object>> data;

	// Use this for initialization
	void Start () {
		//스프라이트동적할당과 게임오브젝트동적할당
		string str=this.gameObject.name;
		if (str.Length < 3) {
			data = CSVReader.Read ("ppiyak_info");
			for (int i = 0; i < 20; i++) {
				i++;
				infoImage_spr[i-1]=Resources.Load<Sprite>("collection/bookbg("+i+")");
				i--;
			}
			infoName_spr = Resources.LoadAll<Sprite> ("collection/ppiyak_name(250x50)");
		}

	}

	//도감열기
	public void bookOpen(){
		Book_obj.SetActive (true);
		for (int i = 0; i < 13; i++) {
			GM.GetComponent<BookEvt> ().bookGM_str = "Image (" + i + ")";
			GM.GetComponent<BookEvt> ().bookGM [i] = GameObject.Find (GM.GetComponent<BookEvt> ().bookGM_str);
		}
		for (int i = 0; i < 5; i++) {
			if (PlayerPrefs.GetInt ("basic_book" + i, 0) == 1) {
				GM.GetComponent<BookEvt> ().bookGM [i].GetComponent<Image> ().sprite = GM.GetComponent<GameEvt> ().ppiyakBasic_spr [i+1];
			}
		}



		/*
		//배열에 들어있는 병아리들 이미지 띄우기
		for(int i=0;i<bookBasic_obj.Length;i++){
			int c = PlayerPrefs.GetInt ("basic_book"+i,0);
			bookBasic_obj[i].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().ppiyakBasic_spr [0];
			if (c == 1) {
				bookBasic_obj[i].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().ppiyakBasic_spr [i];
			}
		}
		for(int i=0;i<bookGood_obj.Length;i++){
			int c = PlayerPrefs.GetInt ("good_book"+i,0);
			bookGood_obj[i].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().ppiyakBasic_spr [0];
			if (c == 1) {
				bookGood_obj[i].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().ppiyakGood_spr [i];
			}
		}
		for(int i=0;i<bookAwesome_obj.Length;i++){
			int c = PlayerPrefs.GetInt ("awesome_book"+i,0);
			bookAwesome_obj[i].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().ppiyakBasic_spr [0];
			if (c == 1) {
				bookAwesome_obj[i].GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().ppiyakAwesome_spr [i];
			}
		}
		*/
	}
		
	//도감정보자세히보기열기
	public void bookInfoOpen(){
		//자신의 이름을 불러옴
		string str=this.gameObject.name;
		//자신의 이름에 달린 번호를 불러옴
		int c_Num = int.Parse(str.Substring (6,2));
		int cal = c_Num;
		while (cal > 0) {
			cal = cal - 2; 
		}
		if (cal == 0) {
			GM.GetComponent<BookEvt> ().infoImage1_obj.SetActive (true);
			GM.GetComponent<BookEvt> ().infoBack_obj.SetActive (true);
			GM.GetComponent<BookEvt> ().infoImage1_obj.GetComponent<Image> ().sprite = GM.GetComponent<BookEvt> ().infoImage_spr [c_Num];
			GM.GetComponent<BookEvt> ().infoName1_obj.GetComponent<Image> ().sprite = GM.GetComponent<BookEvt> ().infoName_spr [c_Num];
			GM.GetComponent<BookEvt> ().infoText1_txt.text=""+GM.GetComponent<BookEvt> ().data [c_Num] ["info"];
			GM.GetComponent<BookEvt> ().infoImage2_obj.SetActive (false);
		} else {
			GM.GetComponent<BookEvt> ().infoImage2_obj.SetActive (true);
			GM.GetComponent<BookEvt> ().infoBack_obj.SetActive (true);
			GM.GetComponent<BookEvt> ().infoImage2_obj.GetComponent<Image> ().sprite = GM.GetComponent<BookEvt> ().infoImage_spr [c_Num];
			GM.GetComponent<BookEvt> ().infoName2_obj.GetComponent<Image> ().sprite = GM.GetComponent<BookEvt> ().infoName_spr [c_Num];
			GM.GetComponent<BookEvt> ().infoText2_txt.text=""+GM.GetComponent<BookEvt> ().data [c_Num] ["info"];
			GM.GetComponent<BookEvt> ().infoImage1_obj.SetActive (false);
		}

		//infoImage_obj.GetComponent<Image>().sprite=GM.GetComponent<GameEvt>().ppiyakAwesome_spr [c_Num];
	}

	public void infoBackClose(){
		GM.GetComponent<BookEvt> ().infoBack_obj.SetActive (false);
		GM.GetComponent<BookEvt> ().infoImage1_obj.SetActive (false);
		GM.GetComponent<BookEvt> ().infoImage2_obj.SetActive (false);
	}

	public void bookClose(){
		Book_obj.SetActive (false);
		infoBackClose ();
		GM.GetComponent<BookEvt> ().infoBack_obj.SetActive (true);
	}

}
