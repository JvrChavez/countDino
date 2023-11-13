using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnManager : MonoBehaviour
{
    public GameObject[] prefabs; // Un arreglo que contiene tus 4 prefabs diferentes

    void Start()
    {
        int indiceAleatorio = Random.Range(0, prefabs.Length); // Genera un �ndice aleatorio dentro del rango de prefabs

        GameObject objetoGenerado = Instantiate(prefabs[indiceAleatorio], transform.position, Quaternion.identity);

        // Puedes ajustar la posici�n y la rotaci�n seg�n tus necesidades.
    }
}
