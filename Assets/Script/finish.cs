using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            panel.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("player");
            
        }
    }
}
