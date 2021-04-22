using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonManager : MonoBehaviour
{
    public Button[] Buttons = new Button[2];
    //public Tile[] Tiles = new Tile[9];
    public GameObject button1;
    public GameObject button2;

    public void switchButtonOn()
    {
        button1.SetActive(true);
        button2.SetActive(true);
    }
    public void switchButtonOff()
    {
        button1.SetActive(false);
        button2.SetActive(false);
    }
}