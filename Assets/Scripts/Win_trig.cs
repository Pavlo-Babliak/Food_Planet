using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Win_trig : MonoBehaviour
{
    public GameObject [] Star_prog_bar = new GameObject[3];
    public GameObject Prog_bar;
    public GameObject[] Star_Finish = new GameObject[3];
    public float Fin_prog_bar;
    void Start()
    {
        if (Application.loadedLevel == 50 || Application.loadedLevel == 100 || Application.loadedLevel == 150 || Application.loadedLevel == 200)
        {
            GameObject.Find("Next").SetActive(false);
        }
        else
        {
            GameObject.Find("Next").GetComponent<Image>().color = new Color32(100, 100, 100, 255);
            GameObject.Find("Next").GetComponent<Button>().enabled = false;
        }
        StartCoroutine(Win());
    }
    IEnumerator Win() 
    {
        Fin_prog_bar = GameObject.Find("Main Camera").GetComponent<Jump>().Pr_drob;
        while (Prog_bar.GetComponent<Image>().fillAmount <= Fin_prog_bar)
        {
            Fin_prog_bar = GameObject.Find("Main Camera").GetComponent<Jump>().Pr_drob;
            Prog_bar.GetComponent<Image>().fillAmount += 0.02f;
            yield return new WaitForSeconds(0.1f);
            if (Prog_bar.GetComponent<Image>().fillAmount > 0.17f && Prog_bar.GetComponent<Image>().fillAmount <= 0.19f)
            {
                Star_prog_bar[0].GetComponent<ParticleSystem>().Play();
                if (Star_prog_bar[0].GetComponent<AudioSource>().enabled == true)
                {
                    Star_prog_bar[0].GetComponent<AudioSource>().Play();
                }
                Star_Finish[0].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                Star_Finish[0].GetComponent<Animator>().enabled = true;

            }
            if (Prog_bar.GetComponent<Image>().fillAmount > 0.56f && Prog_bar.GetComponent<Image>().fillAmount <= 0.58f)
            { 
                Star_prog_bar[1].GetComponent<ParticleSystem>().Play();
                if (Star_prog_bar[0].GetComponent<AudioSource>().enabled == true)
                {
                    Star_prog_bar[1].GetComponent<AudioSource>().Play();
                }
                Star_Finish[1].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                Star_Finish[1].GetComponent<Animator>().enabled = true;
            }
            if (Prog_bar.GetComponent<Image>().fillAmount > 0.88f && Prog_bar.GetComponent<Image>().fillAmount <= 0.9f)
            {
                Star_prog_bar[2].GetComponent<ParticleSystem>().Play();
                if (Star_prog_bar[0].GetComponent<AudioSource>().enabled == true)
                {
                    Star_prog_bar[2].GetComponent<AudioSource>().Play();
                }
                Star_Finish[2].GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                Star_Finish[2].GetComponent<Animator>().enabled = true;
            }
            if (Prog_bar.GetComponent<Image>().fillAmount >= Fin_prog_bar-0.1f)
            {
                if (Application.loadedLevel != 50 || Application.loadedLevel != 100 || Application.loadedLevel != 150 || Application.loadedLevel != 200)
                {
                    GameObject.Find("Next").GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                    GameObject.Find("Next").GetComponent<Button>().enabled = true;
                }
                
            }
        }
        if (Prog_bar.GetComponent<Image>().fillAmount > 0.17f)
        {
            if (PlayerPrefs.GetInt(System.Convert.ToString(Application.loadedLevel)) < 1) 
            { 
                PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 1);
                PlayerPrefs.SetInt(System.Convert.ToString(Application.loadedLevel), 1);
            }
        }
        if (Prog_bar.GetComponent<Image>().fillAmount > 0.58f)
        {
            if (PlayerPrefs.GetInt(System.Convert.ToString(Application.loadedLevel)) < 2) 
            { 
                PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 1);
                PlayerPrefs.SetInt(System.Convert.ToString(Application.loadedLevel), 2);
            }
        }
        if (Prog_bar.GetComponent<Image>().fillAmount > 0.88f)
        {
            if (PlayerPrefs.GetInt(System.Convert.ToString(Application.loadedLevel)) < 3) 
            { 
                PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 1);
                PlayerPrefs.SetInt(System.Convert.ToString(Application.loadedLevel), 3);
            }
        }
        if (PlayerPrefs.GetInt("Last_LVL") < Application.loadedLevel) { PlayerPrefs.SetInt("Last_LVL", Application.loadedLevel); }
        
    }
}
