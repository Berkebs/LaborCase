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

        //Object poola birim sınırı kadar birim ekleniyor
        UnitCount=gameController.UnitCount;
        
        for (int i = 0; i < UnitCount; i++)
        {
            OpenUnit.Add(this.gameObject.transform.GetChild(i).gameObject);
        }
            StartCoroutine(SendObject());
    }

    //1.5 saniyede bir birim havuzundan rastgele nesne gönderiliyor
    //Rastgele gönderdigimiz birimlere levele ve acik olan istasyona gore myCode tanımlanıyor
    IEnumerator SendObject() 
    {
        
        int SendRandom = Random.Range(0, OpenUnit.Count);
        OpenUnit[SendRandom].SetActive(true);
        int rndcode = gameController.Level!=4? Random.Range(0, gameController.Level + 2): Random.Range(0, gameController.Level + 1);
        OpenUnit[SendRandom].GetComponent<Unit>().myCode = rndcode;
        OpenUnit[SendRandom].GetComponent<Unit>().TargetPos = Base.transform.position;
        OpenUnit.RemoveAt(SendRandom);



        yield return new WaitForSeconds(2f);
        if (OpenUnit.Count!=0)
        {
            StartCoroutine(SendObject());
        }

    }
}
