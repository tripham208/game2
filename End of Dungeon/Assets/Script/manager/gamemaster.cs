using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gamemaster : MonoBehaviour
{
    // Start is called before the first frame update
    public int points = 0;
    public int highscore = 0;

    public Text pointtext;
    public Text Hightext;
    public Text Inputtext;

    // Use this for initialization
    void Start()
    {
        Hightext.text = ("HighScore: " + PlayerPrefs.GetInt("highscore"));
        highscore = PlayerPrefs.GetInt("highscore", 0);

        if (PlayerPrefs.HasKey("points"))
        {
            Scene ActiveScreen = SceneManager.GetActiveScene();
            if (ActiveScreen.buildIndex == 1)//màn hiện tại =0
            {
                PlayerPrefs.DeleteKey("points");
                points = 0;
            }
            else
                points = PlayerPrefs.GetInt("points");//điểm màn trc
        }
    }

    // Update is called once per frame
    void Update()
    {
        pointtext.text = ("Points: " + points);
    }


}
