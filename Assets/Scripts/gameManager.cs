using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject decoy = null;
    public int decoyPosition;
    public string playFaction = "Egyptians";
    public bool playedTurn;
    public bool player1 = false;
    public bool player2 = false;
    public Deck deck1;
    public Deck deck2;
    public GameObject[] saveWeather = new GameObject[6];
    public GameObject[] saveIncrease = new GameObject[6];
    public GameObject[] saveMelee = new GameObject[8];
    public GameObject[] saveRange = new GameObject[8];
    public GameObject[] saveSiege = new GameObject[8];
    public TextMeshProUGUI text1, text2;
    public int power1, power2,round1,round2;
    public TextMeshProUGUI textRound1, textRound2;
    public bool initial1, initial2 = true;
    public GameObject gan1,gan2, empate,boton;
    private void Update()
    {
        Powers();
        TextUI();
        comparePower();
        TextUI1();
        End_Game();
    }

   
    //Metodo para calcular poder de cada jugador
    private void Powers()
    {
        power1 = 0;
        power2 = 0;
        //Ciclo para comprobar cada fila del campo
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

    //Metodo que verifica constantemente las rondas ganadas
    private void End_Game()
    {
        if(round1 == 2 && round2 != 2)
        {
            gan1.SetActive(true);
            boton.SetActive(true);
        }
        if (round2 == 2 && round1 != 2)
        {
            gan2.SetActive(true);
            boton.SetActive(true);
        }
        if (round1 == 2 && round2 == 2)
        {
            empate.SetActive(true);
            boton.SetActive(true);
        }
    }

    //Metodo para mostrar visualmente el poder de cada jugador
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

    //Metodo para determinar que jugador gano la ronda
    public void comparePower()
    {
        if (player1&&player2==true)
        {
            if (power1 > power2)
            {
                round1++;
            }
            if(power2 > power1)
            {
                round2++;
            }
            if(power1==power2)
            {
                round1++;
                round2++;
            }
            //vaciar el campo
            for (int f = 0; f < 8;f++)
            {
                if (saveMelee[f] != null)
                {
                    Destroy(saveMelee[f]);
                    saveMelee[f] = null;
                }
                if (saveRange[f] != null)
                {
                    Destroy(saveRange[f]);
                    saveRange[f] = null;
                }
                if (saveSiege[f] != null)
                {
                    Destroy(saveSiege[f]);
                    saveSiege[f] = null;
                }
            }
            for (int f = 0; f < 6; f++)
            {
                if (saveWeather[f] != null)
                {
                    Destroy(saveWeather[f]);
                    saveWeather[f] = null;
                }
            }
                deck1.melee1 = new bool[4];
            deck1.range1 = new bool[4];
            deck1.siege1 = new bool[4];
            deck1.increase1 = new bool[3];
            deck1.weather1 = new bool[3];
            deck2.melee1 = new bool[4];
            deck2.range1 = new bool[4];
            deck2.siege1 = new bool[4];
            deck2.increase1 = new bool[3];
            deck2.weather1 = new bool[3];
            player1 = false;
            player2 = false;
            playedTurn = false;

        }
    }

    //Metodo para mostrar visualmente la cantidad de rondas ganadas
    private void TextUI1()
    {
        if (playFaction == "Vikings")
        {
            textRound1.text = "" + round2.ToString();
            textRound2.text = "" + round1.ToString();
        }
        if (playFaction == "Egyptians")
        {
            textRound1.text = "" + round1.ToString();
            textRound2.text = "" + round2.ToString();
        }
    }
}
