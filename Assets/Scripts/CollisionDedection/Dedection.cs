using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dedection : MonoBehaviour
{
    public string scenename;
    public float scenerestartsecond = 5; 

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Barrier")
        {
            StartCoroutine(timar());
        }
    }


    IEnumerator timar()
    {
        yield return new WaitForSeconds(scenerestartsecond);
        SceneManager.LoadScene(scenename);
    }
}
