using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor;
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
    public int amount = 0;
    private int AiHandSize;

    public bool playerTurn = true;
    public hud hud;
    private bool playerSelect;
    private GameObject playerSelected;
    

    public int aiNeeds;
    public TextMeshProUGUI aiAsks;
    public TextMeshProUGUI whosTurn;
    public int oPoints = 0;
    public int yPoints = 0;

    public Card card;

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
        hud = GameObject.FindObjectOfType<hud>();
       //PlayerTurn();
    }
    
    void Update()
    {
        if (playerTurn == false)
        {
            print("player turn over");
            AI_Turn();
        }
        
       
        
    }
    
    void Deal()
    {
       // print(deck.Count);
        for (int i = 0; i < handSize; i++)
        {
            temp = null;
            whatCard = Random.Range(0, deck.Count);
            temp = Instantiate(deck[whatCard], new Vector3(-300 + amount, 60, 0), quaternion.identity);
            deck.Remove(temp);//might cause issues towards the end of the deck
            player_hand.Add(temp);
            
            temp.transform.SetParent(_Canvas);
            amount += 100;
            
            if (player_hand.Count > 1)
            {
                //we do this count-1 times because we don't want to compare temp to the last card in the hand (which is also temp)
                for(int j = 0; j < player_hand.Count-1; j++)
                {
                    if (temp.data.health == player_hand[j].data.health)
                    {
                        player_hand.Remove(temp);
                        player_hand.Remove(player_hand[j]);
                        Match(temp, player_hand[j], "player");
                    }
                }
            }
            temp = null;
            
            //same temp? maybe issue
            temp = deck[whatCard];
            deck.Remove(temp);//might cause issues towards the end of the deck
            ai_hand.Add(temp);
            if (ai_hand.Count > 1)
            {
                //we do this count-1 times because we don't want to compare temp to the last card in the hand (which is also temp)
                for(int k = 0; k < ai_hand.Count-1; k++)
                {
                    if (temp.data.health == ai_hand[k].data.health)
                    {
                        Match(temp, ai_hand[k], "ai");
                    }
                }
            }
            temp = null;
        }
    }

    public void DrawCard()
    {
        if(deck.Count >= 1)
        {
            temp = deck[Random.Range(0, deck.Count)];
            
            player_hand.Add(temp);
            deck.Remove(temp);
            hud.deckSize -= 1;
            for (int i = 0; i < player_hand.Count; i++)
            {
                Instantiate(temp, new Vector3(-300 + amount + 100, 60, 0), Quaternion.identity);
            }
            playerTurn = false;
        }
    }
    
    void AI_Turn()
    {
        whosTurn.text = "Ai's turn";
        int aiWant = Random.Range(0, ai_hand.Count);
        Card aiCard = ai_hand[aiWant];
        aiNeeds = aiCard.data.health;
        aiAsks.text = "Do you have any " + aiNeeds;
        for (int j = 0; j < player_hand.Count; j++)
        {
            if (aiCard.data.health == player_hand[j].data.health)
            {
                ai_hand.Add(player_hand[j]);
                player_hand.Remove(player_hand[j]);
                Match(aiCard, player_hand[j], "player");
                playerTurn = true;
                //do something here
                return;
            }
            else
            {
                Card randCard = deck[Random.Range(0, deck.Count)];
                deck.Remove(randCard);
                ai_hand.Add(randCard);
                playerTurn = true;
            }
        }
        whosTurn.text = null;
    }
    
    public void PlayerTurn()
    {
        whosTurn.text = "Your Turn, pick a card you want to ask for";
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
        whosTurn.text = null;
    }

    void Match(Card one, Card two, string playerPoints)
    {
        print("matched");
        one.gameObject.SetActive(false);
        two.gameObject.SetActive(false);
        // add and remove from lists, discard
        
        if (playerPoints == "ai")
            oPoints++;
        else
        {
            yPoints++;
        }
        print(yPoints);
        print(oPoints);

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (playerSelect == true)
        {
            playerSelected = other.gameObject;
        }
    }
    
}
