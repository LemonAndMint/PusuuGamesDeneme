using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public static ObstacleSpawner Instance;
    [SerializeField] private float spawnDelay;
    [SerializeField] private Transform obsPrefab;
    [SerializeField] private Vector3 baseSpawnPos;
    [SerializeField] private float spawnDistance;
    [SerializeField] private Transform player;
    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartSpawn();
    }

    private void SpawnObstacle()
    {
        Vector3 spawnPos = new Vector3(baseSpawnPos.x, baseSpawnPos.y, baseSpawnPos.z+spawnDistance+player.transform.position.z);
        Transform obstacleHolder = Instantiate(obsPrefab.transform, spawnPos,Quaternion.identity);
        int random = Random.Range(1, 10);
        Debug.Log(random);
        obstacleHolder.Find(random.ToString()).gameObject.SetActive(false);
    }

    public void StartSpawn()
    {
        InvokeRepeating("SpawnObstacle", spawnDelay, spawnDelay);
    }

    public void StopSpawn()
    {
        CancelInvoke("SpawnObstacle");
    }
}