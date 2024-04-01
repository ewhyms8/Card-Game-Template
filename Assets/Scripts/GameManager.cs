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
    public List<Card> deck;// = new List<Card>(52);
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
       PlayerTurn();
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
         if (player_hand.Contains or ai_hand.Contains 4 same card.health -> 
            for (int x = 0; x < handSize; x++)
            {
                if card.data.health == othercard.data.health and there are 4
                {
                    _hand.Remove(all 4 cards)
                }
            }
         }
         */
        
    }


    void Deal()
    {
       // print(deck.Count);
        for (int i = 0; i < handSize; i++)
        {
            whatCard = Random.Range(0, deck.Count);
            temp = deck[whatCard];
            deck.Remove(temp);//might cause issues towards the end of the deck
            player_hand.Add(temp);
            //player_deck.Add(temp); 
            temp = null;
            
            whatCard = Random.Range(0, deck.Count);
            temp = deck[whatCard];
            deck.Remove(temp);//might cause issues towards the end of the deck
            ai_hand.Add(temp);
            temp = null;
        }

        // move this to update, this only occurs when the func deal is called to which is once :)
        for (int i = 0; i < handSize; i++)
        {
            Card card = Instantiate(player_hand[i], new Vector3(-300 + amount, 60, 0), quaternion.identity);
            card.transform.SetParent(_Canvas);
            amount += 100;
            player_hand.Remove(card);
            card = null; 
            // I don't think this needs a return; because we want it going constantly
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
        
        Card aiCard = ai_hand[aiWant];
        print("click on a card");

        //player clicks on cards -> check if card value is the same as the one being asked
        for (int j = 0; j < player_hand.Count; j++)
        {
            if (aiCard.data.health == player_hand[j].data.health)
            {
                print("there was a match");
                ai_hand.Add(player_hand[j]);
                player_hand.Remove(player_hand[j]);
                playerTurn = true;
                //do something here
                return;
                //health is temp, assign number to each card to check if same
            }
            else
            {
                Card randCard = deck[Random.Range(0, deck.Count)];
                deck.Remove(randCard);
                ai_hand.Add(randCard);
                playerTurn = true;
            }
        }
        //check if 4 of a kind, if so add hud.oPoints += 1; & playerTurn = true
    }

   
    public void PlayerTurn()
    {
        int playerWant = Random.Range(0, player_hand.Count);
        // ^ change to on click event when I can think
        print("Player Turn :)");
        Card playerCard = player_hand[playerWant];
        for (int i = 0; i < ai_hand.Count; i++)
        {
            if (playerCard.data.health == ai_hand[i].data.health)
            {
                ai_hand.Remove(ai_hand[i]);
                player_hand.Add(ai_hand[i]);
                return;
            }
            else
            {
                print("Go Fish. Draw a card and end your turn");
            }

        }
        
        
        //check for matches in player_hand
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (playerSelect == true)
        {
            playerSelected = other.gameObject;
        }
    }
}
