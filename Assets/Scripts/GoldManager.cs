using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldManager : MonoBehaviour
{
    public GameObject windowPrefab;
    public float goldAmount;
    public float betAmount;
    public bool isBet;
    public bool endOfGame;

    private Instruction instruction;
    private ThrowButton throwButton;
    private Text goldText;
    private Text betText;



    void Start()
    {
        instruction = FindObjectOfType<Instruction>().GetComponent<Instruction>();
        goldText = GameObject.Find("Gold").GetComponent<Text>();
        betText = GameObject.Find("Bet Text").GetComponent<Text>();
        throwButton = FindObjectOfType<ThrowButton>().GetComponent<ThrowButton>();
    }

    void Update()
    {
        if (goldAmount < 10 && betText.text == "")
        {
            throwButton.GetComponent<Button>().interactable = false;
            GameObject.Find("Back").GetComponent<Button>().interactable = true;
        }

        goldText.text = goldAmount.ToString();

        if(betAmount == 0)
        {
            betText.text = "";
        }

        if (isBet)
        {
            Bet();

            throwButton.GetComponent<Button>().interactable = false;

            isBet = false;
        }

        if (endOfGame)
        {
            switch (GameObject.Find("Combination").GetComponent<Text>().text)
            {
                case "Nic":
                    //Ilość złota pozostaje taka jak po zakładzie - przegrana zakładu
                    break;
                case "Para":
                    //Ilość złota pozostaje taka jak po zakładzie - przegrana zakładu
                    break;
                case "Trójka":
                    //Ilość złota pozostaje taka jak przed zakładem - remis
                    goldAmount += betAmount;
                    break;
                case "Kareta":
                    //Ilość złota pozostaje zwiększona o założoną kwotę - wygrana zakładu
                    goldAmount += betAmount * 2;
                    break;
                case "Poker":
                    //Ilość złota pozostaje zwiększona dwukrotnie o założoną kwotę - wygrana zakładu z bonusem
                    goldAmount += betAmount * 3;
                    break;
                case "Dwie Pary":
                    //Ilość złota pozostaje taka jak po zakładzie - przegrana zakładu
                    break;
                case "Full":
                    //Ilość złota pozostaje zwiększona o założoną kwotę - wygrana zakładu
                    goldAmount += betAmount * 2;
                    break;
                case "Mały Strit":
                    //Ilość złota pozostaje zwiększona o założoną kwotę - wygrana zakładu
                    goldAmount += betAmount * 2;
                    break;
                case "Duży Strit":
                    //Ilość złota pozostaje zwiększona o założoną kwotę - wygrana zakładu
                    goldAmount += betAmount * 2;
                    break;
            }

            betAmount = 0;
            betText.text = betAmount.ToString();


            if (instruction.endOfChangeText)
            {
                endOfGame = false;

                instruction.endOfChangeText = false;

                //GameObject.Find("Combination").GetComponent<Text>().text = "";
                //FindObjectOfType<Combinations>().GetComponent<Combinations>().combinationName = "";
            }
        }


    }

    void Bet()
    {
        Instantiate(windowPrefab, FindObjectOfType<Canvas>().transform);

        GameObject.Find("MoreButton").GetComponent<Button>().onClick.AddListener(More);
        GameObject.Find("LessButton").GetComponent<Button>().onClick.AddListener(Less);
        GameObject.Find("BetButton").GetComponent<Button>().onClick.AddListener(Accept);

    }

    public void Accept()
    {
        Text amountText = GameObject.Find("Amount").GetComponent<Text>();

        betAmount = float.Parse(amountText.text);

        if (goldAmount >= betAmount)
        {
            throwButton.GetComponent<Button>().interactable = true;

            goldAmount -= betAmount;

            betText.text = betAmount.ToString();

            Destroy(GameObject.Find("Bet(Clone)").gameObject);
        }
    }

    public void More()
    {
        Text amountText = GameObject.Find("Amount").GetComponent<Text>();

        switch (amountText.text)
        {
            case "10":
                amountText.text = "20";
                break;
            case "20":
                amountText.text = "50";
                break;
            case "50":
                amountText.text = "100";
                break;
            case "100":
                amountText.text = "200";
                break;
            case "200":
                amountText.text = "500";
                break;
            case "500":
                amountText.text = "1000";
                break;
        }
    }

    public void Less()
    {
        Text amountText = GameObject.Find("Amount").GetComponent<Text>();

        switch (amountText.text)
        {
            case "20":
                amountText.text = "10";
                break;
            case "50":
                amountText.text = "20";
                break;
            case "100":
                amountText.text = "50";
                break;
            case "200":
                amountText.text = "100";
                break;
            case "500":
                amountText.text = "200";
                break;
            case "1000":
                amountText.text = "500";
                break;
        }
    }
}
