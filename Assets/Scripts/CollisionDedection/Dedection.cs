using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dedection : MonoBehaviour
{
    public float sceneRestartSecond = 5;

    public AudioClip[] audios;
    public AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            GetComponent<MeshFilter>().mesh = null;
            gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            source.PlayOneShot(audios[Random.Range(0, audios.Length)]);
            StartCoroutine(timar());
        }
    }


    IEnumerator timar()
    {
        yield return new WaitForSeconds(sceneRestartSecond);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
