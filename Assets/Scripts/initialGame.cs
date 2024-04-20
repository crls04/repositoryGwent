using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class initialGame : MonoBehaviour
{
    public Deck deck1, deck2;
    private bool inicial = true;
    public RawImage[] Image = new RawImage[10];
    public GameObject Boton;
    private int cant = 0;
    public gameManager manager;

    private void OnMouseDown()
    {
        if(inicial)
        {
            deck1.drawCard(10);
            deck2.drawCard(10);
            inicial = false;
            for(int f = 0; f < Image.Length;f++)
            {
                Image[f].texture = deck1.hand[f].GetComponent<SpriteRenderer>().sprite.texture;
                Image[f].transform.localScale = Vector2.one;
            }
            Boton.transform.localScale = Vector2.one;
        }
    }

    public void Siguiente_Jugador()
    {
        if(manager.playFaction == "Vikings" && manager.initial2)
        {
            for (int f = 0; f < Image.Length; f++)
            {
                Image[f].texture = deck2.hand[f].GetComponent<SpriteRenderer>().sprite.texture;
                Image[f].transform.localScale = Vector2.one;
            }
            Boton.transform.localScale = Vector2.one;
        }
    }

    public void Botar(int carta, Deck deck)
    {
        Destroy(deck.hand[carta]);
        deck.hand[carta] = null;
        deck.drawCard(1);
        Image[carta].transform.localScale = Vector2.zero;
        cant++;
        if(cant == 2)
        {
            End_Fase();
        }
    }

    public void End_Fase()
    {
        for(int f = 0; f < Image.Length; f++)
        {
            if (Image[f].texture != null)
            {
                Image[f].transform.localScale = Vector3.zero;
                Boton.transform.localScale = Vector3.zero;
            }
        }
        if(manager.playFaction == "Vikings")
        {
            manager.initial2 = false;
        }
        if (manager.playFaction == "Egyptians")
        {
            manager.initial1 = false;
        }
        cant = 0;
    }
}
