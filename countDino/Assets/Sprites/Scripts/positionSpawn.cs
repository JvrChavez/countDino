using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionSpawn : MonoBehaviour
{    
    public GameObject[] prefabs;
    public float posicionX; // La posici�n en el eje X donde quieres instanciar el prefab
    public float rangoYMin; // Valor m�nimo para la posici�n en el eje Y
    public float rangoYMax; // Valor m�ximo para la posici�n en el eje Y

    void Start()
    {
        float manyDinos = Random.Range(1, 11);
        for (int i = 0; i < manyDinos; i++)
        {         
            int randomIndex = Random.Range(0, prefabs.Length);
            if (randomIndex == 3)
            {//Indica que vuela
                rangoYMax = 130;
                rangoYMin = 0;
            }
            else
            {//Indica que camina por la tierra
                rangoYMax = 0;
                rangoYMin = -130;
            }
            float posicionY = Random.Range(rangoYMin, rangoYMax);
            // Combina la posici�n en X fija con la posici�n aleatoria en Y
            Vector3 posicionDeseada = new Vector3(posicionX, posicionY, 0f);

            // Instancia el prefab en la posici�n deseada con la rotaci�n predeterminada
            GameObject instanciaPrefab = Instantiate(prefabs[randomIndex], posicionDeseada, Quaternion.identity);

            // Puedes hacer m�s cosas con la instanciaPrefab si es necesario
            // Por ejemplo, modificar propiedades del objeto instanciado.   
        }
    }
}
