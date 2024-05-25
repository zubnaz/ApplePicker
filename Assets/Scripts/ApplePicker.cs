using UnityEngine;
using Assets.Scripts;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;
    public RawImage gameOver;
    public Text gameOverText;
    public Text scoreGT;
    public Text highScore;
    public int hightSc;
    //public static int userScore = 0;
    public int counter = 0;
    public Text yourLevel;
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();

        GameObject scoreHigh = GameObject.Find("HighScore");
        highScore = scoreHigh.GetComponent<Text>();

        GameObject level = GameObject.Find("Level");
        yourLevel = level.GetComponent<Text>();
        yourLevel.text += GameStatistick.level.ToString();

        if (GameStatistick.score != 0)
        {
            hightSc = GameStatistick.highScore;
            counter = GameStatistick.score;
            numBaskets = GameStatistick.sizeOfBasket;
        }
        else
        {
            switch (GameStatistick.level)
            {
                case 1:
                    GameStatistick.highScore = 25;
                    break;
                case 2:
                    GameStatistick.highScore = 50;
                    break;
                case 3:
                    GameStatistick.highScore = 100;
                    break;
            }
            
        }
        
        highScore.text += GameStatistick.highScore;

        scoreGT.text += $" {counter.ToString()}";
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBaskeGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY+(basketSpacingY*i);
            tBaskeGO.transform.position = pos;
            basketList.Add(tBaskeGO);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            GameStatistick.score = counter;
            GameStatistick.sizeOfBasket = basketList.Count;
            SceneManager.LoadScene("PauseScene");
        }
    }
    public void AppleDestroyed()
    {
        GameObject[] list = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject go in list)
        {
            Destroy(go);
        }
        if (basketList.Count > 0)
        {
            int index = basketList.Count - 1;
            var item = basketList[index];
            basketList.RemoveAt(index);
            Destroy(item);
            if (basketList.Count == 0)
            {
                GameStatistick.level = 1;
                SceneManager.LoadScene("GameOverScene");
            }
            
        }
        
        
    }
}
