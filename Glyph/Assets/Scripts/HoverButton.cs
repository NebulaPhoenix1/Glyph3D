using UnityEngine;
using UnityEngine.UI;

public class HoverButton : MonoBehaviour
{
    public Button myButton;  // Reference to the button
    public Sprite hoverSprite;  // Sprite to show when hovering
    public Sprite defaultSprite;  // Original sprite of the object

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Get the SpriteRenderer component of the object
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Set up the button's hover event listeners
        myButton.onClick.AddListener(OnClick); // If you want the button to do something when clicked (optional)

        // Start with the default sprite
        spriteRenderer.sprite = defaultSprite;
    }

    // This function will be called when the mouse hovers over the button
    public void OnHoverEnter()
    {
        spriteRenderer.sprite = hoverSprite;  // Change to the hover sprite
    }

    // This function will be called when the mouse exits the hover state
    public void OnHoverExit()
    {
        spriteRenderer.sprite = defaultSprite;  // Revert back to the default sprite
    }

    // Optional: OnClick event for the button (if you want it to trigger something)
    private void OnClick()
    {
        Debug.Log("Button clicked!");
    }
}
