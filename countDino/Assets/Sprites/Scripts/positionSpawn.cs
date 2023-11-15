using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionSpawn : MonoBehaviour
{    
    public GameObject[] prefabs;
    public float posicionX; // La posición en el eje X donde quieres instanciar el prefab
    public float rangoYMin; // Valor mínimo para la posición en el eje Y
    public float rangoYMax; // Valor máximo para la posición en el eje Y

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
            // Combina la posición en X fija con la posición aleatoria en Y
            Vector3 posicionDeseada = new Vector3(posicionX, posicionY, 0f);

            // Instancia el prefab en la posición deseada con la rotación predeterminada
            GameObject instanciaPrefab = Instantiate(prefabs[randomIndex], posicionDeseada, Quaternion.identity);

            // Puedes hacer más cosas con la instanciaPrefab si es necesario
            // Por ejemplo, modificar propiedades del objeto instanciado.   
        }
    }
}
