using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public enum GameState { Ready, StartRun, Running, StartAnswer,Answering, Lose,Ended };
public class GameManager : MonoBehaviour
{
    public GameState gameState = GameState.Ready;
    public GameObject uiReady;
    public GameObject UIScore;
    public GameObject UIBtns;
    public GameObject UIEnd;
    public Button[] btns;
    public Text[] txts;
    public int correct;
    void Update()
    {
        ifStart();
        SpawnButtons();
        methodExit();
    }
    void ifStart()
    {
        if (gameState==GameState.Ready && Input.GetMouseButtonDown(0))
        {
            gameState = GameState.StartRun;
            uiReady.SetActive(false);
            UIScore.SetActive(true);
        }
        if (gameState == GameState.Ended && Input.GetMouseButtonDown(0))
        {
            gameState = GameState.StartRun;
            UIEnd.SetActive(false);
            AudioManager.Instance.PlayMusic();
        }
    }
    void SpawnButtons()
    {
        if (gameState == GameState.StartAnswer)
        {
            UIBtns.SetActive(true);
            foreach (Button btn in btns)
            {
                btn.interactable = true;
            }
            string [] listTxt = new string[4];
            // Seleccionar aleatoriamente el índice del botón correcto
            int indiceBotonCorrecto = Random.Range(0, btns.Length);
            txts[indiceBotonCorrecto].text = correct.ToString();
            btns[indiceBotonCorrecto].onClick.AddListener(BotonCorrecto);
            listTxt[indiceBotonCorrecto] = txts[indiceBotonCorrecto].text;

            for (int i = 0; i < btns.Length; i++)
            {
                btns[i].interactable = true;
                if (i != indiceBotonCorrecto)
                {
                    do
                    {
                        string randomNum;
                        if (correct<4)
                        {
                            randomNum = Random.Range(Mathf.Abs(correct - 2), correct + 4).ToString();
                        }
                        else if (correct>7)
                        {
                            randomNum = Random.Range(correct - 3, correct + 2).ToString();
                        }
                        else
                        {
                            randomNum = Random.Range(correct - 3, correct + 3).ToString();
                        }                        
                        txts[i].text = randomNum;
                    } while (listTxt.Contains(txts[i].text));
                    listTxt[i] = txts[i].text;
                    btns[i].onClick.AddListener(BotonIncorrecto);
                }
            }
            gameState = GameState.Answering;
        }else if (gameState == GameState.StartRun)
        {
            UIBtns.SetActive(false);
        }else if (gameState == GameState.Ended)
        {
            UIBtns.SetActive(false);
            UIEnd.SetActive(true);
        }
    }
    void BotonCorrecto()
    {
        Debug.Log("¡Correcto!");
        foreach (Button btn in btns)
        {
            btn.onClick.RemoveAllListeners();
        }
        scoreManager.Instance.IncreasePoints();
        AudioManager.Instance.PlaySound("Point");
        gameState = GameState.StartRun;
    }
    void BotonIncorrecto()
    {
        Debug.Log("Incorrecto.");
        foreach (Button btn in btns)
        {
            btn.onClick.RemoveAllListeners();        
        }
        AudioManager.Instance.PlaySound("spongebob-fail");
        AudioManager.Instance.StopMusic();
        gameState = GameState.Lose;
    }
    void methodExit()
    {
        if (Input.GetKeyDown("escape")) {
            Application.Quit();
            Debug.Log("Exit App");
        }        
    }
}