using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TunnelDeath2 : MonoBehaviour
{
    // Start is called before the first frame update




    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("TunnelDeath2");
        }

    }
}
