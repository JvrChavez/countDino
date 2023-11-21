using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonsManager : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    
    void Start()
    {
        // Obtener el script GameManager desde el objeto gameManager
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }
    void Update()
    {
    }
    
}
