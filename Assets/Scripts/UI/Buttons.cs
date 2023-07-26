using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    [SerializeField] GameObject optionsMenu;
    [SerializeField] GameObject mainMenu;
    [SerializeField] AudioSource awakeStatic;
    [SerializeField] Camera cam;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void playButton()
    {
        SceneManager.LoadScene("Game");
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void optionsButton()
    {
        cam.transform.position = new Vector3(-0.55f, 2.207f, -2.846f);
        cam.transform.rotation = Quaternion.Euler(9.194f, 189.692f, 1.545f);
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
        awakeStatic.Play();
        Debug.Log("Options");
    }
    public void quitButton()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

}
