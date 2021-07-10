using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Finish : MonoBehaviour
{
    public GameObject pistol;
    public GameObject pistol1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "finishtag")
        {
            gameObject.GetComponent<characterMoveControl>().enabled = false;
            gameObject.GetComponent<FireControl>().enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("danceprm");
            pistol.SetActive(false);
            pistol1.SetActive(false);


            StartCoroutine(ReturnLevelTime());
        }
    }
    IEnumerator ReturnLevelTime()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("level1");

    }
}

