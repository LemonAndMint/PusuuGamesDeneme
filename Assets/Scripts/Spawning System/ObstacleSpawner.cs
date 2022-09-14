using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner Instance;
    [SerializeField] private float spawnDelay;
    [SerializeField] private float decreaseSpawnDelay;
    [SerializeField,Range(0,100)] private float decreaseSpawnDistancePercent;
    [SerializeField] private Transform obsPrefab;
    [SerializeField] private Vector3 baseSpawnPos;
    [SerializeField] private float spawnDistance;
    [SerializeField] private float minSpawnDistance;
    private float baseSpawnDistance;
    [SerializeField] private Transform player;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        baseSpawnDistance = spawnDistance;
        StartSpawn();   
    }

    private void DecreaseSpawnDistance()
    {
        float temp = spawnDistance - (baseSpawnDistance * decreaseSpawnDistancePercent / 100);
        if (temp < minSpawnDistance)
            spawnDistance = minSpawnDistance;
        else
            spawnDistance = temp;
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(baseSpawnPos.x, baseSpawnPos.y, baseSpawnPos.z+spawnDistance+player.transform.position.z);
        Transform obstacleHolder = Instantiate(obsPrefab.transform, spawnPos,Quaternion.identity);
        int random = Random.Range(1, 10);
        obstacleHolder.Find(random.ToString()).gameObject.SetActive(false);        
    }

    public void StartSpawn()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnDelay);
        InvokeRepeating("DecreaseSpawnDistance", decreaseSpawnDelay, decreaseSpawnDelay);
    }

    public void StopSpawn()
    {
        CancelInvoke("SpawnObstacle");
        CancelInvoke("DecreaseSpawnDistance");
    }
}