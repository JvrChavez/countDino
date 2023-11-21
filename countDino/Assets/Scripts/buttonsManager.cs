using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonsManager : MonoBehaviour
{
    public Button [] btns;
    public Text[] txts;

    void Start()
    {

        foreach (Button btn in btns)
        {
            btn.interactable = true;
        }
        // Seleccionar aleatoriamente el índice del botón correcto
        int indiceBotonCorrecto = Random.Range(0, btns.Length);
        txts[indiceBotonCorrecto].text = "C";
        btns[indiceBotonCorrecto].onClick.AddListener(BotonCorrecto);

        // Asignar el listener de BotonIncorrecto a los demás botones
        for (int i = 0; i < btns.Length; i++)
        {
            btns[i].interactable = true;
            if (i != indiceBotonCorrecto)
            {
                txts[i].text = "I";
                btns[i].onClick.AddListener(BotonIncorrecto);
            }
        }
    }

    void BotonCorrecto()
    {
        Debug.Log("¡Correcto!");
    }

    void BotonIncorrecto()
    {
        Debug.Log("Incorrecto. Intenta de nuevo.");
    }
}
