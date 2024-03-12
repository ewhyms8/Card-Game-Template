using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyHand : MonoBehaviour
{
    public Button m_firstButton;
    public bool cardAddedToHand;
    public List<Card> playerDeck = new List<Card>();

    public hud hud;
    // Start is called before the first frame update
    void Start()
    {
        hud = GameObject.FindObjectOfType<hud>();
        print("Jelly FISH!!!!!!");
        m_firstButton.onClick.AddListener(TaskOnClick);
    }

    void Update()
    {
        /* if 2 same cards in hand, add to hud.yPoints and remove from hand
         draw from pile (by click?), hud.remCardNum -= 1
         add random card from array to hand
         */
        
    }

    void TaskOnClick()
    {
        print("button pressed");
        hud.deckSize -= 1;
        cardAddedToHand = true;
    }
}
