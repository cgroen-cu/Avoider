using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{
    //inputs
    //start title text
    public string titleName;
    //The text of title
    public GameObject text;
    public Text titleCard;
    //player
    public Penguin penny;
    public BearMovement bear1;
    public BearMovement bear2;

    //Buttons
    public ButtonManager buttonManager;
    //Play button
    public GameObject playbutton;
    public Button Button_Play;
    public bool win = true;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Hello");
        Init(0);
    }

    public void Init(int deathType)
    {
        Debug.Log("Initializing");
        text.SetActive(true);
        if(deathType == 1)
        {
            titleCard.text = "You got the sardine!";
        } else if (deathType == 2)
        {
            titleCard.text = "You fell in the water";
        } else if (deathType == 3)
        {
            titleCard.text = "You were eaten by a polar bear";
        } else 
            titleCard.text = titleName;
        buttonManager.switchButtonOn();
        penny.switchMove();
        penny.Init();
        bear1.Init();
        bear2.Init();
    }
    //after pressing play
    public void startGame()
    {
        Debug.Log("Starting Game");
        buttonManager.switchButtonOff();
        text.SetActive(false);
        penny.switchMove();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
