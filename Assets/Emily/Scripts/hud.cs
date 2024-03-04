using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class hud : MonoBehaviour
{
    public TextMeshProUGUI oponentsPoints;
    public TextMeshProUGUI yourPoints;
    public float oPoints;
    public float yPoints;

    public TextMeshProUGUI numCardsRemaining;
    public float remCardNum;
    
    // Start is called before the first frame update
    void Start()
    {
        oPoints = 0;
        yPoints = 0;
        remCardNum = 52;
    }

    // Update is called once per frame
    void Update()
    {
        oponentsPoints.text = "Opponents Total Points: " + oPoints;
        yourPoints.text = "Your Total Points: " + yPoints;
        numCardsRemaining.text = "Cards remaining: " + remCardNum;
    }
}
