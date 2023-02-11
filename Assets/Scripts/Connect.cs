using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connect : MonoBehaviour
{  
    public int i;
    public bool con;
    public bool exit;
    public int j;
    public int max;
    public bool Destoy;
    public int count;
    private void Awake()
    {
        i = 1;
        gameObject.name = System.Convert.ToString(i);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision.tag == gameObject.tag && con == false && collision.GetComponent<Connect>().exit == false)
            {
                if (collision.GetComponent<Connect>().i == 1)
                {
                    max = 1;
                    gameObject.name = System.Convert.ToString(collision.GetComponent<Connect>().i);
                    collision.GetComponent<Connect>().i = i + 1;
                    collision.GetComponent<Connect>().max = max + 1;
                    collision.gameObject.name = System.Convert.ToString(collision.GetComponent<Connect>().i);
                    con = true;
                    collision.GetComponent<Connect>().con = true;
                }
                else if (collision.GetComponent<Connect>().i != 1)
                {
                    i = collision.GetComponent<Connect>().i + 1;
                    max = collision.GetComponent<Connect>().max + 1;
                    gameObject.name = System.Convert.ToString(i);
                    con = true;
                    collision.GetComponent<Connect>().con = true;
                }
            }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == gameObject.tag)
        {
           /* if (i == 2)
            {
                collision.GetComponent<Connect>().i = 1;
                i = 1;
                gameObject.name = System.Convert.ToString(i);
                con = false;
                exit = false;
                collision.gameObject.name = System.Convert.ToString(collision.GetComponent<Connect>().i);
                collision.GetComponent<Connect>().con = false;
                collision.GetComponent<Connect>().exit = false;
                max = max - 1;
                //exit = true;
            }*/

            if (collision.transform.parent.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
            {
                collision.GetComponent<Connect>().i = 1;
                collision.gameObject.name = System.Convert.ToString(collision.GetComponent<Connect>().i);
                collision.GetComponent<Connect>().con = false;
                collision.GetComponent<Connect>().exit = false;
                max = max - 1;
                exit = true;
            }
        }   
    }
    public void Dest() 
    {
        Destoy = true;
        transform.position = new Vector3(transform.position.x + 0.0005f, transform.position.y + 0.0005f, transform.position.z);
        StartCoroutine(Des());
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == gameObject.tag &&  con==true)
        {
            if (Destoy == true) { collision.GetComponent<Connect>().Dest(); }
            if (exit == true)
            {
                if (collision.transform.parent.GetComponent<Rigidbody2D>().velocity == Vector2.zero)
                {
                    StartCoroutine(Ext());
                    collision.GetComponent<Connect>().exit = true;
                    i = max;
                    gameObject.name = System.Convert.ToString(i);
                    if (max < collision.GetComponent<Connect>().max) { collision.GetComponent<Connect>().i = max; collision.GetComponent<Connect>().max = max; gameObject.name = System.Convert.ToString(i); }
                }
            }
                else
                {
                    if (collision.GetComponent<Connect>().max > max) { i = collision.GetComponent<Connect>().max; max = collision.GetComponent<Connect>().max; gameObject.name = System.Convert.ToString(i); }
                    collision.GetComponent<Connect>().con = true;
                }
            
 
        }
    }
    
    IEnumerator Ext() 
    {
        yield return new WaitForSeconds(0.05f);
        exit = false;
    }
    public IEnumerator Des()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject.transform.parent.gameObject);
    }

}

