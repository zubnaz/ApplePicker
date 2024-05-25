using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Basket : MonoBehaviour
{
    [Header("Set Dynamically")]
    public Text scoreGT;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject scoreGO = GameObject.Find("ScoreCounter");
        scoreGT = scoreGO.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos2D = Input.mousePosition;
        mousePos2D.z=-Camera.main.transform.position.z;

        Vector3 mousePos3D = Camera.main.ScreenToWorldPoint(mousePos2D);
        Vector3 pos = this.transform.position;
        pos.x = mousePos3D.x;
        this.transform.position = pos;
    }
    private void OnCollisionEnter(Collision collision)
    {
        GameObject collidedWith = collision.gameObject;
        ApplePicker ap = Camera.main.GetComponent<ApplePicker>();
        if (collidedWith.tag == "Apple")
        {
            Destroy(collidedWith);
            ap.counter += 1;         
            scoreGT.text = $"Your score : {ap.counter.ToString()}";
            if (ap.counter == GameStatistick.highScore)
            {
                if (GameStatistick.level == 3)
                {
                    GameStatistick.level = 1;
                    SceneManager.LoadScene("WinScene");
                }
                else
                {
                    GameStatistick.level += 1;
                    GameStatistick.score = 0;
                    SceneManager.LoadScene("_Scene_0");
                }
            }
        }
    }
}
