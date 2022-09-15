using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    [SerializeField] private float speed;

    void Update()
    {
        if (!GetComponent<Dedection>().openCover)
        {

        }

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        gameObject.transform.position = new Vector3(x * 4, y * 4, transform.position.z);
    }
}
