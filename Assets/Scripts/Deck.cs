using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Deck : MonoBehaviour
{
    //definicion de datos
    public gameManager gameManager;
    public GameObject[] deck = new GameObject[25];
    public GameObject[] hand = new GameObject[10];

    public GameObject[] melee = new GameObject[4];
    public bool[] melee1 = new bool[4];

    public GameObject[] range = new GameObject[4];
    public bool[] range1 = new bool[4];

    public GameObject[] siege = new GameObject[4];
    public bool[] siege1 = new bool[4];

    public GameObject[] increase = new GameObject[3];
    public bool[] increase1 = new bool[3];

    public GameObject[] weather = new GameObject[3];
    public bool[] weather1 = new bool[3];

    public GameObject deckPosition;
    public GameObject graveyard;
    public GameObject clearance;

    public GameObject[] handPosition = new GameObject[10];
    public bool[] handPosition1 = new bool[10];

    int nextCardDraw = 0;

    private void Start()
    {
        shuffle();
        drawCard(10);
    }
    public void shuffle()
    {
        //barajear el mazo
        for (int f = 0; f < deck.Length; f++)
        {
            int position = Random.Range(0, deck.Length);
            GameObject saveElemet = deck[f];
            deck[f] = deck[position];
            deck[position] = saveElemet;
        }
    }
    //robar cartas
    public void drawCard(int numberCards)
    {
        int comprobationCard = 0;
        for (int f = 0; f < hand.Length; f++)
        {
            if (hand[f] == null && comprobationCard < numberCards)
            {
                hand[f] = Instantiate(deck[nextCardDraw], handPosition[f].transform.position, handPosition[f].transform.rotation);
                hand[f].transform.localScale = handPosition[f].transform.localScale;
                nextCardDraw++;
                comprobationCard++;
            }
        }
    }//invocar cartas
    public bool summonCards(GameObject card)
    {
        if (!gameManager.playedTurn)
        {
            if (card.GetComponent<cardsCharacteristic>().typeCard == "Silver" || card.GetComponent<cardsCharacteristic>().typeCard == "Gold")
            {
                for (int f = 0; f < melee1.Length; f++)
                {
                    if (!melee1[f] && card.GetComponent<UnytCard>().attakMode == "Melee")
                    {
                        melee1[f] = true;
                        card.transform.position = melee[f].transform.position;
                        return true;
                    }
                }
                for (int f = 0; f < range1.Length; f++)
                {
                    if (!range1[f] && card.GetComponent<UnytCard>().attakMode == "Range")
                    {
                        range1[f] = true;
                        card.transform.position = range[f].transform.position;
                        return true;
                    }
                }
                for (int f = 0; f < siege1.Length; f++)
                {
                    if (!siege1[f] && card.GetComponent<UnytCard>().attakMode == "Siege")
                    {
                        siege1[f] = true;
                        card.transform.position = siege[f].transform.position;
                        return true;
                    }
                }

            }
        }
        return false;
    }
}

