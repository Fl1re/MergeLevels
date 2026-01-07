using Cysharp.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnerTimerButton : MonoBehaviour
{
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private Button startTimerButton;

    [SerializeField] private float cooldown;

    private void Awake()
    {
        if (startTimerButton)
        {
            startTimerButton.onClick.AddListener(StartTimer);
        }
    }

    private async void StartTimer()
    {
        startTimerButton.interactable = false;
        timerText.gameObject.SetActive(true);
        float remaining = cooldown;

        while (remaining > 0)
        {
            timerText.text = Mathf.CeilToInt(remaining).ToString();
            await UniTask.Delay(1000);
            remaining -= 1f;
        }

        var field = Services.Get<IFieldService>().GetField();
        if (!field.TryGetFreeCell(out var cell)) return;

        var registry = Services.Get<IConfigRegistry>();
        var config = registry.GetSpawnerConfig(1);

        var factory = Services.Get<IEntityFactory>();
        var spawner = factory.CreateSpawner(config);

        cell.SetEntity(spawner);
        
        startTimerButton.interactable = true;
        timerText.gameObject.SetActive(false);
    }
}
