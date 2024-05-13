using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UnytCard : MonoBehaviour
{
    public int powerCard;
    public string attakMode;
    public GameObject description;

    private void OnMouseEnter()
    {
        description = GameObject.FindGameObjectWithTag("textDescription");
        description.GetComponent<TextMeshProUGUI>().text += "\npoder:" + powerCard + "\nataque:" + attakMode;      
    }
}


