using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    public Vector2 touchPos1;
    public bool con;
    public bool Start_Spawn; 
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Start_Spawn = true;
            UnityEngine.Touch touch1 = Input.GetTouch(0);
            if (touch1.phase == TouchPhase.Stationary)
            {
                touchPos1 = Camera.main.ScreenToWorldPoint(new Vector2(touch1.position.x, touch1.position.y));
            }
            RaycastHit2D hit = Physics2D.Raycast(touchPos1, -Vector2.up,0.001f);
            Debug.DrawRay(touchPos1, -Vector2.up);
            if (hit.collider != null)
            {
                if (hit.collider.gameObject.tag == "Sushi1"  || hit.collider.gameObject.tag == "Sushi2" || hit.collider.gameObject.tag == "Sushi3" || hit.collider.gameObject.tag == "Sushi4" || hit.collider.gameObject.tag == "Sushi5" || hit.collider.gameObject.tag == "Sushi6")
                {
                    con = true;
                    if (hit.collider.GetComponent<NewConnect>().Connect==true) { hit.collider.GetComponent<NewConnect>().Dest(); }
                }
            } 
        }
        else
        {
            touchPos1 = new Vector2(0, 10);
            if (Start_Spawn == true) { GameObject.Find("Main Camera").GetComponent<Jump>().Spawn(); Start_Spawn = false; }
            
        }
    }
}
