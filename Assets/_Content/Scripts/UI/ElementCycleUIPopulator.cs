using UnityEngine;
using UnityEngine.UI;

public class ElementCycleUIPopulator : MonoBehaviour
{
    [SerializeField] private Sprite elementIcon;
    [SerializeField] private Sprite highlightedElementIcon;
    [SerializeField] private Button[] arrowButtons;
    [SerializeField] private Image[] iconImages;

    private void Awake()
    {
        Populate();
    }

    private void Populate()
    {
        PopulateImages();
        PopulateArrowButtons();
    }

    private void PopulateImages()
    {
        foreach (var image in iconImages)
        {
            image.sprite = elementIcon;
        }
    }

    private void PopulateArrowButtons()
    {
        foreach (var button in arrowButtons)
        {
            var spriteState = new SpriteState();
            spriteState.highlightedSprite = highlightedElementIcon;
            spriteState.pressedSprite = highlightedElementIcon;
            spriteState.selectedSprite = elementIcon;
            spriteState.disabledSprite = elementIcon;
            button.spriteState = spriteState;
        }
    }
}
