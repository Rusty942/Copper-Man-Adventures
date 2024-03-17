using UnityEngine;

public class BodyFlip : MonoBehaviour
{
    // Reference to the body's transform
    private Transform bodyTransform;

    // Start is called before the first frame update
    void Start()
    {
        // Get the body's transform
        bodyTransform = transform;
    }

    // Update is called once per frame
    void Update()
    {
        // Get the position of the cursor relative to the screen width
        float cursorXPosition = Input.mousePosition.x / Screen.width;

        // Determine if the cursor is on the left or right half of the screen
        bool isCursorOnLeft = cursorXPosition < 0.5f;

        // Flip the body's scale along the x-axis based on cursor position
        if (isCursorOnLeft && bodyTransform.localScale.x > 0)
        {
            bodyTransform.localScale = new Vector3(-1 * Mathf.Abs(bodyTransform.localScale.x), bodyTransform.localScale.y, bodyTransform.localScale.z);
        }
        else if (!isCursorOnLeft && bodyTransform.localScale.x < 0)
        {
            bodyTransform.localScale = new Vector3(Mathf.Abs(bodyTransform.localScale.x), bodyTransform.localScale.y, bodyTransform.localScale.z);
        }
    }
}
