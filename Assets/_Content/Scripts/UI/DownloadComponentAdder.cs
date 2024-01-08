using UnityEngine;

public class DownloadComponentAdder : MonoBehaviour
    // For some reason the ImageDownloadButton itself gets lost when building to WebGL
{
    private void Awake() => gameObject.AddComponent<ImageDownloadButton>();
}
