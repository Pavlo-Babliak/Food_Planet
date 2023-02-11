using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Jump : MonoBehaviour
{
    public GameObject [] bubble = new GameObject [6];
    public Sprite[] img = new Sprite[6];
    public GameObject [] bomb = new GameObject [2];
    public int Random_max_bomb;
    public int C1;
    public int C2;
    public int C3;
    public int C4;
    public int C5;
    public int C6;
    public int c;
    public int i;
    public int k;
    public int random;
    public int Finish_count;
    public int Finish_count_Real;
    public int Fin_obj;
    public int Fin_obj_last;
    public float Pr_drob;
    private void Start()
    {
        Finish_count_Real = Finish_count;
        for (int i = 0; i < 6; i++) 
        {
            if (Application.loadedLevel < 51) { bubble[i].tag = "Sweets"+System.Convert.ToString(i+1); }
            else if (Application.loadedLevel >= 51 && Application.loadedLevel < 101) { bubble[i].tag = "Sushi" + System.Convert.ToString(i + 1); }
            else if (Application.loadedLevel >= 101 && Application.loadedLevel < 151) { bubble[i].tag = "Candy" + System.Convert.ToString(i + 1); }
            else if (Application.loadedLevel >= 151 && Application.loadedLevel < 201) { bubble[i].tag = "Fast_Food" + System.Convert.ToString(i + 1); }
            bubble[i].GetComponent<SpriteRenderer>().sprite = img[i];
        }
        Fin_obj_last = 0;
        Pr_drob = (float) 1 / (Finish_count*2.5f);
        GameObject.Find("P_b2").GetComponent<Image>().fillAmount = 0;
        //GameObject.Find("Text_Progress").GetComponent<TextMeshProUGUI>().text = "0/" + System.Convert.ToString(Finish_count);
        GameObject.Find("Text_Progress").GetComponent<TextMeshProUGUI>().text =System.Convert.ToString(Finish_count);
        c = C1 + C2 + C3 + C4 + C5+C6;
        StartCoroutine(Auto_spawn());
    }
    public void Jump_button()
    {
        Instantiate(bubble[Random.Range(0,3)], new Vector3(Random.Range(-2,3), 2,2),Quaternion.identity);
        StartCoroutine(Auto_spawn());
    }
    public void Spawn() { c = C1 + C2 + C3 + C4 + C5 + C6;  StartCoroutine(Auto_spawn()); }
   public IEnumerator Auto_spawn() 
    {
        c = C1 + C2 + C3 + C4 + C5 + C6;
        for (i=0;i<c;)
        {
            c = C1 + C2 + C3 + C4 + C5+C6;
            random = Random.Range(1, c);
            if (random > 0 && random <= C1) { Instantiate(bubble[0], new Vector3(Random.Range(-2f, 2f), 4, 2), Quaternion.identity);C1--; }//1
            if (random > C1 && random <= C1 + C2) { Instantiate(bubble[1], new Vector3(Random.Range(-2f, 2f), 4, 2), Quaternion.identity);C2--; }//2
            if (random > C1 + C2 && random <= C1 + C2 + C3) { Instantiate(bubble[2], new Vector3(Random.Range(-2f, 2f), 4, 2), Quaternion.identity); C3--; }//3
            if (random > C1 + C2 + C3 && random <= C1 + C2 + C3 + C4) { Instantiate(bubble[3], new Vector3(Random.Range(-2f, 2f), 4, 2), Quaternion.identity); C4--; }//4
            if (random > C1 + C2 + C3+C4 && random <= C1 + C2 + C3 + C4+C5) { Instantiate(bubble[4], new Vector3(Random.Range(-2f, 2f), 4, 2), Quaternion.identity);C5--; }//5
            if (random > C1 + C2 + C3 + C4+C5 && random <= C1 + C2 + C3 + C4 + C5+C6) { Instantiate(bubble[5], new Vector3(Random.Range(-2f, 2f), 4, 2), Quaternion.identity);C6--; }//6

            k = Random.Range(1, Random_max_bomb);
            if(k>=1 && k < 3) { Instantiate(bomb[0], new Vector3(Random.Range(-2f, 2f), 4, 2), Quaternion.identity); }
            if (k >= 3 && k < 5) { Instantiate(bomb[1], new Vector3(Random.Range(-2f, 2f), 4, 2), Quaternion.identity); }
            
            yield return new WaitForSeconds(0.1f);
        }

    }
    public void pr() 
    {
        StartCoroutine(Progress_Bar());
    }
    IEnumerator Progress_Bar()
    {
        Fin_obj_last++;
        yield return new WaitForSeconds(0.1f);
        if (Pr_drob < 1) { Pr_drob += (float)(Fin_obj_last ^ 2) / (Finish_count_Real * 2.5f); }
        Fin_obj_last = 0;
        GameObject.Find("P_b2").GetComponent<Image>().fillAmount =Pr_drob;
        
    }
}
