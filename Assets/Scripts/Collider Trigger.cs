using UnityEngine;

public class ColliderTrigger : MonoBehaviour
{
    public Canvas screenUI;
    public float fadeSpeed = 1;

    private float _desiredAlpha;
    private float _currentAlpha;

    void Update()
    {
        _currentAlpha = Mathf.MoveTowards(_currentAlpha, _desiredAlpha, fadeSpeed * Time.deltaTime);
        screenUI.GetComponent<CanvasGroup>().alpha = _currentAlpha;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _desiredAlpha = 1f;
            Debug.Log("Player Entered");
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            _desiredAlpha = 0f;
            Debug.Log("Player Exited");
        }
    }
}