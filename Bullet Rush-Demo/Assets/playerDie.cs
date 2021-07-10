using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDie : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<characterMoveControl>().enabled = false;
            other.gameObject.GetComponent<FireControl>().enabled = false;
            other.gameObject.GetComponent<Animator>().SetTrigger("dieprm");
            StartCoroutine(ReturnLevelTime());
        }
    }

    IEnumerator ReturnLevelTime()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("level1");

    }
}
