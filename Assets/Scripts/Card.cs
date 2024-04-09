using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    public static Card card;
    public Card_data data;

    public string card_name;
    public string description;
    public int health;
    public int cost;
    public int damage;
    public Sprite sprite;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI costText;
    public TextMeshProUGUI damageText;
    public Image spriteImage;

    public bool hasBeenPlayed;
    public int handIndex;
    private GameManager gm;
    public hud hud;
        

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        
        card_name = data.card_name;
        description = data.description;
        health = data.health;
        cost = data.cost;
        damage = data.damage;
        sprite = data.sprite;
        nameText.text = card_name;
        descriptionText.text = description;
        healthText.text = health.ToString();
        costText.text = cost.ToString();
        damageText.text = damage.ToString();
        spriteImage.sprite = sprite;

    }

    // Update is called once per frame
    void Update()
    {
        
        if (card != null && card != this)
        {
            Destroy(gameObject); //gm.card doesn't work this was also a failed attempt
            hud.amount -= 50;
        }
        else
        {
            card = this;
            DontDestroyOnLoad(this.gameObject);
        }
        
    }
    
    /*
    private void OnMouseDown()
    {
        if (hasBeenPlayed == false)
        {
            hasBeenPlayed = true;
            gm.availableCardSlots[handIndex] = true;
            //Invoke("MoveToDisscardPile", 2f);
        }
    }

    void MoveToDiscardPile()
    {
        //gm.discard_pile.Add(the four cards);
    }
    */
}
