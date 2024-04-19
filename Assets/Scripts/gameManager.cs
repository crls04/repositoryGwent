using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public string playFaction = "Egyptians";
    public bool playedTurn;
    public Deck deck1;
    public Deck deck2;
    public GameObject[] saveWeather = new GameObject[6];
    public GameObject[] saveIncrease = new GameObject[6];
    public GameObject[] saveMelee = new GameObject[8];
    public GameObject[] saveRange = new GameObject[8];
    public GameObject[] saveSiege = new GameObject[8];
    public TextMeshProUGUI text1, text2;
    private int power1, power2;


    private void Update()
    {
        Powers();
        TextUI();
    }
    private void Powers()
    {
        power1 = 0;
        power2 = 0;
        for(int i = 0; i < 8; i++)
        {
            if (saveMelee[i] != null)
            {
                if (deck1.CompareTag(saveMelee[i].GetComponent<cardsCharacteristic>().faction))
                {
                    power1 += saveMelee[i].GetComponent<UnytCard>().powerCard;
                }
                if (deck2.CompareTag(saveMelee[i].GetComponent<cardsCharacteristic>().faction))
                {
                    power2 += saveMelee[i].GetComponent<UnytCard>().powerCard;
                }
            }

            if (saveRange[i] != null)
            {
                if (deck1.CompareTag(saveRange[i].GetComponent<cardsCharacteristic>().faction))
                {
                    power1 += saveRange[i].GetComponent<UnytCard>().powerCard;
                }
                if (deck2.CompareTag(saveRange[i].GetComponent<cardsCharacteristic>().faction))
                {
                    power2 += saveRange[i].GetComponent<UnytCard>().powerCard;
                }
            }

            if (saveSiege[i] != null)
            {
                if (deck1.CompareTag(saveSiege[i].GetComponent<cardsCharacteristic>().faction))
                {
                    power1 += saveSiege[i].GetComponent<UnytCard>().powerCard;
                }
                if (deck2.CompareTag(saveSiege[i].GetComponent<cardsCharacteristic>().faction))
                {
                    power2 += saveSiege[i].GetComponent<UnytCard>().powerCard;
                }
            }
        }
    }

    private void TextUI()
    {
        if(playFaction == "Vikings")
        {
            text1.text ="Poder:" + power2.ToString();
            text2.text ="Poder:" + power1.ToString();
        }
        if (playFaction == "Egyptians")
        {
            text1.text = "Poder: " + power1.ToString();
            text2.text = "Poder: " + power2.ToString();
        }
    }
}
