using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float deactiveTimeDelay;
    private void Start()
    {
        Invoke("Deactive", 5f);
    }

    void Deactive()
    {
        Destroy(gameObject);
    }
}