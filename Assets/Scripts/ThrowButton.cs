using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThrowButton : MonoBehaviour
{

    public GameObject player;
    public bool firstThrow;
    public bool secondThrow;
    public bool endOfGame;
    public bool firstGame;

    private List<Dice> dices = new List<Dice>();
    private Combinations combinationsInspector;


	void Start ()
    {
        for (int i = 0; i < 5; i++)
        {
            dices.Add(GameObject.Find("Dice" + (i + 1).ToString()).GetComponent<Dice>());
        }

        combinationsInspector = FindObjectOfType<Combinations>();

        firstGame = true;
    }
	
	void Update ()
    {
        if (firstThrow)
        {
            GetComponentInChildren<Text>().text = "Rzut kośćmi";

            GetComponent<Button>().onClick.RemoveAllListeners();
            GetComponent<Button>().onClick.AddListener(FirstThrow);

            FindObjectOfType<GoldManager>().isBet = true;

            GameObject.Find("Back").GetComponent<Button>().interactable = false;

            firstThrow = false;
        }

        if (secondThrow)
        {
            GetComponentInChildren<Text>().text = "Przerzut kości";

            GetComponent<Button>().onClick.RemoveAllListeners();
            GetComponent<Button>().onClick.AddListener(SecondThrow);

            secondThrow = false;
        }

        if (endOfGame || firstGame)
        {
            GetComponentInChildren<Text>().text = "Nowa rozgrywka";

            GetComponent<Button>().onClick.RemoveAllListeners();
            GetComponent<Button>().onClick.AddListener(NewGame);

            GameObject.Find("Back").GetComponent<Button>().interactable = true;

            if (endOfGame)
            {
                FindObjectOfType<GoldManager>().GetComponent<GoldManager>().endOfGame = true;
            }

            endOfGame = false;
            firstGame = false;
        }

    }

    public void FirstThrow()
    {
        combinationsInspector.combinationName = "";
        combinationsInspector.combinationName2 = "";
        combinationsInspector.combinationValue = 0;
        combinationsInspector.combinationValue2 = 0;

        for (int i = 0; i < 5; i++)
        {
            
            dices[i].dotCount = Random.Range(1, 7);
            
            dices[i].secondThrow = true;
        }

        combinationsInspector.thrown = true;

        secondThrow = true;
    }

    public void SecondThrow()
    {

        combinationsInspector.combinationName = "";
        combinationsInspector.combinationName2 = "";
        combinationsInspector.combinationValue = 0;
        combinationsInspector.combinationValue2 = 0; 

        for (int i = 0; i < 5; i++)
        {
            if (dices[i].picked)
            {
                dices[i].dotCount = Random.Range(1, 7);
            }

            dices[i].picked = false;
            dices[i].secondThrow = false;
        }

        combinationsInspector.thrown = true;

        endOfGame = true;
    }

    public void NewGame()
    {
        
        for (int i = 0; i < 5; i++)
        {
            dices[i].blank = true;
        }

        GameObject.Find("Combination").GetComponent<Text>().text = "";
        FindObjectOfType<Combinations>().GetComponent<Combinations>().combinationName = "";

        firstThrow = true;
    }
}
