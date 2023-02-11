using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SnapScrolling : MonoBehaviour
{
    [Range(1, 50)]
    [Header("Controllers")]
    public int panCount;
    [Range(0, 500)]
    public int panOffset;
    [Range(0f, 20f)]
    public float snapSpeed;
    [Range(0f, 10f)]
    public float scaleOffset;
    [Range(1f, 20f)]
    public float scaleSpeed;
    [Header("Other Objects")]
    public GameObject panPrefab;
    public ScrollRect scrollRect;

    private GameObject[] instPans;
    private Vector2[] pansPos;
    private Vector2[] pansScale;

    private RectTransform contentRect;
    private Vector2 contentVector;

    private int selectedPanID;
    private bool isScrolling;
    public Sprite[] Img_planets = new Sprite[4];

    public TextMeshProUGUI Star_count;

    public GameObject Name_planet;
    public Sprite[] Name = new Sprite[4];
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Planets")) { PlayerPrefs.SetInt("Planets", 1); }
        
        contentRect = GetComponent<RectTransform>();
        instPans = new GameObject[panCount];
        pansPos = new Vector2[panCount];
        pansScale = new Vector2[panCount];
        for (int i = 0; i < panCount; i++)
        {
            if (i == 0) 
            {
                panPrefab.GetComponent<Image>().sprite = Img_planets[0];
                panPrefab.GetComponent<Button>().enabled = true;
                panPrefab.name = "Candy";
                panPrefab.transform.GetChild(0).gameObject.SetActive(false);
                panPrefab.transform.GetChild(1).gameObject.SetActive(false);
                panPrefab.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            if (i == 1) 
            {
                if (PlayerPrefs.GetInt("Planets") == 1) 
                {
                    panPrefab.GetComponent<Image>().sprite = Img_planets[1];
                    panPrefab.GetComponent<Button>().enabled = true;
                    panPrefab.name = "Sushi";
                    panPrefab.GetComponent<Image>().color = new Color32(65, 65, 65, 255);
                    panPrefab.transform.GetChild(0).gameObject.SetActive(true);
                    panPrefab.transform.GetChild(1).gameObject.SetActive(true);
                    panPrefab.transform.GetChild(1).gameObject.name = "100";
                    panPrefab.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "100";
                }
                else 
                {
                    panPrefab.GetComponent<Image>().sprite = Img_planets[1];
                    panPrefab.GetComponent<Button>().enabled = false;
                    panPrefab.name = "Sushi";
                    panPrefab.GetComponent<Image>().color = new Color32(65, 65, 65, 255);
                    panPrefab.transform.GetChild(0).gameObject.SetActive(true);
                    panPrefab.transform.GetChild(1).gameObject.SetActive(false);
                }
               
                if (PlayerPrefs.GetInt("Planets") >= 2) 
                {
                    panPrefab.GetComponent<Button>().enabled = true;
                    panPrefab.transform.GetChild(0).gameObject.SetActive(false);
                    panPrefab.transform.GetChild(1).gameObject.SetActive(false);
                    panPrefab.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                }
            }
            if (i == 2) 
            {
                if (PlayerPrefs.GetInt("Planets") == 2)
                {
                    panPrefab.GetComponent<Image>().sprite = Img_planets[2];
                    panPrefab.GetComponent<Button>().enabled = true;
                    panPrefab.name = "Ñhocolate";
                    panPrefab.GetComponent<Image>().color = new Color32(65, 65, 65, 255);
                    panPrefab.transform.GetChild(0).gameObject.SetActive(true);
                    panPrefab.transform.GetChild(1).gameObject.SetActive(true);
                    panPrefab.transform.GetChild(1).gameObject.name = "115";
                    panPrefab.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "115";
                }
                else
                {
                    panPrefab.GetComponent<Image>().sprite = Img_planets[2];
                    panPrefab.GetComponent<Button>().enabled = false;
                    panPrefab.name = "Ñhocolate";
                    panPrefab.GetComponent<Image>().color = new Color32(65, 65, 65, 255);
                    panPrefab.transform.GetChild(0).gameObject.SetActive(true);
                    panPrefab.transform.GetChild(1).gameObject.SetActive(false);
                }
                if (PlayerPrefs.GetInt("Planets") >= 3)
                {
                    panPrefab.GetComponent<Button>().enabled = true;
                    panPrefab.transform.GetChild(0).gameObject.SetActive(false);
                    panPrefab.transform.GetChild(1).gameObject.SetActive(false);
                    panPrefab.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                }
            }
            if (i == 3) 
            {
                if (PlayerPrefs.GetInt("Planets") == 3)
                {
                    panPrefab.GetComponent<Image>().sprite = Img_planets[3];
                    panPrefab.GetComponent<Button>().enabled = true;
                    panPrefab.name = "Fast_Food";
                    panPrefab.GetComponent<Image>().color = new Color32(65, 65, 65, 255);
                    panPrefab.transform.GetChild(0).gameObject.SetActive(true);
                    panPrefab.transform.GetChild(1).gameObject.SetActive(true);
                    panPrefab.transform.GetChild(1).gameObject.name = "125";
                    panPrefab.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = "125";
                }
                else
                {
                    panPrefab.GetComponent<Image>().sprite = Img_planets[3];
                    panPrefab.GetComponent<Button>().enabled = false;
                    panPrefab.name = "Fast_Food";
                    panPrefab.GetComponent<Image>().color = new Color32(65, 65, 65, 255);
                    panPrefab.transform.GetChild(0).gameObject.SetActive(true);
                    panPrefab.transform.GetChild(1).gameObject.SetActive(false);
                }
                if (PlayerPrefs.GetInt("Planets") >= 4)
                {
                    panPrefab.GetComponent<Button>().enabled = true;
                    panPrefab.transform.GetChild(0).gameObject.SetActive(false);
                    panPrefab.transform.GetChild(1).gameObject.SetActive(false);
                    panPrefab.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
                }
            }
           
            instPans[i] = Instantiate(panPrefab, transform, false);
            if (i == 0) continue;
            instPans[i].transform.localPosition = new Vector2(instPans[i - 1].transform.localPosition.x + panPrefab.GetComponent<RectTransform>().sizeDelta.x + panOffset, instPans[i].transform.localPosition.y);
            pansPos[i] = -instPans[i].transform.localPosition;
        }
    }

    private void FixedUpdate()
    {
        if ( GetComponent<RectTransform>().localPosition.x >= -300) { Name_planet.GetComponent<Image>().sprite = Name[0]; }
        if (GetComponent<RectTransform>().localPosition.x < -300 && GetComponent<RectTransform>().localPosition.x >= -1150) { Name_planet.GetComponent<Image>().sprite = Name[1]; }
        if (GetComponent<RectTransform>().localPosition.x < -1150 && GetComponent<RectTransform>().localPosition.x >= -1950) { Name_planet.GetComponent<Image>().sprite = Name[2]; }
        if (GetComponent<RectTransform>().localPosition.x <= -1950 ) { Name_planet.GetComponent<Image>().sprite = Name[3]; }





        Star_count.text =System.Convert.ToString(PlayerPrefs.GetInt("Stars"));
        if (contentRect.anchoredPosition.x >= pansPos[0].x && !isScrolling || contentRect.anchoredPosition.x <= pansPos[pansPos.Length - 1].x && !isScrolling)
            scrollRect.inertia = false;
        float nearestPos = float.MaxValue;
        for (int i = 0; i < panCount; i++)
        {
            float distance = Mathf.Abs(contentRect.anchoredPosition.x - pansPos[i].x);
            if (distance < nearestPos)
            {
                nearestPos = distance;
                selectedPanID = i;
            }
            float scale = Mathf.Clamp(1 / (distance / panOffset) * scaleOffset, 0.5f, 1f);
            pansScale[i].x = Mathf.SmoothStep(instPans[i].transform.localScale.x, scale + 0.3f, scaleSpeed * Time.fixedDeltaTime);
            pansScale[i].y = Mathf.SmoothStep(instPans[i].transform.localScale.y, scale + 0.3f, scaleSpeed * Time.fixedDeltaTime);
            instPans[i].transform.localScale = pansScale[i];
        }
        float scrollVelocity = Mathf.Abs(scrollRect.velocity.x);
        if (scrollVelocity < 400 && !isScrolling) scrollRect.inertia = false;
        if (isScrolling || scrollVelocity > 400) return;
        contentVector.x = Mathf.SmoothStep(contentRect.anchoredPosition.x, pansPos[selectedPanID].x, snapSpeed * Time.fixedDeltaTime);
        contentRect.anchoredPosition = contentVector;
    }

    public void Scrolling(bool scroll)
    {
        isScrolling = scroll;
        if (scroll) scrollRect.inertia = true;
    }
}