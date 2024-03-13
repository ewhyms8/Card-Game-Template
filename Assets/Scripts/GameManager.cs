using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
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
    //public Card card;

    private int whatCard;
    
    private int AICard;
    public int handSize;
    public float amount;

    public Transform[] myHand; // cardSlots in vid
    public bool[] availableCardSlots;
    // get hand index from EmilyCard
    

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
            //Card card = Instantiate(player_hand[i] , new Vector3(amount, 93, 0));
            Card card = Instantiate(player_hand[i], new Vector3(amount, 93, 0), quaternion.identity);
            card.transform.SetParent(_Canvas);
            amount += 300;
            player_hand.Remove(card);
            card = null; // player hand changed
        }
        
    }

    public void DrawCard()
    {
        if(deck.Count >= 1) {
            Card randCard = deck[Random.Range(0, deck.Count)];
                
            for (int i = 0; i < availableCardSlots.Length; i++)
            {
                if(availableCardSlots[i] == true) {
                    randCard.gameObject.SetActive(true);
                    //randCard.handIndex = i;
                    randCard.transform.position = myHand[i].position;
                    availableCardSlots[i] = false;
                    deck.Remove(randCard); //<- this will not be rand, it will be a group of 4
                    return;
                }
            }
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
            if (player_hand.Contains(GiantSquid))
            {
                player_hand.Remove(GiantSquid);
                ai_hand.Add(GiantSquid);
            }
        }
        else
        {
            print("Do you have any Rainbow Trout?");
            if (player_hand.Contains(trout))
            {
                player_hand.Remove(trout);
                ai_hand.Add(trout);
            }
        }
        
        
        //Ask for a card in their deck, more off a type of card = more likely to ask for that card
    }
    */
    
    

}
