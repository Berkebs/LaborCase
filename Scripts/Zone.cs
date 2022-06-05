using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{

    public Transform nowNextZone;
    public List<GameObject> ConnectedZones;
    public List<Transform> NextZones;
    GameObject myArrows;
    public List <GameObject> OpenArrows;

    public GameController gameController;
    private void Start()
    {
        myArrows = this.gameObject.transform.GetChild(1).transform.gameObject;
        for (int i = 0; i < this.myArrows.transform.childCount; i++)
        {
            myArrows.transform.GetChild(i).gameObject.SetActive(false);
        }





        //Bagli olan bölgelerden
        //Kapalý olan istasyonlarý eleyip
        //Acik istasyonlarý gidebilecek bolge listesine ekliyor

        for (int i = 0; i < ConnectedZones.Count; i++)
        {
            if (ConnectedZones[i].transform.parent.gameObject.activeSelf==true)
            {
                NextZones.Add(ConnectedZones[i].transform);
                OpenArrows.Add(myArrows.transform.GetChild(i).gameObject);
            }
        }

        nowNextZone = NextZones[0];
        OpenArrows[0].SetActive(true);
    }

    public void ZoneCLick() 
    {
        for (int i = 0; i < this.gameObject.transform.GetChild(1).childCount; i++)
        {
            myArrows.transform.GetChild(i).gameObject.SetActive(false);
        }
        //Bolgeye týklandýgýnda bolgenin baglandýgý diger bolgeyi degistiriyor
        for (int i = 0; i < NextZones.Count; i++)
        {
            if (NextZones[i]==nowNextZone)
            {
                if ((NextZones.Count-1)>i)
                {
                    nowNextZone = NextZones[i + 1];
                    OpenArrows[i+1].SetActive(true);

                    
                }
                else
                {
                    nowNextZone = NextZones[0];
                    OpenArrows[0].SetActive(true);
                }

                break;
            }
        }

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Birim bolgeye geldiginde birime yeni hedef atanýyor
        if (collision.tag=="Unit")
        {
            collision.gameObject.GetComponent<Unit>().TargetPos = nowNextZone.position;
        }

    }
}
