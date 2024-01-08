using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SceneElement : MonoBehaviour
{
    protected Image image;
    [SerializeField] protected SceneElementSprites sprites;
    
    private int _selectedSpriteIndex = 0;
    private int _selectedSpriteCategory = 0;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    public void SetElementCategory(int category)
    {
        _selectedSpriteIndex = 0;
        _selectedSpriteCategory = category;
        UpdateSceneElement();
    }

    public void SetNextElement()
    {
        _selectedSpriteIndex++;
        int maxIndex = sprites.GetCount(_selectedSpriteCategory) - 1;
        _selectedSpriteIndex = Mathf.Min(maxIndex, _selectedSpriteIndex);
        UpdateSceneElement();
    }
    public void SetPreviousElement()
    {
        _selectedSpriteIndex--;
        _selectedSpriteIndex = Mathf.Max(0, _selectedSpriteIndex);
        UpdateSceneElement();
    }

    protected virtual void UpdateSceneElement()
    {
        image.sprite = sprites.GetSceneElementSprite(
            new SceneElementFilter(_selectedSpriteIndex, _selectedSpriteCategory));
    }
}