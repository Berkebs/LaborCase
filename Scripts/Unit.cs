using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    public Vector3 TargetPos;
    float Speed=0.008f;

    public int myCode;
    private void Start()
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
   
    void Update()
    {
        //Hareket Kodu
        transform.position = Vector2.MoveTowards(transform.position,TargetPos,Speed);
    }
}
