using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public List<Card> deck = new List<Card>(52);
    public List<Card> player_deck = new List<Card>();
    public List<Card> ai_deck = new List<Card>();
    public List<Card> player_hand = new List<Card>();
    public List<Card> ai_hand = new List<Card>();
    public List<Card> discard_pile = new List<Card>();


    public Card trout;
    public Card GiantSquid;
    public Card Jellyfish;


    private float whatCard;
    private float AICard;

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
        deck.Add(trout);
        Deal();
        Instantiate(trout);
    }

    // Update is called once per frame
    void Update()
    {
        
        whatCard = Random.Range(1, 3);
        AI_Turn();
        
    }

    void Deal()
    {
        if (whatCard == 1)
        {
            player_deck.Add(trout);
            deck.Remove(trout);
            print("gave trout to player");
            Instantiate(trout);
        }

        if (whatCard == 2)
        {
            player_deck.Add(GiantSquid);
            deck.Remove(GiantSquid);
            print("gave giant squid to player");
            Instantiate(GiantSquid);
        }

        if (whatCard == 3)
        {
            player_deck.Add(Jellyfish);
            deck.Remove(Jellyfish);
            print("gave jellyfish to player");
        }
    }

    void Shuffle()
    {
        
        
    }

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
    
}
