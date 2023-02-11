using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Active_lvl : MonoBehaviour
{
    public Sprite[] Active_disable_img = new Sprite[2];
    void Start()
    {
        if (PlayerPrefs.GetInt("Last_LVL") >= System.Convert.ToInt32(gameObject.name)) 
        {
            gameObject.GetComponent<Image>().sprite = Active_disable_img[0];
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            if (PlayerPrefs.GetInt(System.Convert.ToString(gameObject.name)) == 1) 
            {
                transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            if (PlayerPrefs.GetInt(System.Convert.ToString(gameObject.name)) == 2)
            {
                transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                transform.GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            if (PlayerPrefs.GetInt(System.Convert.ToString(gameObject.name)) == 3)
            {
                transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                transform.GetChild(1).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                transform.GetChild(2).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
        }
        if ( System.Convert.ToInt32(gameObject.name) == PlayerPrefs.GetInt("Last_LVL")+1) 
        {
            gameObject.GetComponent<Image>().sprite = Active_disable_img[1];
            gameObject.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        }
    }
    public void load_lvl() 
    {
        if (gameObject.GetComponent<Image>().color == new Color32(255, 255, 255, 255)) 
        {
            SceneManager.LoadScene(System.Convert.ToInt32(gameObject.name));
        }
    }
}
