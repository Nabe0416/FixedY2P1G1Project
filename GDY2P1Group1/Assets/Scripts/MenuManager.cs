using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMenu()
    {
        Time.timeScale = 0;
        menu.SetActive(true);
    }

    public void WisUp()
    {
        FindObjectOfType<CharacterMovement>().ChangeWtoUp();
    }

    public void WisFor()
    {
        FindObjectOfType<CharacterMovement>().ChangeWtoFor();
    }

    public void Back()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        
    }
}
