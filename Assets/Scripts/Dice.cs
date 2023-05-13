using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    public Sprite dot0;
    public Sprite dot1;
    public Sprite dot2;
    public Sprite dot3;
    public Sprite dot4;
    public Sprite dot5;
    public Sprite dot6;

    public Sprite pickedDot1;
    public Sprite pickedDot2;
    public Sprite pickedDot3;
    public Sprite pickedDot4;
    public Sprite pickedDot5;
    public Sprite pickedDot6;

    public int dotCount;
    public bool secondThrow;
    public bool picked;
    public bool blank;

    
	void Start ()
    {
        dotCount = 0;
	}
	
	void Update ()
    {
        
        if (blank)
        {
            dotCount = 0;

            GetComponent<SpriteRenderer>().sprite = dot0;

            blank = false;
        }
        


        if (!picked)
        {
            switch (dotCount)
            {
                case 1:
                    GetComponent<SpriteRenderer>().sprite = dot1;
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().sprite = dot2;
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().sprite = dot3;
                    break;
                case 4:
                    GetComponent<SpriteRenderer>().sprite = dot4;
                    break;
                case 5:
                    GetComponent<SpriteRenderer>().sprite = dot5;
                    break;
                case 6:
                    GetComponent<SpriteRenderer>().sprite = dot6;
                    break;
            }
        }
        else
        {
            switch (dotCount)
            {
                case 1:
                    GetComponent<SpriteRenderer>().sprite = pickedDot1;
                    break;
                case 2:
                    GetComponent<SpriteRenderer>().sprite = pickedDot2;
                    break;
                case 3:
                    GetComponent<SpriteRenderer>().sprite = pickedDot3;
                    break;
                case 4:
                    GetComponent<SpriteRenderer>().sprite = pickedDot4;
                    break;
                case 5:
                    GetComponent<SpriteRenderer>().sprite = pickedDot5;
                    break;
                case 6:
                    GetComponent<SpriteRenderer>().sprite = pickedDot6;
                    break;
            }
        }



    }

    void OnMouseDown()
    {
        if (secondThrow)
        {
            if (picked)
            {
                picked = false;
            }
            else
            {
                picked = true;
            }
        }
    }


}
