using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    public bool pause = false;

    public GameObject pauseUI;

    // Use this for initialization
    private void Start()
    {
        pauseUI.SetActive(false);//ẩn hiện
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            pause = !pause;
        }

        if (pause)
        {
            pauseUI.SetActive(true);
            Time.timeScale = 0;//dừng
        }

        if (pause == false)
        {
            pauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Resume()
    {
        pause = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        Application.Quit();
    }
}