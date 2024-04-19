using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class cardsCharacteristic : MonoBehaviour
{
    public string name;
    public string faction;
    public string typeCard;
    public string hability;
    public bool summonedCard = false;
    public bool increased = false;
    public bool affected = false;
    public GameObject image, description;
    private void Start()
    {
        image = GameObject.FindGameObjectWithTag("imageCard");
        description = GameObject.FindGameObjectWithTag("textDescription");
    }
    private void OnMouseDown()
    {
        if(!summonedCard && GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>().playFaction == faction)
        {
            summonedCard = GameObject.FindGameObjectWithTag(faction).GetComponent<Deck>().summonCards(gameObject);
            if(summonedCard)
            {
                GameObject.FindGameObjectWithTag(faction).GetComponent<Deck>().Vaciar(gameObject);
            }
        }
    }
    private void OnMouseEnter()
    {
        image.GetComponent<RawImage>().texture = GetComponent<SpriteRenderer>().sprite.texture;
        image.transform.localScale = Vector3.one;
        description.GetComponent<TextMeshProUGUI>().text = "name: "+ name +"\nfaction: "+ faction + "\ntype card: " + typeCard + "\nhability: \n" + hability;
        GameObject.FindGameObjectWithTag("imageDescription").transform.localScale = Vector3.one;
    }

    private void OnMouseExit()
    {
        image.transform.localScale = Vector3.zero;
        GameObject.FindGameObjectWithTag("imageDescription").transform.localScale = Vector3.zero;

    }
}
