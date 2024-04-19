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
            for (int i = 0; i < gameManager.saveMelee.Length; i++)
            {
                if (gameManager.saveMelee[i] != null)
                {
                    if (!gameManager.saveMelee[i].GetComponent<cardsCharacteristic>().affected)
                        {
                            gameManager.saveMelee[i].GetComponent<cardsCharacteristic>().affected = true;
                            gameManager.saveMelee[i].GetComponent<UnytCard>().powerCard--;
                        }
                    
                }
            }
        }

        if (affected == "Range")
        {
            for (int i = 0; i < gameManager.saveRange.Length; i++)
            {
                if (gameManager.saveRange[i] != null)
                {
                   if (!gameManager.saveRange[i].GetComponent<cardsCharacteristic>().affected)
                        {
                            gameManager.saveRange[i].GetComponent<cardsCharacteristic>().affected = true;
                            gameManager.saveRange[i].GetComponent<UnytCard>().powerCard--;
                        }
                    
                }
            }
        }
        if (affected == "Siege")
        {
            for (int i = 0; i < gameManager.saveSiege.Length; i++)
            {
                if (gameManager.saveSiege[i] != null)
                {
                    if (!gameManager.saveSiege[i].GetComponent<cardsCharacteristic>().affected)
                        {
                            gameManager.saveSiege[i].GetComponent<cardsCharacteristic>().affected = true;
                            gameManager.saveSiege[i].GetComponent<UnytCard>().powerCard--;
                        }
                    
                }
            }
        }

    }

    public void Delete()
    {
        if (affected == "Melee")
        {
            for (int i = 0; i < gameManager.saveMelee.Length; i++)
            {
                if (gameManager.saveMelee[i] != null)
                {
                    if (gameManager.saveMelee[i].GetComponent<cardsCharacteristic>().affected)
                    {
                        gameManager.saveMelee[i].GetComponent<cardsCharacteristic>().affected = false;
                        gameManager.saveMelee[i].GetComponent<UnytCard>().powerCard++;
                    }

                }
            }
        }

        if (affected == "Range")
        {
            for (int i = 0; i < gameManager.saveRange.Length; i++)
            {
                if (gameManager.saveRange[i] != null)
                {
                    if (gameManager.saveRange[i].GetComponent<cardsCharacteristic>().affected)
                    {
                        gameManager.saveRange[i].GetComponent<cardsCharacteristic>().affected = false;
                        gameManager.saveRange[i].GetComponent<UnytCard>().powerCard++;
                    }

                }
            }
        }
        if (affected == "Siege")
        {
            for (int i = 0; i < gameManager.saveSiege.Length; i++)
            {
                if (gameManager.saveSiege[i] != null)
                {
                    if (gameManager.saveSiege[i].GetComponent<cardsCharacteristic>().affected)
                    {
                        gameManager.saveSiege[i].GetComponent<cardsCharacteristic>().affected = false;
                        gameManager.saveSiege[i].GetComponent<UnytCard>().powerCard++;
                    }

                }
            }
        }

    }
}
