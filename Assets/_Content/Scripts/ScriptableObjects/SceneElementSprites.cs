using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSceneElementSprites", menuName = "Character Designer/Scene Element Sprites", order = 0)]
public class SceneElementSprites : ScriptableObject
{
    [SerializeField] protected Sprite[] sceneElementSprites;

    public int GetCount(int category) => 
        GetCategorySprites(category).Length;

    public Sprite GetSceneElementSprite(SceneElementFilter filter)
    {
        var categorySprites = GetCategorySprites(filter.category);
        return categorySprites[filter.index];
    }

    protected virtual Sprite[] GetCategorySprites(int category)
    {
        return sceneElementSprites
            .Where(sprite => sprite.name.GetSceneElementCategory() == category
                || category.WorksWithAnything())
            .ToArray();
    }
}