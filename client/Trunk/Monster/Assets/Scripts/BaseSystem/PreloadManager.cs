using UnityEngine;

public class PreloadManager : MonoBehaviour
{
    private Transform _uiRoot;

    void Start()
    {
        _uiRoot = GameObject.Find("Canvas").transform;

        GameObject preloadView = Instantiate(Resources.Load<GameObject>("Prefab/UI/Preload/PreloadPanel"), _uiRoot) as GameObject;
        preloadView.transform.localScale = Vector3.one;
        (preloadView.transform as RectTransform).sizeDelta = Vector2.zero;
        (preloadView.transform as RectTransform).localPosition = Vector2.zero;

#if UNITY_EDITOR
        GameObject loginView = Instantiate(Resources.Load<GameObject>("Prefab/UI/Login/LoginView"), _uiRoot) as GameObject;
        loginView.transform.localScale = Vector3.one;
        (loginView.transform as RectTransform).sizeDelta = Vector2.zero;
        (loginView.transform as RectTransform).localPosition = Vector2.zero;

#endif

    }
}
