using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dedection : MonoBehaviour
{
    public string scenename;
    public float scenerestartsecond = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            GetComponent<MeshFilter>().mesh = null;
            gameObject.transform.GetChild(0).GetComponent<ParticleSystem>().Play();
            StartCoroutine(timar());
        }
    }


    IEnumerator timar()
    {
        yield return new WaitForSeconds(scenerestartsecond);
        SceneManager.LoadScene(scenename);
    }
}
