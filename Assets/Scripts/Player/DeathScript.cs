using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{
    UnityEvent OnDeath;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Enemy"))
        {
            OnDeath?.Invoke();
            Death();
        }
    }

    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
