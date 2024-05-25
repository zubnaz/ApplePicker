using UnityEngine;
public class Apple : MonoBehaviour
{
    public static float appleFallingLimit = -15f;
    // Start is called before the first frame update
    void Start()
    {
        this.transform.SetAsLastSibling();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < appleFallingLimit)
        {
            Destroy(gameObject);
            ApplePicker ap = Camera.main.GetComponent<ApplePicker>();
            ap.AppleDestroyed();
        }
    }
}
