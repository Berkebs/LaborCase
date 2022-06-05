using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Station : MonoBehaviour
{

    public GameController gameController;
    public int myCode;
    // Start is called before the first frame update
    void Start()
    {
        //Buradaki myCode degiskeni birimlerin istasyonla eslesmesini saglýyor 

        switch (myCode)
        {
            case 0:
                this.GetComponent<SpriteRenderer>().color = Color.grey;
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().color = Color.red;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().color = Color.blue;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().color = Color.yellow;
                break;
            case 4:
                this.GetComponent<SpriteRenderer>().color = Color.green;
                break;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Burada birimin dogru istasyona gelip gelmedigi kontrol ediliyor
        if (collision.tag == "Unit")
        {

            collision.gameObject.SetActive(false);
            if (myCode==collision.GetComponent<Unit>().myCode)
            {
                gameController.EntryUnit();
            }
            else
            {
                gameController.FailUnit();
            }
        }
    }

}

