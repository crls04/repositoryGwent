using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseCard : MonoBehaviour
{
    public string bonus;
    public gameManager gameManager;

    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();
    }
    private void Update()
    {
        if(GetComponent<cardsCharacteristic>().summonedCard)
        {
            increase();
        }
    }
    public void increase()
    {
        if(bonus == "Melee")
        {
            for (int i = 0; i < gameManager.saveMelee.Length;i++)
            {
                if (gameManager.saveMelee[i] != null)
                {
                    if (gameManager.saveMelee[i].GetComponent<cardsCharacteristic>().faction == GetComponent<cardsCharacteristic>().faction)
                    {
                        if(!gameManager.saveMelee[i].GetComponent<cardsCharacteristic>().increased)
                        {
                            gameManager.saveMelee[i].GetComponent<cardsCharacteristic>().increased = true;
                            gameManager.saveMelee[i].GetComponent<UnytCard>().powerCard++;
                        }
                    }
                }
            }
        }

        if (bonus == "Range")
        {
            for (int i = 0; i < gameManager.saveRange.Length; i++)
            {
                if (gameManager.saveRange[i] != null)
                {
                    if (gameManager.saveRange[i].GetComponent<cardsCharacteristic>().faction == GetComponent<cardsCharacteristic>().faction)
                    {
                        if (!gameManager.saveRange[i].GetComponent<cardsCharacteristic>().increased)
                        {
                            gameManager.saveRange[i].GetComponent<cardsCharacteristic>().increased = true;
                            gameManager.saveRange[i].GetComponent<UnytCard>().powerCard++;
                        }
                    }
                }
            }
        }
        if (bonus == "Siege")
        {
            for (int i = 0; i < gameManager.saveSiege.Length; i++)
            {
                if (gameManager.saveSiege[i] != null)
                {
                    if (gameManager.saveSiege[i].GetComponent<cardsCharacteristic>().faction == GetComponent<cardsCharacteristic>().faction)
                    {
                        if (!gameManager.saveSiege[i].GetComponent<cardsCharacteristic>().increased)
                        {
                            gameManager.saveSiege[i].GetComponent<cardsCharacteristic>().increased = true;
                            gameManager.saveSiege[i].GetComponent<UnytCard>().powerCard++;
                        }
                    }
                }
            }
        }

    }
   
}
