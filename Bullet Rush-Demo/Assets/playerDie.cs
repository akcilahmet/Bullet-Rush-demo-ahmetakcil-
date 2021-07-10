using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerDie : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            gameObject.GetComponent<characterMoveControl>().enabled = false;
            gameObject.GetComponent<FireControl>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("dieprm");
            StartCoroutine(ReturnLevelTime());
        }
    }

    IEnumerator ReturnLevelTime()
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("level1");

    }
}
