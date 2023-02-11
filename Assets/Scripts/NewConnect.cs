using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewConnect : MonoBehaviour
{
    public bool Connect;
    public bool dest;
    GameObject cam;
    public GameObject Star;
    bool des_sound;
    int r;
    private void Start()
    {
        if (PlayerPrefs.GetInt("Sound") == 0)
        {
            GetComponent<AudioSource>().enabled = false;
        }
        else
        {
            GetComponent<AudioSource>().enabled = true;
        }
        des_sound =true;
        cam = GameObject.Find("Main Camera");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag && collision.gameObject.GetComponent<NewConnect>())
        {
            Connect = true;
            collision.gameObject.GetComponent<NewConnect>().Connect = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag && collision.gameObject.GetComponent<NewConnect>())
        {
            if (collision.gameObject.GetComponent<NewConnect>().Connect == true)
            {
                collision.gameObject.GetComponent<NewConnect>().Connect = false;
                Connect = false;
            }
            if (collision.gameObject.GetComponent<NewConnect>().dest == true) { Dest();  }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == gameObject.tag && collision.gameObject.GetComponent<NewConnect>())
        {
            Connect = true;
        }

        if (collision.gameObject.tag == gameObject.tag && dest == true && collision.gameObject.GetComponent<NewConnect>()) { Dest(); }
    }
    public void Dest()
    {

        StartCoroutine(D());
       
    }
    IEnumerator D() 
    {
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
        transform.position = new Vector3(transform.position.x + 0.0005f, transform.position.y + 0.0005f, transform.position.z);
        
        cam.GetComponent<Jump>().Spawn();
        dest = true;
        if (des_sound == true) 
        { 
            Instantiate(Star, gameObject.transform.position, Quaternion.identity);
            if (GetComponent<AudioSource>().enabled == true) { GetComponent<AudioSource>().Play(); }
            des_sound = false; 
        }
        yield return new WaitForSeconds(0.05f);
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        
        if (cam) 
        {
            //cam.GetComponent<Jump>().Fin_obj++;
            cam.GetComponent<Jump>().Finish_count--;
            cam.GetComponent<Jump>().pr();
            
            if (GameObject.Find("Text_Progress")) 
            {
                GameObject.Find("Text_Progress").GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(cam.GetComponent<Jump>().Finish_count);
                // GameObject.Find("Text_Progress").GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(cam.GetComponent<Jump>().Fin_obj) + "/" + System.Convert.ToString(cam.GetComponent<Jump>().Finish_count);
            }
            if (Application.loadedLevel < 75) { r = Random.Range(1, 5); }
            if (Application.loadedLevel >= 75 && Application.loadedLevel < 126) { r = Random.Range(1, 6); }
            if (Application.loadedLevel >= 126 && Application.loadedLevel < 201) { r = Random.Range(1, 7); }

            if (r == 1) { cam.GetComponent<Jump>().C1++; }
            else if (r == 2) { cam.GetComponent<Jump>().C2++; }
            else if (r == 3) { cam.GetComponent<Jump>().C3++; }
            else if (r == 4) { cam.GetComponent<Jump>().C4++; }
            else if (r == 5) { cam.GetComponent<Jump>().C5++; }
            else if (r == 6) { cam.GetComponent<Jump>().C6++; }
           

        }

        
    }

}
