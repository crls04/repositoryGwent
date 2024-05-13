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

        //Fragmento para intercambio con el senuelo
        if(summonedCard && gameManager.decoy!=null && !dontNext && typeCard!= "Senuelo" && !gameManager.playedTurn)
        {
            if (typeCard == "Plata" || typeCard == "Oro")
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
                    for (int f = 0; f < 8; f++)
                    {
                        if (gameManager.saveMelee[f] != null)
                        {
                            if (gameObject == gameManager.saveMelee[f])
                            {
                                gameManager.saveMelee[f] = decoy1;
                            }
                        }

                        if (gameManager.saveRange[f] != null)
                        {
                            if (gameObject == gameManager.saveRange[f])
                            {
                                gameManager.saveRange[f] = decoy1;
                            }
                        }

                        if (gameManager.saveSiege[f] != null)
                        {
                            if (gameObject == gameManager.saveSiege[f])
                            {
                                gameManager.saveSiege[f] = decoy1;
                            }
                        }
                    }
                    
                    summonedCard = false;
                    gameManager.playedTurn = true;
                }
            }
        }
        
    }

    //Utilizado para mostrar descripcion de las cartas
    private void OnMouseEnter()
    {
        image.GetComponent<RawImage>().texture = GetComponent<SpriteRenderer>().sprite.texture;
        image.transform.localScale = Vector3.one;
        description.GetComponent<TextMeshProUGUI>().text = "nombre:"+ Name + "\ntipo:" + typeCard + "\nhabilidad:" + hability;
        GameObject.FindGameObjectWithTag("imageDescription").transform.localScale = Vector3.one;
    }

    //Utilizado para cerrar descripcion de las cartas
    private void OnMouseExit()
    {
        image.transform.localScale = Vector3.zero;
        GameObject.FindGameObjectWithTag("imageDescription").transform.localScale = Vector3.zero;

    }
}
