using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class weatherCards : MonoBehaviour
{
    public string affected;
    public gameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();
    }
    private void Update()
    {
        if (GetComponent<cardsCharacteristic>().summonedCard)
        {
            Decresed();
        }
    }
    public void Decresed()
    {
        if (affected == "Melee")
        {
            for (int f = 0; f < gameManager.saveMelee.Length; f++)
            {
                if (gameManager.saveMelee[f] != null)
                {
                    if (!gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().affected)
                    {
                        if (gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().typeCard == "Plata")
                        {
                            gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().affected = true;
                            gameManager.saveMelee[f].GetComponent<UnytCard>().powerCard--;
                        }
                    }

                }
            }
        }

        if (affected == "Range")
        {
            for (int f = 0; f < gameManager.saveRange.Length; f++)
            {
                if (gameManager.saveRange[f] != null)
                {
                    if (!gameManager.saveRange[f].GetComponent<cardsCharacteristic>().affected)
                    {
                        if (gameManager.saveRange[f].GetComponent<cardsCharacteristic>().typeCard == "Plata")
                        {
                            gameManager.saveRange[f].GetComponent<cardsCharacteristic>().affected = true;
                            gameManager.saveRange[f].GetComponent<UnytCard>().powerCard--;
                        }
                    }
                }
            }
        }
        if (affected == "Siege")
        {
            for (int f = 0; f < gameManager.saveSiege.Length; f++)
            {
                if (gameManager.saveSiege[f] != null)
                {
                    if (!gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().affected)
                    {
                        if (gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().typeCard == "Plata")
                        {
                            gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().affected = true;
                            gameManager.saveSiege[f].GetComponent<UnytCard>().powerCard--;
                        }
                    }
                }
            }
        }

    }

    public void Delete()
    {
        if (affected == "Melee")
        {
            for (int f = 0; f < gameManager.saveMelee.Length; f++)
            {
                if (gameManager.saveMelee[f] != null)
                {
                    if (gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().affected)
                    {
                        if (gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().typeCard == "Plata")
                        {
                            gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().affected = false;
                            gameManager.saveMelee[f].GetComponent<UnytCard>().powerCard++;
                        }
                    }

                }
            }
        }

        if (affected == "Range")
        {
            for (int f = 0; f < gameManager.saveRange.Length; f++)
            {
                if (gameManager.saveRange[f] != null)
                {
                    if (gameManager.saveRange[f].GetComponent<cardsCharacteristic>().affected)
                    {
                        if (gameManager.saveRange[f].GetComponent<cardsCharacteristic>().typeCard == "Plata")
                        {
                            gameManager.saveRange[f].GetComponent<cardsCharacteristic>().affected = false;
                            gameManager.saveRange[f].GetComponent<UnytCard>().powerCard++;
                        }
                    }
                }
            }
        }
        if (affected == "Siege")
        {
            for (int f = 0; f < gameManager.saveSiege.Length; f++)
            {
                if (gameManager.saveSiege[f] != null)
                {
                    if (gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().affected)
                    {
                        if (gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().typeCard == "Plata")
                        {
                            gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().affected = false;
                            gameManager.saveSiege[f].GetComponent<UnytCard>().powerCard++;
                        }
                    }
                }
            }
        }
    }
}