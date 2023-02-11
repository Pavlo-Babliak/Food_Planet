using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stop_anim : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        if (gameObject.name == "Num_lvl") { gameObject.GetComponent<TextMeshProUGUI>().text = System.Convert.ToString(Application.loadedLevel); }
    }
    public void Stop() { GetComponent<Animator>().enabled = false; }
}
