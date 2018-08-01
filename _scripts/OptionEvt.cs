using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionEvt : MonoBehaviour {

	public GameObject option_obj;
	public GameObject GM;

    public AudioSource bgm_title;
    public GameObject BGMmute, SEmute;
    public Sprite[] spr_mute;

    //아이디

    public Text id_txt;
    
	void Start () {

        //배경과 효과음 이미지변경
        bgm_title = this.gameObject.GetComponent<AudioSource>();
        if (PlayerPrefs.GetInt("soundmute", 0) == 1)
        {
            SEmute.GetComponent<Image>().sprite = spr_mute[1];

        }
        if (PlayerPrefs.GetInt("soundBGmute", 0) == 1)
        {
            BGMmute.GetComponent<Image>().sprite = spr_mute[1];
            bgm_title.mute = true;
        }
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
