using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Airplane : MonoBehaviour
{
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private int _healthValue;


    private int _scoreValue;

    public int HealthValue => _healthValue;

    public event UnityAction HealthChanged;


    private void Start()
    {
        _healthText.text = _healthValue.ToString();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Coin coin))
        {

            _scoreValue++;
            _scoreText.text = _scoreValue.ToString();
            Destroy(coin.gameObject);
        }
        else if (other.TryGetComponent(out Bomb bomb))
        {
            _healthValue--;
            _healthText.text = _healthValue.ToString();
            HealthChanged?.Invoke();
            Destroy(other.gameObject);
        }
        else if(other.TryGetComponent(out HeartCoin heartCoin))
        {
            _healthValue++;
            _healthText.text = _healthValue.ToString();
            HealthChanged?.Invoke();
            Destroy(other.gameObject);
        }
    }
}
