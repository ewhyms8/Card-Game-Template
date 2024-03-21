using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<Card> deck = new List<Card>(52);
    //public List<Card> player_deck = new List<Card>();
    //public List<Card> ai_deck = new List<Card>();
    public List<Card> player_hand = new List<Card>();
    public List<Card> ai_hand = new List<Card>();
    public List<Card> discard_pile = new List<Card>();
    public Transform _Canvas;
    
    public Card temp;
    private int whatCard;
    
    private int AICard;
    private int handSize = 7;
    private float amount;
    private int AiHandSize;

    public bool playerTurn = true;
    public hud hud;
    private bool playerSelect;
    private GameObject playerSelected;

    public Transform[] myHand; // cardSlots in vid
    public bool[] availableCardSlots;
    

    private void Awake()
    {
        if (gm != null && gm != this)
        {
            Destroy(gameObject);
        }
        else
        {
            gm = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       Deal();
       amount = 0;
       hud = GameObject.FindObjectOfType<hud>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn == false)
        {
            print("player turn over");
            AI_Turn();
        }
        /*
         if (player hand or ai_hand.Contains 4 same card.health -> 
         public system.collections.generic.list<player_hand> FindAll (Predicate<T> match);
         list<player_hand> results = player_hand.FindAll(jellyfish) this for all possibilities
            if results != 4
            {
                no points
            }
            else
            {
                hud.player or ai points += 1; 
            }
         }
         */
        
    }


    void Deal()
    {
        for (int i = 0; i < handSize; i++)
        {
            whatCard = Random.Range(0, deck.Count);
            temp = deck[whatCard];
            deck.Remove(temp);
            player_hand.Add(temp);
            //player_deck.Add(temp); 
            temp = null;
            
            
            whatCard = Random.Range(0, deck.Count);
            temp = deck[whatCard];
            deck.Remove(temp);
            ai_hand.Add(temp);
            temp = null;
        }

        for (int i = 0; i < handSize; i++)
        {
            Card card = Instantiate(player_hand[i], new Vector3(-300 + amount, 60, 0), quaternion.identity);
            card.transform.SetParent(_Canvas);
            amount += 100;
            player_hand.Remove(card);
            card = null; 
        }
        
    }

    public void DrawCard()
    {
        if(deck.Count >= 1)
        {
            Card randCard = deck[Random.Range(0, deck.Count)];
            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if(availableCardSlots[i] == true)
                {
                    randCard = Instantiate(randCard, myHand[i].position, quaternion.identity);
                    randCard.handIndex = i;
                    availableCardSlots[i] = false;
                    player_hand.Add(temp);
                    deck.Remove(randCard); //<- this will not be rand, it will be a group of 4
                    return;
                }
            }
        }
    }
    
    void AI_Turn()
    {
        //AiHandSize = 7f;
        int aiWant = Random.Range(0, ai_hand.Count);
        for (int i = 0; i < player_hand.Count; i++)
        {
            Card aiCard = ai_hand[i];
            print("click on a card");
            //player clicks on cards -> check if card value is the same as the one being asked
            if (aiCard.data.health == playerSelected.GetComponent<Card_data>().health)
            {
                //health is temp, assign number to each card to check if same
            }
            //same card? or just same card place in hand?
            Card hasCard = player_hand[i];
            if (player_hand.Contains(hasCard))
            {
                ai_hand.Add(hasCard);
                player_hand.Remove(hasCard);
            }
            else
            {
                Card randCard = deck[Random.Range(0, deck.Count)];
                deck.Remove(randCard);
                ai_hand.Add(randCard);
            }
        }
        //check if 4 of a kind, if so add hud.oPoints += 1; & playerTurn = true;

    }

    public void PlayerTurn()
    {
        
        /*
        click on card to ask for one
        
        check for that card in ai_hand
        if(ai_hand.Contains(card you want)
        {
            if ai has card move from ai_hand to player_hand
            ai_hand.Remove(card);
            player_hand.Add(Card);
        }
        
        else
        {
             if not in ai hand give card to player from draw card have player end turn
             DrawCard();
             playerTurn = false;
        }
        
        check for matches
        */
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (playerSelect = true)
        {
            playerSelected = other.gameObject;
        }
    }
}
