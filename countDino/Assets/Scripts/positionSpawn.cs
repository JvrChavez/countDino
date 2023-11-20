using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class positionSpawn : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript; // Agrega una referencia al script GameManager
    public GameObject[] prefabsDinos,prefabsBtns;
    public float posicionX, rangoYMin, rangoYMax;
    public float[] listY;
    private float manyDinos;


    void Start()
    {
        // Obtener el script GameManager desde el objeto gameManager
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }

    void Update()
    {        
        SpawnDinos();
        SpawnButtons();
    }
    void SpawnDinos()
    {
        if (gameManagerScript.gameState == GameState.StartRun)
        {
            Debug.Log("Hola");
            manyDinos = UnityEngine.Random.Range(1, 11);
            listY = new float[(int)manyDinos];
            int contadorSprite = 0;
            for (int i = 0; i < manyDinos; i++)
            {
                rangoYMax = (contadorSprite == 3) ? 130 : 0;
                rangoYMin = (contadorSprite == 3) ? 0 : -130;

                float posicionY;
                do
                {
                    posicionY = Mathf.Round(UnityEngine.Random.Range(rangoYMin, rangoYMax) / 20f) * 20f;
                } while (listY.Contains(posicionY));

                listY[i] = posicionY;
                Vector3 setPosition = new Vector3(posicionX, posicionY, 0f);
                GameObject instanciaPrefab = Instantiate(prefabsDinos[contadorSprite], setPosition, Quaternion.identity);                

                contadorSprite = (contadorSprite != 3) ? contadorSprite + 1 : 0;
            }
            gameManagerScript.gameState = GameState.Running;
            StartCoroutine(EsperarYContinuar());
        }
    }
    IEnumerator EsperarYContinuar()
    {
        yield return new WaitForSeconds(1000);
        gameManagerScript.gameState = GameState.Answering;
    }
    void SpawnButtons()
    {
        if (gameManagerScript.gameState == GameState.Answering)
        {
            for (int i = 0; i < 4; i++)
            {
                GameObject botonPrefab = Instantiate(prefabsBtns[i], new Vector3((-250+(i*150)) , 0, 0f), Quaternion.identity);
                botonPrefab.GetComponentInChildren<Text>().text = manyDinos.ToString();
            }
            gameManagerScript.gameState = GameState.Ended;
            
        }        
    }
}
