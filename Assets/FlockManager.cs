using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public int numFish = 20;
    public GameObject[] allFish;
    public Vector3 swinLimits = new Vector3(5, 5, 5);
    public Vector3 goalPos;

    [Header("Configurações do Cardume")]
    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed;

    void Start()
    {
        allFish = new GameObject[numFish];

        for (int i = 0; i < numFish; i++)
        {
            // Define uma posição aleatória dentro dos limites especificados
            Vector3 pos = this.transform.position + new Vector3(
                Random.Range(-swinLimits.x, swinLimits.x),
                Random.Range(-swinLimits.y, swinLimits.y),
                Random.Range(-swinLimits.z, swinLimits.z));

            // Instancia um peixe e atribui ao array de todos os peixes
            allFish[i] = Instantiate(fishPrefab, pos, Quaternion.identity);
            allFish[i].GetComponent<Flock>().myManager = this;
        }

        goalPos = this.transform.position;
    }

    void Update()
    {
        // Define a posição do objetivo para a posição atual do objeto FlockManager
        goalPos = this.transform.position;

        if (Random.Range(0, 100) < 10)
        {
            // Define uma nova posição aleatória dentro dos limites especificados como objetivo
            goalPos = this.transform.position + new Vector3(
                Random.Range(-swinLimits.x, swinLimits.x),
                Random.Range(-swinLimits.y, swinLimits.y),
                Random.Range(-swinLimits.z, swinLimits.z));
        }
    }
}
