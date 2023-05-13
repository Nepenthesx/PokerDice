using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instruction : MonoBehaviour
{
    public bool endOfChangeText;

    private ThrowButton throwButton;
    private Text myText;

	void Start ()
    {
        myText = GetComponent<Text>();
        throwButton = FindObjectOfType<ThrowButton>().GetComponent<ThrowButton>();
	}
	
	void Update ()
    {
		if (throwButton.firstThrow)
        {
            myText.text = "Ustal kwotę zakładu, a następnie rzuć kośćmi.";
        }

        if (throwButton.secondThrow)
        {
            myText.text = "Wybierz kości do przerzucenia i rzuć po raz drugi.";
        }

        if (FindObjectOfType<GoldManager>().GetComponent<GoldManager>().endOfGame)
        {
            myText.text = "";

            switch (GameObject.Find("Combination").GetComponent<Text>().text)
            {
                case "Nic":
                    myText.text = "Słabo poszło. Przegrywasz!";
                    break;
                case "Para":
                    myText.text = "Para to za mało. Przegrywasz!";
                    break;
                case "Trójka":
                    myText.text = "Trójka oznacza remis. Trzymaj pieniądze z powrotem!";
                    break;
                case "Kareta":
                    myText.text = "Świetnie. Wygrywasz!";
                    break;
                case "Poker":
                    myText.text = "Masz pieprzonego farta!. Wygrywasz premię!";
                    break;
                case "Dwie Pary":
                    myText.text = "To wciąż za mało. Przegrywasz!";
                    break;
                case "Full":
                    myText.text = "Świetnie. Wygrywasz!";
                    break;
                case "Mały Strit":
                    myText.text = "Świetnie. Wygrywasz!";
                    break;
                case "Duży Strit":
                    myText.text = "Świetnie. Wygrywasz!";
                    break;
            }

            myText.text += "\n" + "Chcesz zagrać ponownie?";
            

            endOfChangeText = true;
        }

        if (throwButton.firstGame)
        {
            myText.text = "Zacznij grę.";
        }

        if (FindObjectOfType<GoldManager>().goldAmount < 10 && GameObject.Find("Bet Text").GetComponent<Text>().text == "")
        {
            myText.text = "GAME OVER";
        }
    }
}
