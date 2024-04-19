using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passTurn : MonoBehaviour
{
    public gameManager gameManager;
    public Camera player1;
    public Camera player2;
    public void changeTurn()
    {
        if (player1.isActiveAndEnabled)
        {
            player1.enabled = false;
            player2.enabled = true;
            gameManager.playFaction = "Vikings";
            gameManager.playedTurn = false;
            return;
        }
        if (player2.isActiveAndEnabled)
        {
            player2.enabled = false;
            player1.enabled = true;
            gameManager.playFaction = "Egyptians";
            gameManager.playedTurn = false;
            return;
        }
        
    }
        
}
