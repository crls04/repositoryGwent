using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaderVikings : MonoBehaviour
{
    public gameManager manager;
    private bool activate = false;
    private void OnMouseDown()
    {
        if (manager.playFaction == "Vikings")
        {
            if (!activate)
            {
                for (int f = 0; f < manager.saveRange.Length; f++)
                {
                    if (manager.saveRange[f] != null)
                    {
                        Destroy(manager.saveRange[f]);
                        manager.saveRange[f] = null;
                    }
                }
                activate = true;
            }
        }
    }
}
