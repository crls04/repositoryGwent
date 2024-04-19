using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class clearenceCard : MonoBehaviour
{
    public gameManager gameManager;
    public void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("gameManager").GetComponent<gameManager>();
    }
    public void clear()
    {
        for (int f = 0; f < gameManager.saveWeather.Length; f++)
        {
            if(gameManager.saveWeather[f] != null)
            {
                gameManager.saveWeather[f].GetComponent<weatherCards>().Delete();
                Destroy(gameManager.saveWeather[f]);
                gameManager.saveWeather[f] = null;
            }
           
        }
        for(int f = 0; f < gameManager.deck1.weather1.Length; f++)
        {
            gameManager.deck1.weather1[f] = false;
        }
        for (int f = 0; f < gameManager.deck2.weather1.Length; f++)
        {
            gameManager.deck2.weather1[f] = false;
        }
    }
    public void Update()
    {
        if (GetComponent<cardsCharacteristic>().summonedCard)
        {
           clear();
           Destroy(gameObject,1);
        }
    }
}
