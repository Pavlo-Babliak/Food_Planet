using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button_menu : MonoBehaviour
{
    GameObject cam;
    public Sprite [] Sound_sprite = new Sprite[2];
    public Sprite [] Music_sprite = new Sprite [2];
    public GameObject Sound;
    public GameObject Music;


    private void Start()
    {
        Application.targetFrameRate = 60;
        cam = GameObject.Find("Main Camera");
        if (!PlayerPrefs.HasKey("Sound")) { PlayerPrefs.SetInt("Sound", 1); }
        if (!PlayerPrefs.HasKey("Music")) { PlayerPrefs.SetInt("Music", 1); }
        if (!PlayerPrefs.HasKey("Stars")) { PlayerPrefs.SetInt("Stars", 0); }

        if (PlayerPrefs.GetInt("Music") == 0)
        {
            Music.GetComponent<Image>().sprite = Music_sprite[0];
            cam.GetComponent<AudioSource>().Stop();
        }
        else
        {
            Music.GetComponent<Image>().sprite = Music_sprite[1];
            cam.GetComponent<AudioSource>().Play();
        }
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            Sound.GetComponent<Image>().sprite = Sound_sprite[0];
        }
        else
        {
            Sound.GetComponent<Image>().sprite = Sound_sprite[1];
        }
    }
    public void Star_plus() { PlayerPrefs.SetInt("Stars", PlayerPrefs.GetInt("Stars") + 100); }
    public void Sound_ON_OFF() 
    {
        if (PlayerPrefs.GetInt("Sound") == 0) 
        {
            Sound.GetComponent<Image>().sprite = Sound_sprite[1];
            PlayerPrefs.SetInt("Sound", 1); 
        }
        else 
        {
            Sound.GetComponent<Image>().sprite = Sound_sprite[0];
            PlayerPrefs.SetInt("Sound", 0);
        }
    }
    public void Music_ON_OFF()
    {
        if (PlayerPrefs.GetInt("Music") == 0)
        {
            cam.GetComponent<AudioSource>().Play();
            Music.GetComponent<Image>().sprite = Music_sprite[1];
            PlayerPrefs.SetInt("Music", 1);
        }
        else
        {
            cam.GetComponent<AudioSource>().Stop();
            Music.GetComponent<Image>().sprite = Music_sprite[0];
            PlayerPrefs.SetInt("Music", 0);
        }
    }
    public void Start_game() { SceneManager.LoadScene(PlayerPrefs.GetInt("Last_LVL")+1); }
}
