using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scoreManager : MonoBehaviour
{
    public static scoreManager Instance { get; private set; }
    [SerializeField]private int points;
    public Text pointsText,maxPointsText;
    public GameObject gameManager;
    private GameManager gameManagerScript;
    private void Awake()
    {
        Instance = this; 
    }
    private void Update()
    {
        UpdateMaxPoints();
    }
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }
    public void IncreasePoints()
    {
        points++;
        pointsText.text = points.ToString();
    }
    public void UpdateMaxPoints()
    {
        if (gameManagerScript.gameState == GameState.Lose)
        {
            int maxPoints = PlayerPrefs.GetInt("Max", 0);
            if (points >= maxPoints)
            {
                maxPoints = points;
                PlayerPrefs.SetInt("Max", maxPoints);                
            }
            maxPointsText.text = "BEST: " + maxPoints.ToString();            
            points = 0;
            pointsText.text = points.ToString();
            gameManagerScript.gameState = GameState.Ended;
        }
        
    }
}
