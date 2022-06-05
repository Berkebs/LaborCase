using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public int FinishedUnit,UnitCount,Level;

    public TextMeshProUGUI UnitinfoTxt;

    public int[] LevelsNeedUnit;
    public GameObject ObjectManager;
    public List <GameObject> Stations;
    public List <GameObject> Zones;
    public List<GameObject> Levels;





    public CanvasGroup GameOverCanvas;
    public Button NextLevelBtn;
    public TextMeshProUGUI StatusText,LevelText,NextLevelButtoninText;

    private void Awake()
    {
        //Yerel dosyada Level degiskeni yoksa yeni bir Level degiskeni atanýyor
        if (!PlayerPrefs.HasKey("Level"))
        {
            PlayerPrefs.SetInt("Level",0);
        }
        Level=PlayerPrefs.GetInt("Level");

        UnitCount=LevelsNeedUnit[Level];



    }

     void OnEnable()
    {
        for (int i = 0; i <= 4; i++)
        {
            if (i <=  Level)
            {
                Levels[i].SetActive(true);
            }
            else
            {
                //Zone baðlantýlarýný görmemek için parent içindekileride kaldýrmamýz gerekiyor
                Levels[i].SetActive(false);
            }
        }
    }
    void Start()
    {
      



        for (int i = 0; i <= Level; i++)
        {
            Stations[i].gameObject.SetActive(true);
            Stations[i + 1].gameObject.SetActive(true);
        }


        UnitinfoTxt.text = FinishedUnit + " / " + UnitCount;
    }
   
    void Update()
    {
        // Dokunma Kontrolleri

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {

            Ray ray = Camera.main.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.tag == "ZoneTouch")
                {
                    hit.transform.parent.GetComponent<Zone>().ZoneCLick();
                }
            }
        }


    }


    //Birim dogru bolgeye girdiginde calisacak
    //Bitiren birim sayýsý arttýrýlýp ekrana yazdýrýlacak
    public void EntryUnit() 
    {
        FinishedUnit++;
        UnitinfoTxt.text = FinishedUnit + " / " + UnitCount;
        if (FinishedUnit == UnitCount)
        {
            GameFinish(true);
        }
    }
    //Birim yanlýs bolgeye girdiginde calisacak
    public void FailUnit() 
    {
        GameFinish(false);
    }
    void GameFinish(bool Completed)
    {
        ObjectManager.SetActive(false);
        GameOverCanvas.alpha = 1;
        GameOverCanvas.interactable = true;
        if (Completed)
        {
            StatusText.text = "Complete";
            LevelText.text = "Level " + (Level + 1).ToString();
            if (Level>=4)
            {
                NextLevelButtoninText.text = "Max Level";
                NextLevelBtn.interactable = false;
            }
        }
        else
        {
            StatusText.text="Failed";
            LevelText.text ="Level "+ (Level).ToString();
            NextLevelBtn.interactable = false;
        }
    }


    #region GameOver Panel UI Buttons
    public void NextLevelButton() 
    {
        PlayerPrefs.SetInt("Level",(PlayerPrefs.GetInt("Level")+1));
        SceneManager.LoadScene(0);
    
    }
    public void RetryButton() 
    {
        SceneManager.LoadScene(0);
    }

     #endregion
}
