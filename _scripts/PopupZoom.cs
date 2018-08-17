using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupZoom : MonoBehaviour
{
    public GameObject popupWindow,GM;
    Vector3 scalee;
    private Exception e;
    Color color;

    // Use this for initialization
    void Start () {
    }

    public void ZoomIn()
    {
        scalee = transform.localScale;
        if(PlayerPrefs.GetInt("popupeff", 0) == 99)
        {
            StartCoroutine("popupZoomIn");
        }

    }
       

    IEnumerator popupZoomIn()
    {        
        scalee = transform.localScale;
        scalee.x = 1.2f;
        scalee.y = 1.2f;
        transform.localScale = scalee;
        while (scalee.x < 1.35f)
        {
            yield return new WaitForSeconds(0.01f);
            scalee.x = scalee.x + 0.05f;
            scalee.y = scalee.y + 0.05f;
            transform.localScale = scalee;
        }
    }
    
    public void ZoomIn2()
    {
        StartCoroutine("popupZoomIn2");
    }

    IEnumerator popupZoomIn2()
    {
        scalee.x = 1.25f;
        scalee.y = 1.25f;
        transform.localScale = scalee;
        scalee = transform.localScale;
        while (scalee.x < 1.45f)
        {
            yield return new WaitForSeconds(0.01f);
            scalee.x = scalee.x + 0.03f;
            scalee.y = scalee.y + 0.03f;
            transform.localScale = scalee;
        }

        while (scalee.x >= 1.4f)
        {
            yield return new WaitForSeconds(0.01f);
            scalee.x = scalee.x - 0.03f;
            scalee.y = scalee.y - 0.03f;
            transform.localScale = scalee;
        }
    }


    public void fadeouttt()
    {
        if (PlayerPrefs.GetInt("popuptouch", 0) == 9)
        {
            StartCoroutine("imgFadeOut");
            GM.GetComponent<UnityADS>().soundck = 0;
            PlayerPrefs.SetInt("popuptouch", 1);
        }
        
    }


    IEnumerator imgFadeOut()
    {
        for (int i = 0; i < 3; i++)
        {
            color = GM.GetComponent<GameEvt>().fever_obj.GetComponent<Image>().color;
        }
        for (float i = 1f; i > -1f; i -= 0.1f)
        {
            //Debug.Log (i);
            color.a = Mathf.Lerp(0f, 1f, i);
            for (int j = 0; j < 3; j++)
            {
                GM.GetComponent<GameEvt>().fever_obj.GetComponent<Image>().color = color;
            }
            yield return null;
        }
        GM.GetComponent<GameEvt>().fever_obj.SetActive (false);
        //다음 피버를 위해 투명도 복구
        color.a = Mathf.Lerp(0f, 1f, 1f);
        GM.GetComponent<GameEvt>().fever_obj.GetComponent<Image>().color = color;
    }


}
