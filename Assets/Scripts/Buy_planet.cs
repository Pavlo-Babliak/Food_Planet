using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buy_planet : MonoBehaviour
{
    GameObject[] Fon_lvl_planet = new GameObject[4];
    // Start is called before the first frame update
    private void Start()
    {
            Fon_lvl_planet[0] = GameObject.Find("Fon_lvl").transform.GetChild(0).gameObject;
            Fon_lvl_planet[1] = GameObject.Find("Fon_lvl").transform.GetChild(1).gameObject;
            Fon_lvl_planet[2] = GameObject.Find("Fon_lvl").transform.GetChild(2).gameObject;
            Fon_lvl_planet[3] = GameObject.Find("Fon_lvl").transform.GetChild(3).gameObject;
    }
    public void buy() 
    {
        if (gameObject.name == "Candy(Clone)")
        {
            Fon_lvl_planet[0].SetActive(true);
        }
        if (gameObject.name == "Sushi(Clone)") 
        {
            if (PlayerPrefs.GetInt("Planets") < 2) 
            {
                if (PlayerPrefs.GetInt("Stars") >= System.Convert.ToInt32(transform.GetChild(1).name)) 
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(false);
                    GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") - System.Convert.ToInt32(transform.GetChild(1).name));
                    PlayerPrefs.SetInt("Planets", 2);
                    PlayerPrefs.SetInt("Last_LVL", 50);
                }
            }
            else if (PlayerPrefs.GetInt("Planets") >= 2) 
            {
                Fon_lvl_planet[1].SetActive(true);
            }
        }
        if (gameObject.name == "Ñhocolate(Clone)")
        {
            if (PlayerPrefs.GetInt("Planets") < 3)
            {
                if (PlayerPrefs.GetInt("Stars") >= System.Convert.ToInt32(transform.GetChild(1).name))
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(false);
                    GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") - System.Convert.ToInt32(transform.GetChild(1).name));
                    PlayerPrefs.SetInt("Planets", 3);
                    PlayerPrefs.SetInt("Last_LVL", 100);
                }
            }
            else if (PlayerPrefs.GetInt("Planets") >= 3)
            {
                Fon_lvl_planet[2].SetActive(true);
            }
        }
        if (gameObject.name == "Fast_Food(Clone)")
        {
            if (PlayerPrefs.GetInt("Planets") < 4)
            {
                if (PlayerPrefs.GetInt("Stars") >= System.Convert.ToInt32(transform.GetChild(1).name))
                {
                    transform.GetChild(0).gameObject.SetActive(false);
                    transform.GetChild(1).gameObject.SetActive(false);
                    GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") - System.Convert.ToInt32(transform.GetChild(1).name));
                    PlayerPrefs.SetInt("Planets", 4);
                    PlayerPrefs.SetInt("Last_LVL", 150);
                }
            }
            else if (PlayerPrefs.GetInt("Planets") >= 4)
            {
                Fon_lvl_planet[3].SetActive(true);
            }
        }
    }
}
