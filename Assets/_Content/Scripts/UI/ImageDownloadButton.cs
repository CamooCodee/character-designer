using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ImageDownloadButton : MonoBehaviour
{
    private Button _button;

    private void Awake() => _button = GetComponent<Button>();

    private void OnEnable() => _button.onClick.AddListener(CaptureAndDownload);
    private void OnDisable() => _button.onClick.RemoveListener(CaptureAndDownload);

    private void CaptureAndDownload()
    {
        ImageDownloader.DownloadFrame();
    }
}
