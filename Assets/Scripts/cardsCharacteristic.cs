using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardsCharacteristic : MonoBehaviour
{
    public string name;
    public string faction;
    public string typeCard;
    public string hability;
    private bool summonedCard = false;
    private void OnMouseDown()
    {
        if(!summonedCard)
        {
            summonedCard = GameObject.FindGameObjectWithTag(faction).GetComponent<Deck>().summonCards(gameObject);

        }
    }
}
