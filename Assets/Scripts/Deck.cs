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
                        for (int x = 0; x < gameManager.saveMelee.Length; x++)
                        {
                            if (gameManager.saveMelee[x] == null)
                            {
                                gameManager.saveMelee[x] = card;
                                break;
                            }
                        }
                        gameManager.playedTurn = true;
                        return true;
                    }
                }
                for (int f = 0; f < range1.Length; f++)
                {
                    if (!range1[f] && card.GetComponent<UnytCard>().attakMode == "Range")
                    {
                        range1[f] = true;
                        card.transform.position = range[f].transform.position;
                        for (int x = 0; x < gameManager.saveRange.Length; x++)
                        {
                            if (gameManager.saveRange[x] == null)
                            {
                                gameManager.saveRange[x] = card;
                                break;
                            }
                        }
                        gameManager.playedTurn = true;
                        return true;
                    }
                }
                for (int f = 0; f < siege1.Length; f++)
                {
                    if (!siege1[f] && card.GetComponent<UnytCard>().attakMode == "Siege")
                    {
                        siege1[f] = true;
                        card.transform.position = siege[f].transform.position;
                        for (int x = 0; x < gameManager.saveSiege.Length; x++)
                        {
                            if (gameManager.saveSiege[x] == null)
                            {
                                gameManager.saveSiege[x] = card;
                                break;
                            }
                        }
                        gameManager.playedTurn = true;
                        return true;
                    }
                }

            }
            if (card.GetComponent<cardsCharacteristic>().typeCard == "Increase")

            {
                if (card.GetComponent<increaseCard>().bonus == "Melee" && !increase1[0])
                {
                    increase1[0] = true;
                    card.transform.position = increase[0].transform.position;
                    gameManager.playedTurn = true;
                    return true;
                }
                if (card.GetComponent<increaseCard>().bonus == "Range" && !increase1[1])
                {
                    increase1[1] = true;
                    card.transform.position = increase[1].transform.position;
                    gameManager.playedTurn = true;
                    return true;
                }
                if (card.GetComponent<increaseCard>().bonus == "Siege" && !increase1[2])
                {
                    increase1[2] = true;
                    card.transform.position = increase[2].transform.position;
                    gameManager.playedTurn = true;
                    return true;
                }
            }
            if (card.GetComponent<cardsCharacteristic>().typeCard == "Weather")
            {
                if (card.GetComponent<weatherCards>().affected == "Melee" && !weather1[0])
                {
                    weather1[0] = true;
                    card.transform.position = weather[0].transform.position;
                    for(int f = 0; f < gameManager.saveWeather.Length; f++)
                    {
                        if (gameManager.saveWeather[f] == null)
                        {
                            gameManager.saveWeather[f] = card;
                            break;
                        }
                    }
                    gameManager.playedTurn = true;
                    return true;
                }
                if(card.GetComponent<weatherCards>().affected == "Range" && !weather1[1])
                {
                    weather1[1] = true;
                    card.transform.position = weather[1].transform.position;
                    for (int f = 0; f < gameManager.saveWeather.Length; f++)
                    {
                        if (gameManager.saveWeather[f] == null)
                        {
                            gameManager.saveWeather[f] = card;
                            break;
                        }
                    }
                    gameManager.playedTurn = true;
                    return true;
                }
                if (card.GetComponent<weatherCards>().affected == "Siege" && !weather1[2])
                {
                    weather1[2] = true;
                    card.transform.position = weather[2].transform.position;
                    for (int f = 0; f < gameManager.saveWeather.Length; f++)
                    {
                        if (gameManager.saveWeather[f] == null)
                        {
                            gameManager.saveWeather[f] = card;
                            break;
                        }
                    }
                    gameManager.playedTurn = true;
                    return true;
                }
            }
            if(card.GetComponent<cardsCharacteristic>().typeCard == "Clearance")
            {
                card.transform.position = clearance.transform.position;
                card.transform.localScale = clearance.transform.localScale;
                gameManager.playedTurn = true;
                return true;
            }
        }
        return false;
    }

    public void Vaciar(GameObject card)
    {
        for(int f = 0; f < hand.Length;f++)
        {
            if (hand[f] == card)
            {
                hand[f] = null;
            }
            
        }
    }
}
