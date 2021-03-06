﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundEvt : MonoBehaviour {

	public AudioSource se_touch;
	public AudioClip sp_touch;
	public AudioSource se_touchegg,se_buy,se_born, se_fail, se_fever;
	public AudioClip sp_touchegg,sp_buy,sp_born, sp_fail, sp_fever;
	public GameObject BGMmute,SEmute;
	public Sprite [] spr_mute;

    public GameObject GM;


    // Use this for initialization
    void Start () {
		
		se_touch = gameObject.GetComponent<AudioSource> ();
		se_touch.clip= sp_touch;

		se_touchegg = gameObject.GetComponent<AudioSource> ();
		se_touchegg.clip=sp_touchegg;

		se_buy = gameObject.GetComponent<AudioSource> ();
		se_buy.clip=sp_buy;

		se_born = gameObject.GetComponent<AudioSource> ();
		se_born.clip=sp_born;

        se_fail = gameObject.GetComponent<AudioSource>();
        se_fail.clip = sp_fail;

        se_fever = gameObject.GetComponent<AudioSource>();
        se_fever.clip = sp_fever;


        if (PlayerPrefs.GetInt ("soundmute", 0)==1) {
			se_touch.mute = true;
			se_buy.mute = true;
			se_touchegg.mute = true;
			se_born.mute = true;
            se_fail.mute = true;
            se_fever.mute = true;
            PlayerPrefs.SetInt("soundmute",1);
		}
		
	}


    private void Update()
    {
        if(GM.GetComponent<UnityADS>().soundck == 99)
        {
            feverSound();
            GM.GetComponent<UnityADS>().soundck = 0;
        }
    }

    public void touchSound()
    {
        se_touch = gameObject.GetComponent<AudioSource>();
        se_touch.clip = sp_touch;
        se_touch.loop = false;
        se_touch.Play();
    }


    public void bornSound()
    {
        se_born = gameObject.GetComponent<AudioSource>();
        se_born.clip = sp_born;
        se_born.loop = false;
        se_born.Play();
    }

    public void touchEggSound(){

        if(PlayerPrefs.GetInt("bornppiyak", 0) == 99) // 태어남
        {
            se_born = gameObject.GetComponent<AudioSource>();
            se_born.clip = sp_born;
            se_born.loop = false;
            se_born.Play();

            PlayerPrefs.SetInt("bornppiyak", 11);

        }
        else
        {
            se_touchegg = gameObject.GetComponent<AudioSource>();
            se_touchegg.clip = sp_touchegg;
            se_touchegg.loop = false;
            se_touchegg.Play();

        }

	}

	public void buySound(){
        if (PlayerPrefs.GetInt("buyorfail", 0)==3)
        {
            se_buy = gameObject.GetComponent<AudioSource>();
            se_buy.clip = sp_buy;
            se_buy.loop = false;
            se_buy.Play();
        }
        else if(PlayerPrefs.GetInt("buyorfail", 0)==4)
        {
            se_fail = gameObject.GetComponent<AudioSource>();
            se_fail.clip = sp_fail;
            se_fail.loop = false;
            se_fail.Play();
        }
	}


    public void feverSound()
    {
        se_fever = gameObject.GetComponent<AudioSource>();
        se_fever.clip = sp_fever;
        se_fever.loop = false;
        se_fever.Play();
    }



    public void soundMute(){
		if (se_touch.mute == false) {
			se_touch.mute = true;
			se_buy.mute = true;
			se_touchegg.mute = true;
			se_born.mute = true;
            se_fail.mute = true;
            se_fever.mute = true;

            SEmute.GetComponent<Image>().sprite=spr_mute[1];
			PlayerPrefs.SetInt("soundmute",1);
		} else {
			se_touch.mute = false;
			se_buy.mute = false;
			se_touchegg.mute = false;
			se_born.mute = false;
            se_fail.mute = false;
            se_fever.mute = false;
            SEmute.GetComponent<Image>().sprite=spr_mute[0];
			PlayerPrefs.SetInt("soundmute",0);
		}
	}

	public void soundBGMute(){        

        if (GM.GetComponent<OptionEvt>().bgm_title.mute == false) {
            GM.GetComponent<OptionEvt>().bgm_title.mute = true;
			BGMmute.GetComponent<Image>().sprite=spr_mute[1];
			PlayerPrefs.SetInt("soundBGmute",1);
		} else {
            GM.GetComponent<OptionEvt>().bgm_title.mute = false;
            BGMmute.GetComponent<Image>().sprite=spr_mute[0];
			PlayerPrefs.SetInt("soundBGmute",0);
		}

	}


}
