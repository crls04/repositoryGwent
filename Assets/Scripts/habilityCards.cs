using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class habilityCards : MonoBehaviour
{
    public gameManager gameManager;
    public int habilityCard;
    private bool activate = false;
    [TextArea(10, 10)] public string Habilidad;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();
    }

    private void Update()
    {
        if(GetComponent<cardsCharacteristic>().summonedCard && !activate)
        {
            
            activate = Hability(habilityCard);
        }


    }

    private bool Hability(int hab)
    {
        //Efectos deck1
        if (hab == 1) // efecto robar carta
        {
            DrawCard();
            return true;
        }
        if (hab == 2) //efecto destruir carta con mayor poder
        {
            DestroylvlUpAttack();
            return true;
        }
        if (hab == 3) // Efecto invocar aumento
        {
            InvokeIncrease();
            return true;
        }

        //Efectos deck2
        if (hab == 4)//Efecto invocar clima
        {
            InvokeWeather();
            return true;
        }
        if (hab == 5)//Efecto multiplicar poder por cada carta del mismo tipo
        {
            PowerTeam();
            return true;
        }
        if (hab == 6)//Efecto destruir carta con menos poder del rival
        {
            DestroyLvlDownAttack();
            return true;
        }

        return false;
    }

    private void DestroyLvlDownAttack()
    {
        GameObject card = null;
        int atk = 100;
        int pos = 0;
        int pos2 = 0;
        for (int f = 0; f < gameManager.saveMelee.Length; f++)
        {
            if (gameManager.saveMelee[f] != null)
            {
                if (gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().typeCard == "Plata")
                {
                    if (gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().faction == "Egyptians")
                    {
                        if (gameManager.saveMelee[f].GetComponent<UnytCard>().powerCard < atk)
                        {
                            card = gameManager.saveMelee[f];
                            atk = gameManager.saveMelee[f].GetComponent<UnytCard>().powerCard;
                            pos = f;
                            pos2 = 1;
                        }
                    }
                }
            }
        }
        for (int f = 0; f < gameManager.saveRange.Length; f++)
        {
            if (gameManager.saveRange[f] != null)
            {
                if (gameManager.saveRange[f].GetComponent<cardsCharacteristic>().typeCard == "Plata")
                {
                    if (gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().faction == "Egyptians")
                    {
                        if (gameManager.saveRange[f].GetComponent<UnytCard>().powerCard < atk)
                        {
                            card = gameManager.saveRange[f];
                            atk = gameManager.saveRange[f].GetComponent<UnytCard>().powerCard;
                            pos = f;
                            pos2 = 2;
                        }
                    }
                }
            }
        }
        for (int f = 0; f < gameManager.saveSiege.Length; f++)
        {
            if (gameManager.saveSiege[f] != null)
            {
                if (gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().typeCard == "Plata")
                {
                    if (gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().faction == "Egyptians")
                    {
                        if (gameManager.saveSiege[f].GetComponent<UnytCard>().powerCard < atk)
                        {
                            card = gameManager.saveSiege[f];
                            atk = gameManager.saveSiege[f].GetComponent<UnytCard>().powerCard;
                            pos = f;
                            pos2 = 3;
                        }
                    }

                }
            }
        }
        if (card != null)
        {
            Destroy(card);
            if (pos2 == 1)
            {
                gameManager.saveMelee[pos] = null;
            }
            if (pos2 == 2)
            {
                gameManager.saveRange[pos] = null;
            }
            if (pos2 == 3)
            {
                gameManager.saveSiege[pos] = null;
            }
        }
    }

    private void PowerTeam()
    {
        int cuantos = 1;
        for (int f = 0; f < gameManager.saveMelee.Length; f++)
        {
            if (gameManager.saveMelee[f] != null)
            {
                if (gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().Name == GetComponent<cardsCharacteristic>().Name)
                {
                    if (gameManager.saveMelee[f] != gameObject)
                    {
                        gameManager.saveMelee[f].GetComponent<UnytCard>().powerCard += GetComponent<UnytCard>().powerCard;
                        cuantos++;
                    }
                }
            }
        }
        GetComponent<UnytCard>().powerCard *= cuantos;
    }

    private void InvokeWeather()
    {
        for (int f = 0; f < gameManager.deck2.GetComponent<Deck>().hand.Length; f++)
        {
            if (gameManager.deck2.GetComponent<Deck>().hand[f] != null)
            {
                if (gameManager.deck2.GetComponent<Deck>().hand[f].GetComponent<cardsCharacteristic>().typeCard == "Clima")
                {
                    GameObject ca = gameManager.deck1.GetComponent<Deck>().hand[f];
                    gameManager.playedTurn = false;
                    if (gameManager.deck2.GetComponent<Deck>().summonCards(gameManager.deck2.GetComponent<Deck>().hand[f]))
                    {
                        ca.GetComponent<cardsCharacteristic>().summonedCard = true;
                        break;
                    }
                }
            }
        }
        gameManager.playedTurn = true;
    }

    private void InvokeIncrease()
    {
        for (int f = 0; f < gameManager.deck1.GetComponent<Deck>().hand.Length; f++)
        {
            if (gameManager.deck1.GetComponent<Deck>().hand[f] != null)
            {
                if (gameManager.deck1.GetComponent<Deck>().hand[f].GetComponent<cardsCharacteristic>().typeCard == "Aumento")
                {
                    gameManager.playedTurn = false;
                    GameObject ca = gameManager.deck1.GetComponent<Deck>().hand[f];
                    if (gameManager.deck1.GetComponent<Deck>().summonCards(gameManager.deck1.GetComponent<Deck>().hand[f]))
                    {
                        ca.GetComponent<cardsCharacteristic>().summonedCard = true;
                        break;
                    }
                }
            }
        }
        gameManager.playedTurn = true;
    }

    private void DestroylvlUpAttack()
    {
        GameObject card = null;
        int atk = 0;
        int pos = 0;
        int pos2 = 0;

        for (int f = 0; f < gameManager.saveMelee.Length; f++)
        {
            if (gameManager.saveMelee[f] != null)
            {
                if (gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().typeCard == "Plata")
                {
                    if (gameManager.saveMelee[f].GetComponent<UnytCard>().powerCard > atk)
                    {
                        card = gameManager.saveMelee[f];
                        atk = gameManager.saveMelee[f].GetComponent<UnytCard>().powerCard;
                        pos = f;
                        pos2 = 1;
                    }
                }
            }
        }

        for (int f = 0; f < gameManager.saveRange.Length; f++)
        {
            if (gameManager.saveRange[f] != null)
            {
                if (gameManager.saveRange[f].GetComponent<cardsCharacteristic>().typeCard == "Plata")
                {
                    if (gameManager.saveRange[f].GetComponent<UnytCard>().powerCard > atk)
                    {
                        card = gameManager.saveRange[f];
                        atk = gameManager.saveRange[f].GetComponent<UnytCard>().powerCard;
                        pos = f;
                        pos2 = 1;
                    }
                }
            }
        }
        for (int f = 0; f < gameManager.saveSiege.Length; f++)
        {
            if (gameManager.saveSiege[f] != null)
            {
                if (gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().typeCard == "Plata")
                {
                    if (gameManager.saveSiege[f].GetComponent<UnytCard>().powerCard > atk)
                    {
                        card = gameManager.saveSiege[f];
                        atk = gameManager.saveSiege[f].GetComponent<UnytCard>().powerCard;
                        pos = f;
                        pos2 = 1;
                    }
                }
            }
        }
        if (card != null)
        {
            Destroy(card);
            if (pos2 == 1)
            {
                gameManager.saveMelee[pos] = null;
            }
            if (pos2 == 2)
            {
                gameManager.saveRange[pos] = null;
            }
            if (pos2 == 3)
            {
                gameManager.saveSiege[pos] = null;
            }
        }
    }

    private void DrawCard()
    {
        gameManager.deck1.drawCard(1);
    }
}
