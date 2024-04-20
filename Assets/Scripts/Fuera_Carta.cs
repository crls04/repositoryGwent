using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuera_Carta : MonoBehaviour
{
    public initialGame game;
    public int carta = 0;
    public gameManager manager;

    public void Usar()
    {
        if (manager.playFaction == "Vikings")
        {
            game.Botar(carta, manager.deck2);
        }
        if (manager.playFaction == "Egyptians")
        {
            game.Botar(carta, manager.deck1);
        }
    }

}
