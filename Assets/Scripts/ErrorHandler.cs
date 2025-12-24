using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class ErrorHandler : MonoBehaviour
{
    public static ErrorHandler Instance;

    public Action<string> OnWarningDisplayed;
    public Action<string, string> OnErrorDisplayed;

    [SerializeField] private TextMeshProUGUI _errorText;
    [SerializeField] private Button _errorButton;

    private bool _isDisplaying = false;
    private GameObject _errorGameObject;
    private WaitForSeconds _waitTimeMessage = new WaitForSeconds(.2f);
    private WaitForSeconds _waitTimer = new WaitForSeconds(2f);
    private Queue<string> _messageQueue = new Queue<string>();
    
    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        _errorGameObject = _errorText.gameObject.transform.parent.gameObject;
        _errorGameObject.SetActive(false);
        _errorButton.gameObject.SetActive(false);

        OnWarningDisplayed += ShowWarning;
        OnErrorDisplayed += ShowError;
    }

    private void ShowWarning(string message)
    {
        _messageQueue.Enqueue(message);
        if (!_isDisplaying)
            StartCoroutine(ProcessQueue());
    }

    private void ShowError(string message, string buttonText = "OK")
    {
        _errorButton.gameObject.SetActive(true);
        _errorButton.GetComponentInChildren<TextMeshProUGUI>().text = buttonText;
        _messageQueue.Enqueue(message);
        if (!_isDisplaying)
            StartCoroutine(ProcessQueue());
    }

    private IEnumerator ProcessQueue()
    {
        _isDisplaying = true;
        while (_messageQueue.Count > 0)
        {
            string msg = _messageQueue.Dequeue();
            _errorGameObject.SetActive(true);
            _errorText.text = msg;

            yield return _waitTimer;

            _errorText.text = string.Empty;
            _errorGameObject.SetActive(false);

            yield return _waitTimeMessage;
        }
        _isDisplaying = false;
    }
}
