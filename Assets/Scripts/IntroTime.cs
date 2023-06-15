using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class IntroTime : MonoBehaviour
{
    public float timeRemaining = 18;

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
        if(Input.GetKeyUp(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
