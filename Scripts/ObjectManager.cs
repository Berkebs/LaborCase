using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{

    public List<GameObject> OpenUnit;
    public int UnitCount;
    public GameController gameController;
    public GameObject Base;

    private void Start()
    {

        //Object poola birim sýnýrý kadar birim ekleniyor
        UnitCount=gameController.UnitCount;
        
        for (int i = 0; i < UnitCount; i++)
        {
            OpenUnit.Add(this.gameObject.transform.GetChild(i).gameObject);
        }
            StartCoroutine(SendObject());
    }

    //1.5 saniyede bir birim havuzundan rastgele nesne gönderiliyor
    //Rastgele gönderdigimiz birimlere levele ve acik olan istasyona gore myCode tanýmlanýyor
    IEnumerator SendObject() 
    {
        
        int SendRandom = Random.Range(0, OpenUnit.Count);
        OpenUnit[SendRandom].SetActive(true);
        OpenUnit[SendRandom].GetComponent<Unit>().myCode = Random.Range(0,gameController.Level+2);
        OpenUnit[SendRandom].GetComponent<Unit>().TargetPos = Base.transform.position;
        OpenUnit.RemoveAt(SendRandom);



        yield return new WaitForSeconds(2f);
        if (OpenUnit.Count!=0)
        {
            StartCoroutine(SendObject());
        }

    }
}
