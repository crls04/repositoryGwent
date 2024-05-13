using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaderEgyptians : MonoBehaviour
{
    public gameManager manager;
    private bool activate = false;
    private void OnMouseDown()
    {
        if(manager.playFaction == "Egyptians")
        {
            if(!activate)
            {
                for(int f = 0; f < manager.saveSiege.Length; f++)
                {
                    if (manager.saveSiege[f] != null)
                    {
                        Destroy(manager.saveSiege[f]);
                        manager.saveSiege[f] = null;
                    }
                }
                manager.playedTurn = true;
                activate = true;
            }
        }
    }
}
