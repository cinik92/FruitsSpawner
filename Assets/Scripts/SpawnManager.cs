using UnityEngine;
using System.Collections.Generic;
using TMPro;


public class SpawnManager : MonoBehaviour
{
    private float spawnRange = 5.0f;
    public GameObject fruitPrefab;
    public int fruitCount;
    public int maxObjects = 10;
    private float spawnInterval = 2.0f;
    private float timer = 0f;
    public TextMeshProUGUI objectCounterText;
    private List<GameObject> activeObjects = new List<GameObject>();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        UpdateObjectCounter();


    }

    // Update is called once per frame
    void Update()
    {


        timer += Time.deltaTime;

        // Generar un nuevo objeto cada 2 segundos si hay menos de 10 activos
        if (timer >= spawnInterval && activeObjects.Count < maxObjects)
        {
            GenerateObject();
            timer = 0f;
        }

        // Actualizar la lista eliminando objetos destruidos
        activeObjects.RemoveAll(obj => obj == null);


    }

    void GenerateObject()
    {
        GameObject newObject = Instantiate(fruitPrefab, GenerateSpawnPosition(), Quaternion.identity);
        activeObjects.Add(newObject);
        UpdateObjectCounter();
    }

    void UpdateObjectCounter()
    {
        if (objectCounterText != null)
        {
            objectCounterText.text = $"Apples: {activeObjects.Count}";
        }
    }




    Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 1, spawnPosZ);
        return randomPos;

    }
}
