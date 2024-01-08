using UnityEngine;

[CreateAssetMenu(fileName = "NewSceneElementSprites", menuName = "Character Designer/Background Scene Element Sprites", order = 1)]
public class BackgroundSceneElementSprites : SceneElementSprites
{
    protected override Sprite[] GetCategorySprites(int category)
    {
        return sceneElementSprites;
    }
}
