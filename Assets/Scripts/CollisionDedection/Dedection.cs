using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dedection : MonoBehaviour
{
    public float sceneRestartSecond = 1;

    public AudioClip[] audios;
    public AudioSource source;
    public GameObject gfx;
    public float timescale = 1;
    public bool openCover = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (openCover)
        {
            timescale = System.Math.Clamp(timescale - Time.deltaTime, 0.01f, 1);
            Time.timeScale = System.Math.Clamp(timescale, 0, 1);
        }
        if (timescale <= 0.05)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            //GetComponent<MeshFilter>().mesh = null;
            gfx.SetActive(false);
            
            gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            source.PlayOneShot(audios[Random.Range(0, audios.Length)]);
            openCover = true;

            //StartCoroutine(timar());
        }
    }


    IEnumerator timar()
    {
        yield return new WaitForSeconds(sceneRestartSecond);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
