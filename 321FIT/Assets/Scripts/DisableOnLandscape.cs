using UnityEngine;

public class DisableOnLandscape : MonoBehaviour
{
    [Header("Targets to Enable/Disable")]
    [SerializeField] private GameObject[] targets = new GameObject[0];
    [SerializeField] private MonoBehaviour[] targetBehaviours = new MonoBehaviour[0];

    [Header("Settings")]
    [SerializeField] private float aspectThreshold = 0.75f; // 3:4 = 0.75

    private void Awake()
    {
        // Force correct state IMMEDIATELY on launch — this fixes "starts in landscape" bug
        EnforceCorrectState();
    }

    private void OnEnable()
    {
        // Also re-apply when the object is re-enabled (e.g. scene reload)
        EnforceCorrectState();
    }

    private void Update()
    {
        EnforceCorrectState();
    }

    private void LateUpdate()
    {
        // Catches anything that re-enables it during the same frame
        EnforceCorrectState();
    }

    // This method now runs EVERY frame and ALWAYS enforces the rule
    private void EnforceCorrectState()
    {
        float currentAspect = (float)Screen.width / Screen.height;
        bool isPortraitMode = currentAspect < aspectThreshold;
        bool shouldBeActive = isPortraitMode;

        // FORCE the state — no early exit, no mercy
        foreach (var go in targets)
        {
            if (go != null && go.activeSelf != shouldBeActive)
            {
                go.SetActive(shouldBeActive);
            }
        }

        foreach (var behaviour in targetBehaviours)
        {
            if (behaviour != null && behaviour.enabled != shouldBeActive)
            {
                behaviour.enabled = shouldBeActive;
            }
        }
    }

    // Optional public trigger
    public void ForceRefresh() => EnforceCorrectState();
}