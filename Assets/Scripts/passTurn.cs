using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class passTurn : MonoBehaviour
{
    public gameManager gameManager;
    public Camera player1;
    public Camera player2;
    //Metodo que realiza el intercambio de camaras y permite jugadas nuevas
    public void changeTurn()
    {
        if (player1.isActiveAndEnabled)
        {
            if(!gameManager.player2 && !gameManager.initial1)
            {
                player1.enabled = false;
                player2.enabled = true;
                gameManager.playFaction = "Vikings";

            }
            if (!gameManager.playedTurn && !gameManager.initial1)
            {
                gameManager.player1 = true;
            }
            gameManager.playedTurn = false;
            return;
        }
        if (player2.isActiveAndEnabled)
        {
            if(!gameManager.player1 && !gameManager.initial2)
            {
                player2.enabled = false;
                player1.enabled = true;
                gameManager.playFaction = "Egyptians";
            }
           
            if (!gameManager.playedTurn && !gameManager.initial2)
            {
                gameManager.player2 = true;
            }
            gameManager.playedTurn = false;
            gameManager.decoy = null;
            return;
        }
        
    }
        
}
