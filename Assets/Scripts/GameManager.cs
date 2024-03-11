using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<Card> deck = new List<Card>(52);
    public List<Card> player_deck = new List<Card>();
    //public List<Card> ai_deck = new List<Card>();
    public List<Card> player_hand = new List<Card>();
    public List<Card> ai_hand = new List<Card>();
    public List<Card> discard_pile = new List<Card>();

    
    public Card temp;
    public Card card;

    private int whatCard;
    
    private int AICard;
    public int handSize;
    public float amount;

    public Transform[] myHand;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        
      
        
    }


    void Deal()
    {
        for (int i = 0; i < handSize; i++)
        {
            whatCard = Random.Range(0, deck.Count);
            temp = deck[whatCard];
            deck.Remove(temp);
            player_hand.Add(temp);
            player_deck.Add(temp);
            temp = null;
            
            
            whatCard = Random.Range(0, deck.Count);
            temp = deck[whatCard];
            deck.Remove(temp);
            ai_hand.Add(temp);
            temp = null;
        }

        for (int i = 0; i < handSize; i++)
        {
            card = player_deck[0];
            Instantiate(card , new Vector3(amount, 93, 0));
            amount += 100;
            player_deck.Remove(card);
        }
        
    }

    private void Instantiate(Card original, Vector3 position)
    {
        throw new NotImplementedException();
    }

    void Shuffle()
    {
        
        
    }
/*
    void AI_Turn()
    {
        AICard = Random.Range(1, 13);
        if (AICard == 2)
        {
            print("Do you have any giant squid?");
            if (player_deck.Contains(GiantSquid))
            {
                player_deck.Remove(GiantSquid);
                ai_deck.Add(GiantSquid);
            }
        }
        else
        {
            print("Do you have any Rainbow Trout?");
            if (player_deck.Contains(trout))
            {
                player_deck.Remove(trout);
                ai_deck.Add(trout);
            }
        }
        
        
        //Ask for a card in their deck, more off a type of card = more likely to ask for that card
    }
    
    public void DrawCard()
    {
        /* if(deck.Count >= 1) {
                Card randCard = deck[Random.Range(0, deck.Count)];
                
                for (int i = 0; i < availableCardSlots.Length; i++)
                {
                    if(availableCardSlots[i] == true) {
                        randCard.gameObject.SetActive(true);
                        randCard.handIndex = i;
                        
                        //this is where empty card slots come in
                        randCard.transform.position = cardSlots[i].position;
                        availableCardSlots[i] = false;
                        deck.Remove(randCard); //<- this will not be rand, it will be a group of 4
                        return;
                        // 3:29 - time needed for hierarchy part
                    }
                }
            }
         */
        
   // }//left off at 5:49, card is EmilyCard

}
