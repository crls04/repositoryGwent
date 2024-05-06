using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class cardsCharacteristic : MonoBehaviour
{
    public gameManager gameManager;
    public string Name;
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
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();
    }
    private void OnMouseDown()
    {
        bool dontNext = false;
        if (!summonedCard)
        {
            summonedCard = GameObject.FindGameObjectWithTag(faction).GetComponent<Deck>().summonCards(gameObject);
            dontNext = true;
        }
        if(summonedCard && gameManager.decoy!=null && !dontNext && typeCard!= "Decoy" && !gameManager.playedTurn)
        {
            if (typeCard == "Silver" || typeCard == "Gold")
            {
                if (faction == gameManager.decoy.GetComponent<cardsCharacteristic>().faction)
                {
                    GameObject decoy1 = gameManager.decoy;
                    decoy1.transform.position = gameObject.transform.position;
                    if (faction == "Egyptians")
                    {
                        gameObject.transform.position = gameManager.deck1.handPosition[gameManager.decoyPosition].transform.position;
                        
                    }
                    if (faction == "Vikings")
                    {
                        gameObject.transform.position = gameManager.deck2.handPosition[gameManager.decoyPosition].transform.position;
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        if (gameManager.saveMelee[i] != null)
                        {
                            if (gameObject == gameManager.saveMelee[i])
                            {
                                gameManager.saveMelee[i] = decoy1;
                            }
                        }

                        if (gameManager.saveRange[i] != null)
                        {
                            if (gameObject == gameManager.saveRange[i])
                            {
                                gameManager.saveRange[i] = decoy1;
                            }
                        }

                        if (gameManager.saveSiege[i] != null)
                        {
                            if (gameObject == gameManager.saveSiege[i])
                            {
                                gameManager.saveSiege[i] = decoy1;
                            }
                        }
                    }
                    
                    summonedCard = false;
                    gameManager.playedTurn = true;
                }
            }
        }
        
    }
    private void OnMouseEnter()
    {
        image.GetComponent<RawImage>().texture = GetComponent<SpriteRenderer>().sprite.texture;
        image.transform.localScale = Vector3.one;
        description.GetComponent<TextMeshProUGUI>().text = "nombre:"+ Name +"\nfaccion:"+ faction + "\ntipo:" + typeCard + "\nhabilidad:" + hability;
        GameObject.FindGameObjectWithTag("imageDescription").transform.localScale = Vector3.one;
    }

    private void OnMouseExit()
    {
        image.transform.localScale = Vector3.zero;
        GameObject.FindGameObjectWithTag("imageDescription").transform.localScale = Vector3.zero;

    }
}
