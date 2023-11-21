using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class positionSpawn : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager gameManagerScript;
    public GameObject[] prefabsDinos,prefabsBtns;
    public float posicionX, rangoYMin, rangoYMax;
    public float[] listY;
    private float manyDinos;
    void Start()
    {
        gameManagerScript = gameManager.GetComponent<GameManager>();
    }
    void Update()
    {        
        SpawnDinos();
    }
    void SpawnDinos()
    {
        if (gameManagerScript.gameState == GameState.StartRun)
        {
            manyDinos = UnityEngine.Random.Range(1, 11);
            gameManagerScript.correct = (int)manyDinos;
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
            StartCoroutine(EsperarYCambiarEstado());
        }
    }
    IEnumerator EsperarYCambiarEstado()
    {
        yield return new WaitForSeconds(8);//Espera 8 segundos.
        gameManagerScript.gameState = GameState.StartAnswer;
    }
}
