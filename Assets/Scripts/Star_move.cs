using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star_move : MonoBehaviour
{

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
        StartCoroutine(Dest());
    }
    IEnumerator Dest() 
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

}
