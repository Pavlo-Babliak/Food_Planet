using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Rate : MonoBehaviour
{
    public GameObject[] Stars = new GameObject[5];
    private void Start()
    {
        if (PlayerPrefs.GetInt("rate") == 1) { gameObject.SetActive(false); }
    }
    public void Star1() 
    {
        Stars[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[1].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
        Stars[2].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
        Stars[3].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
        Stars[4].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
    }
    public void Star2() 
    {
        Stars[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[2].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
        Stars[3].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
        Stars[4].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
    }
    public void Star3()
    {
        Stars[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[3].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
        Stars[4].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
    }
    public void Star4()
    {
        Stars[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[4].GetComponent<Image>().color = new Color32(100, 100, 100, 255);
    }
    public void Star5()
    {
        Stars[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[3].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        Stars[4].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
    public void Confirm() 
    {
        Application.OpenURL("market://details?id=" + Application.productName);
        PlayerPrefs.SetInt("rate", 1);
    }

}
