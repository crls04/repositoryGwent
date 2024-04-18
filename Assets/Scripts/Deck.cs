using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public GameObject[] deck = new GameObject[25];
    public GameObject[] hand = new GameObject[10];
    int nextCardDraw = 0;
    public void shuffle()
    {
        //shuffle the deck.
        for(int f=0; f<deck.Length; f++)
        {
            int position = Random.Range(0,deck.Length);
            GameObject saveElemet = deck[f];
            deck[f] = deck[position];
            deck[position]=saveElemet;
        }
    }
        //draw card
    public void drawCard(int numberCards)
    {
        int comprobationCard = 0;
        for(int f=0; f < hand.Length; f++)
        {
            if (hand[f] != null&& comprobationCard<numberCards)
            {
                hand[f] = deck[nextCardDraw];
                nextCardDraw++;
                comprobationCard++;
            }
        }
    }
}
