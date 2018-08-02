using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupZoom : MonoBehaviour
{
    public GameObject popupWindow;
    //public GameObject GM;
    Vector3 scalee;
    private Exception e;

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


}
