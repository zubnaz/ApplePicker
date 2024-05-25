using Assets.Scripts;
using UnityEngine;


public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject applePrefab;
    public float speed;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirections = 0.02f;
    public float secondsBetweenAppleDrops;
    public bool stop = false;
    // Start is called before the first frame update
    void Start()
    {      
        switch (GameStatistick.level)
        {
            case 1:
                secondsBetweenAppleDrops = 1f;
                speed = 10f;
                break;
            case 2:
                secondsBetweenAppleDrops = 0.5f;
                speed = 25f;
                break;
            case 3:
                secondsBetweenAppleDrops = 0.3f;
                speed = 50f;
                break;
        }
        Invoke(nameof(DropApple),2f);
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;
        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if(pos.x > leftAndRightEdge) 
        {
            speed = -Mathf.Abs(speed);
        }
    }
    void DropApple()
    {
        GameObject apple = Instantiate<GameObject>(applePrefab);
        apple.transform.position=this.transform.position;
        if(!stop) { Invoke(nameof(DropApple), secondsBetweenAppleDrops); }
        
       
       
    }
    private void FixedUpdate()
    {
        if (Random.value<chanceToChangeDirections) {
            speed *= -1;
        }
    }
}
