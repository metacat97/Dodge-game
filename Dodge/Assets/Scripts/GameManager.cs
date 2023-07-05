using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public GameObject gameOverUi = default;
    public Text timedText = default;
    public Text recordText = default;

    private float surviveTime = default;
    private bool isGameOver = default;

    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0f;
            isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
        {
            surviveTime += Time.deltaTime;
            timedText.text = string.Format("Time : {0}", (int)surviveTime);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("PlayScene");
        }


    }

    public void EndGame()
    {
        isGameOver = true;
        gameOverUi.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestTime");

        if(bestTime < surviveTime)
        {
            bestTime = surviveTime;
            PlayerPrefs.SetFloat("BestTime", bestTime);

        }
        recordText.text = string.Format("Best Time : {0}", (int)bestTime);//+연산자로 묶는 것은 연산량이 높아서 안됨
    }

}
