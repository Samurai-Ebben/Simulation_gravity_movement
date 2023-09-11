using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TitleEffects : MonoBehaviour
{

    public TextMeshProUGUI titleTxt;
    public Image bgImg;
    // Start is called before the first frame update
    void Start()
    {
        titleTxt.text = "UFO slayer";
    }

    // Update is called once per frame
    void Update()
    {
        //titleTxt.fontSize = 25 + Mathf.Sin(Time.time * 3) * 10;

    }

    public void PlayBtn()
    {
        bgImg.color = bgImg.color == Color.white ?Color.blue  : Color.white;
    }
}
