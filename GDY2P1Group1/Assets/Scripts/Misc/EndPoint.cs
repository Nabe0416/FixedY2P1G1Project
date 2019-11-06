using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            GameRestart();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<CharacterMovement>())
        {
            GameEnd();
        }
    }

    [ContextMenu("EndGame")]
    void GameEnd()
    {
        print("Game End.");
        SceneManager.LoadScene(0);
    }

    void GameRestart()
    {
        GameEnd();
    }
}
