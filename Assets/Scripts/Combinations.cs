using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Combinations : MonoBehaviour
{
    public string combinationName;
    public string combinationName2;
    public int combinationValue;
    public int combinationValue2;
    public bool thrown;

    private List<Dice> dices = new List<Dice>();
    private Text combinationText;
    private int oneDotDices;
    private int twoDotDices;
    private int threeDotDices;
    private int fourDotDices;
    private int fiveDotDices;
    private int sixDotDices;

    void Start ()
    {
        for (int i = 0; i < 5; i++)
        {
            dices.Add(GameObject.Find("Dice" + (i + 1).ToString()).GetComponent<Dice>());
        }

        combinationText = GameObject.Find("Combination").GetComponent<Text>();
    }
	
	void Update ()
    {
		if (thrown)
        {
            Check();
        }
        else
        {
            oneDotDices = 0;
            twoDotDices = 0;
            threeDotDices = 0;
            fourDotDices = 0;
            fiveDotDices = 0;
            sixDotDices = 0;

        }

        //combinationText.text = "Kombinacja: " + "\n" + combinationName;
        combinationText.text = combinationName;

    }

    void Check()
    {

        //Przypisywanie ilości kości o danej liczbie oczek

        for (int i = 0; i < 5; i++)
        {
            switch (dices[i].dotCount)
            {
                case 1:
                    oneDotDices++;
                    break;
                case 2:
                    twoDotDices++;
                    break;
                case 3:
                    threeDotDices++;
                    break;
                case 4:
                    fourDotDices++;
                    break;
                case 5:
                    fiveDotDices++;
                    break;
                case 6:
                    sixDotDices++;
                    break;
            }
        }

        //Para, Trójka, Kareta, Poker

        FirstCombination(oneDotDices, 1);
        FirstCombination(twoDotDices, 2);
        FirstCombination(threeDotDices, 3);
        FirstCombination(fourDotDices, 4);
        FirstCombination(fiveDotDices, 5);
        FirstCombination(sixDotDices, 6); 

        //Szukanie drugiej Pary

        if (combinationName != "")
        {
            if (combinationValue != 1)
                SecondCombination(oneDotDices, 1);

            if (combinationValue != 2)
                SecondCombination(twoDotDices, 2);

            if (combinationValue != 3)
                SecondCombination(threeDotDices, 3);

            if (combinationValue != 4)
                SecondCombination(fourDotDices, 4);

            if (combinationValue != 5)
                SecondCombination(fiveDotDices, 5);

            if (combinationValue != 6)
                SecondCombination(sixDotDices, 6);
        }

        //Dwie Pary, Full

        if (combinationName == "Trójka" && combinationName2 == "Para" || combinationName == "Para" && combinationName2 == "Trójka")
        {
            combinationName = "Full";
            combinationName2 = "";
        }
        else if (combinationName == "Para" && combinationName2 == "Para")
        {
            combinationName = "Dwie Pary";
            combinationName2 = "";
        }

        //Mały Strit, Duży Strit

        if (twoDotDices == 1 && threeDotDices == 1 && fourDotDices == 1 && fiveDotDices == 1 && sixDotDices == 1)
        {
            combinationName = "Duży Strit";
            combinationName2 = "";
        }
        else if (oneDotDices == 1 && twoDotDices == 1 && threeDotDices == 1 && fourDotDices == 1 && fiveDotDices == 1)
        {
            combinationName = "Mały Strit";
            combinationName2 = "";
        }

        //Nic

        if(combinationName == "")
        {
            combinationName = "Nic";
            combinationName2 = "";
        }


        thrown = false;

    }

    void FirstCombination(int dicesCount, int dots)
    {
        switch (dicesCount)
        {
            case 2:
                combinationName = "Para";
                combinationValue = dots;
                break;
            case 3:
                combinationName = "Trójka";
                combinationValue = dots;
                break;
            case 4:
                combinationName = "Kareta";
                combinationValue = dots;
                break;
            case 5:
                combinationName = "Poker";
                combinationValue = dots;
                break;
        }
    }

    void SecondCombination(int dicesCount, int dots)
    {
        switch (dicesCount)
        {
            case 2:
                combinationName2 = "Para";
                combinationValue2 = dots;
                break;
            case 3:
                combinationName2 = "Trójka";
                combinationValue2 = dots;
                break;
        }
    }






}
