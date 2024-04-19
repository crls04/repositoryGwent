using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardsCharacteristic : MonoBehaviour
{
    public string name;
    public string faction;
    public string typeCard;
    public string hability;
    public bool summonedCard = false;
    public bool increased = false;
    public bool affected = false;
    private void OnMouseDown()
    {
        if(!summonedCard && GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>().playFaction == faction)
        {
            summonedCard = GameObject.FindGameObjectWithTag(faction).GetComponent<Deck>().summonCards(gameObject);
            
        }
    }
}
