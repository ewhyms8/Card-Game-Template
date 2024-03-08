using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EmilyCard : MonoBehaviour
{
    public Card_data data;
    public bool hasBeenplayed;

    public int handIndex;

    private GameManager gm;

    public string card_name;
    public string description;
    public Sprite sprite;
    public TextMeshProUGUI nameText1;
    public TextMeshProUGUI nameText2;
    public Image spriteImage;
        

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        // this will become true when matched with another of its type
        card_name = data.card_name;
        description = data.description;
        sprite = data.sprite;
        nameText1.text = card_name;
        nameText2.text = description;
        spriteImage.sprite = sprite;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        if (hasBeenplayed == false)
        {
            //player can select card to go into discard pile -> move card to another list
            // if ^ hasBeenPlayed = true;
            //gm.availableCardSlots[handIndex] = true;
            //Invoke("MoveToDiscardPile", 2f);
            //Player points ++
        }
    }

    void MoveToDiscardPile()
    {
        //gm.discard_pile.Add(this);
        //5:49
    }
}