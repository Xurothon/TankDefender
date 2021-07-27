using UnityEngine;
using UnityEngine.EventSystems;

public class UIPanelHelper : MonoBehaviour
{
    [SerializeField] private EventTrigger eventTrigger;
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _spawner;

    private void ActiveGamePanelFromMainPanel(PointerEventData data)
    {
        _menuPanel.SetActive(false);
        _gamePanel.SetActive(true);
        _spawner.SetActive(true);
    }

    private void Awake()
    {
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        entry.callback.AddListener((data) => ActiveGamePanelFromMainPanel((PointerEventData)data));
        eventTrigger.triggers.Add(entry);
    }
}