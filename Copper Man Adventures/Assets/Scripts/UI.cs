using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UI : MonoBehaviour
{
    public Sprite normalSprite1;
    public Sprite hoverSprite1;
    public Sprite normalSprite2;
    public Sprite hoverSprite2;

    // Reference to the buttons
    public Button button1;
    public Button button2;

    //Controls images
    public Image image1;
    public Image image2;
    public float fadeDuration = 1f;
    public float displayDuration = 5f;

    IEnumerator Start()
    {
        // Add event listeners for button 1
        AddButtonEvents(button1, normalSprite1, hoverSprite1);

        // Add event listeners for button 2
        AddButtonEvents(button2, normalSprite2, hoverSprite2);

        // Fade in both instructions
        yield return StartCoroutine(FadeImage(image1, true));
        yield return StartCoroutine(FadeImage(image2, true));

        // Wait for the display duration
        yield return new WaitForSeconds(displayDuration);

        // Fade out both images
        yield return StartCoroutine(FadeImage(image1, false));
        yield return StartCoroutine(FadeImage(image2, false));


    }

    void AddButtonEvents(Button button, Sprite normalSprite, Sprite hoverSprite)
    {
        if (button != null)
        {
            // Add event trigger component if not already added
            if (button.GetComponent<EventTrigger>() == null)
                button.gameObject.AddComponent<EventTrigger>();

            // Add PointerEnter event
            EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
            pointerEnter.eventID = EventTriggerType.PointerEnter;
            pointerEnter.callback.AddListener((eventData) => { OnPointerEnter((PointerEventData)eventData, button, hoverSprite); });
            button.GetComponent<EventTrigger>().triggers.Add(pointerEnter);

            // Add PointerExit event
            EventTrigger.Entry pointerExit = new EventTrigger.Entry();
            pointerExit.eventID = EventTriggerType.PointerExit;
            pointerExit.callback.AddListener((eventData) => { OnPointerExit((PointerEventData)eventData, button, normalSprite); });
            button.GetComponent<EventTrigger>().triggers.Add(pointerExit);
        }
    }

    void OnPointerEnter(PointerEventData eventData, Button button, Sprite hoverSprite)
    {
        // Change button sprite to hoverSprite when pointer enters
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
            buttonImage.sprite = hoverSprite;
    }

    void OnPointerExit(PointerEventData eventData, Button button, Sprite normalSprite)
    {
        // Change button sprite back to normalSprite when pointer exits
        Image buttonImage = button.GetComponent<Image>();
        if (buttonImage != null)
            buttonImage.sprite = normalSprite;
    }

    IEnumerator FadeImage(Image image, bool fadeIn)
    {
        float targetAlpha = fadeIn ? 1 : 0;
        float startAlpha = image.color.a;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, timer / fadeDuration);
            image.color = new Color(image.color.r, image.color.g, image.color.b, newAlpha);
            timer += Time.deltaTime;
            yield return null;
        }

        image.color = new Color(image.color.r, image.color.g, image.color.b, targetAlpha); // Ensure alpha reaches exactly 0 or 1
    }
}
