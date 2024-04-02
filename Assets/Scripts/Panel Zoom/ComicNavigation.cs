using UnityEngine;

public class ComicNavigation : MonoBehaviour
{
    public Sprite[] panels; // Array to store references to comic panels
    public Animator wordBubbleAnimator; // Reference to the Animator controlling word bubbles
    int currentPanelIndex = 0;

    void Start()
    {
        // Set the initial panel and play initial word bubble animation
        ShowPanel(currentPanelIndex);
        PlayWordBubbleAnimation("Appear"); // Adjust this name based on your animation
    }

    void Update()
    {
        // Check for arrow key input
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // Move to the next panel and play appropriate word bubble animation
            ShowNextPanel();
            PlayWordBubbleAnimation("Appear"); // Adjust this name based on your animation
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            // Move to the previous panel and play appropriate word bubble animation
            ShowPreviousPanel();
            PlayWordBubbleAnimation("Appear"); // Adjust this name based on your animation
        }
    }

    void ShowPanel(int index)
    {
        // Ensure index is within bounds
        if (index >= 0 && index < panels.Length)
        {
            // Set the sprite of the sprite renderer to the panel at the specified index
            GetComponent<SpriteRenderer>().sprite = panels[index];
            currentPanelIndex = index;
        }
    }

    void ShowNextPanel()
    {
        // Move to the next panel
        int nextIndex = currentPanelIndex + 1;
        if (nextIndex < panels.Length)
        {
            ShowPanel(nextIndex);
        }
    }

    void ShowPreviousPanel()
    {
        // Move to the previous panel
        int previousIndex = currentPanelIndex - 1;
        if (previousIndex >= 0)
        {
            ShowPanel(previousIndex);
        }
    }

    void PlayWordBubbleAnimation(string animationName)
    {
        if (wordBubbleAnimator != null)
        {
            wordBubbleAnimator.Play(animationName);
        }
    }
}
