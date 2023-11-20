using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState { Ready, StartRun, Running, Answering, Ended };
public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Ready;
    public GameObject uiReady;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ifStart();
    }
    void ifStart()
    {
        if (gameState==GameState.Ready && Input.GetMouseButtonDown(0))
        {
            gameState = GameState.StartRun;
            uiReady.SetActive(false);
        }
    }
}
