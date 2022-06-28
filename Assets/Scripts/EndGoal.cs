using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGoal : MonoBehaviour
{
    public GameObject confetti;

    private void Start()
    {
        confetti.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 6)    // player layer
        {
            StartCoroutine(WaitForLevelChange());
            confetti.SetActive(true);
        }
    }

    IEnumerator WaitForLevelChange()
    {

        yield return new WaitForSeconds(2.0f);
        GameManager.Instance.NextLevel();
    }
}
