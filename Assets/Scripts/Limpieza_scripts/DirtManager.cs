using System.Collections.Generic;
using UnityEngine;

public class DirtManager : MonoBehaviour
{
    [System.Serializable]
    public class DirtPrefab
    {
        public GameObject prefab;  // Prefab del objeto
        public string dirtType;    // Tipo de suciedad (ejemplo: "hoja", "mancha")
    }

    public List<DirtPrefab> dirtPrefabs; // Lista de prefabs con sus tipos
    public int dirtCount = 20;           // Número total de objetos a generar

    private Vector2 screenBounds;

    private void Start()
    {
        CalculateScreenBounds();
        GenerateDirt();
    }

    private void CalculateScreenBounds()
    {
        Camera cam = Camera.main;
        float height = 2f * cam.orthographicSize;
        float width = height * cam.aspect;
        screenBounds = new Vector2(width / 2, height / 2);
    }

    private void GenerateDirt()
    {
        for (int i = 0; i < dirtCount; i++)
        {
            DirtPrefab selectedDirt = dirtPrefabs[Random.Range(0, dirtPrefabs.Count)];

            Vector3 position = new Vector3(
                Random.Range(-screenBounds.x, screenBounds.x),
                Random.Range(-screenBounds.y, screenBounds.y),
                0f
            );

            GameObject dirt = Instantiate(selectedDirt.prefab, position, Quaternion.identity);
            dirt.AddComponent<Dirt>().SetDirtType(selectedDirt.dirtType);
        }
    }
}
