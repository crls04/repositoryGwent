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
            for (int f = 0; f < gameManager.saveMelee.Length;f++)
            {
                if (gameManager.saveMelee[f] != null)
                {
                    if (gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().faction == GetComponent<cardsCharacteristic>().faction)
                    {
                        if (gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().typeCard == "Silver")
                        {


                            if (!gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().increased)
                            {
                                gameManager.saveMelee[f].GetComponent<cardsCharacteristic>().increased = true;
                                gameManager.saveMelee[f].GetComponent<UnytCard>().powerCard++;
                            }
                        }
                    }
                }
            }
        }
        if (bonus == "Range")
        {
            for (int f = 0; f < gameManager.saveRange.Length; f++)
            {
                if (gameManager.saveRange[f] != null)
                {
                    if (gameManager.saveRange[f].GetComponent<cardsCharacteristic>().faction == GetComponent<cardsCharacteristic>().faction)
                    {
                        if (gameManager.saveRange[f].GetComponent<cardsCharacteristic>().typeCard == "Silver")
                        {


                            if (!gameManager.saveRange[f].GetComponent<cardsCharacteristic>().increased)
                            {
                                gameManager.saveRange[f].GetComponent<cardsCharacteristic>().increased = true;
                                gameManager.saveRange[f].GetComponent<UnytCard>().powerCard++;
                            }
                        }
                    }
                }
            }
        }
        if (bonus == "Siege")
        {
            for (int f = 0; f < gameManager.saveSiege.Length; f++)
            {
                if (gameManager.saveSiege[f] != null)
                {
                    if (gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().faction == GetComponent<cardsCharacteristic>().faction)
                    {
                        if (gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().typeCard == "Silver")
                        {


                            if (!gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().increased)
                            {
                                gameManager.saveSiege[f].GetComponent<cardsCharacteristic>().increased = true;
                                gameManager.saveSiege[f].GetComponent<UnytCard>().powerCard++;
                            }
                        }
                    }
                }
            }
        }
        
    }
   
}
