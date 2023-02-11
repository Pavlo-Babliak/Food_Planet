using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch1 : MonoBehaviour
{
    public Vector2 touchPos1;
    public bool con;
    public bool Start_Spawn;
    public GameObject Exit_box;
    public GameObject Win_box;
    public GameObject Blur_fon;

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerPrefs.GetInt("Music") == 1) { GetComponent<AudioSource>().Play(); }
        else { GetComponent<AudioSource>().Stop(); }

        Application.targetFrameRate = 60;
        if (PlayerPrefs.GetInt("Music") == 0) { GetComponent<AudioSource>().Stop(); }
        else if (PlayerPrefs.GetInt("Music") == 1) { GetComponent<AudioSource>().Play(); }
        else { GetComponent<AudioSource>().Play(); }
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Blur_fon.SetActive(true);
                Exit_box.SetActive(true);
            }
        }
        //if(GetComponent<Jump>().Fin_obj>= GetComponent<Jump>().Finish_count) { Blur_fon.SetActive(true); Win_box.SetActive(true); }
        if (GetComponent<Jump>().Finish_count<=0) { Blur_fon.SetActive(true); Win_box.SetActive(true); }
        if (Input.touchCount > 0 && Win_box.active==false)
        {
            Start_Spawn = true;
            UnityEngine.Touch touch1 = Input.GetTouch(0);
            if (touch1.phase == TouchPhase.Stationary)
            {
                touchPos1 = Camera.main.ScreenToWorldPoint(new Vector2(touch1.position.x, touch1.position.y));
            }
            RaycastHit2D hit = Physics2D.Raycast(touchPos1, -Vector2.up, 0.001f);
            Debug.DrawRay(touchPos1, -Vector2.up);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Sushi1" || hit.collider.gameObject.tag == "Sushi2" || hit.collider.gameObject.tag == "Sushi3" || hit.collider.gameObject.tag == "Sushi4" || hit.collider.gameObject.tag == "Sushi5" || hit.collider.gameObject.tag == "Sushi6" ||  hit.collider.gameObject.tag == "Candy1" || hit.collider.gameObject.tag == "Candy2" || hit.collider.gameObject.tag == "Candy3" || hit.collider.gameObject.tag == "Candy4" || hit.collider.gameObject.tag == "Candy5" || hit.collider.gameObject.tag == "Candy6" || hit.collider.gameObject.tag == "Chocolate1" || hit.collider.gameObject.tag == "Chocolate2" || hit.collider.gameObject.tag == "Chocolate3" || hit.collider.gameObject.tag == "Chocolate4" || hit.collider.gameObject.tag == "Chocolate5" || hit.collider.gameObject.tag == "Chocolate6" || hit.collider.gameObject.tag == "Fast_Food1" || hit.collider.gameObject.tag == "Fast_Food2" || hit.collider.gameObject.tag == "Fast_Food3" || hit.collider.gameObject.tag == "Fast_Food4" || hit.collider.gameObject.tag == "Fast_Food5" || hit.collider.gameObject.tag == "Fast_Food6" || hit.collider.gameObject.tag == "Sweets1" || hit.collider.gameObject.tag == "Sweets2" || hit.collider.gameObject.tag == "Sweets3" || hit.collider.gameObject.tag == "Sweets4" || hit.collider.gameObject.tag == "Sweets5" || hit.collider.gameObject.tag == "Sweets6")
                {
                    con = true;
                    if (hit.collider.GetComponent<NewConnect>().Connect==true) { hit.collider.GetComponent<NewConnect>().Dest(); }
                }
                if (hit.collider.gameObject.tag == "Bomb") { hit.collider.GetComponent<Bomb>().Boom1(); }
                if (hit.collider.gameObject.tag == "Bomb_kill") { hit.collider.GetComponent<Bomb>().Boom2(); }
            } 
        }
        else
        {
            touchPos1 = new Vector2(0, 10);  
        }
    }
}
