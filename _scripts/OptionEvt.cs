using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionEvt : MonoBehaviour {

	public GameObject option_obj, help_obj;
	public GameObject GM;

    public AudioSource bgm_title, bgm_first;
    public GameObject BGMmute, SEmute;
    public Sprite[] spr_mute, spr_helps;

    //아이디
    public Text id_txt;
    int help_i;


    void Start () {
		//주석
        //알게된 정보 : gameobject = GM으로 나오고 go대신 직접 변수쓰면 아래와 같음
        bgm_first = bgm_first.GetComponent<AudioSource>();

        //배경과 효과음 이미지변경
        bgm_title = this.gameObject.GetComponent<AudioSource>();
        
        //배경음이 두개라 해야함 (밑에서 mute상태에 따라 켜질예정)
        GM.GetComponent<OptionEvt>().bgm_title.mute = true;

        if (PlayerPrefs.GetInt("soundmute", 0) == 1)
        {
            SEmute.GetComponent<Image>().sprite = spr_mute[1];
        }
        if (PlayerPrefs.GetInt("soundBGmute", 0) == 1)
        {
            BGMmute.GetComponent<Image>().sprite = spr_mute[1];
            bgm_title.mute = true;
            bgm_first.mute = true;
        }
    }

    public void bgmCheck()
    { //타이틀용 : 배경음이 두개라서 해야함
        if (PlayerPrefs.GetInt("soundBGmute", 0) == 1)
        {
            bgm_title.mute = true;
        }
        else
        {
            bgm_title.Play();
            bgm_title.mute = false;
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

    public void helpOpen()
    {
        help_obj.SetActive(true);
    }
    
    public void helpClose()
    {
        if (help_i == 0)
        {
            help_obj.GetComponent<Image>().sprite = spr_helps[help_i+1];
            help_i = 1;
        }else if (help_i == 1)
        {
            help_obj.SetActive(false);
            help_i = 0;
            help_obj.GetComponent<Image>().sprite = spr_helps[help_i];
        }
    }
}
