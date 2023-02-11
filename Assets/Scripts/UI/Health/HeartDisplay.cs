using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public class HeartDisplay : MonoBehaviour
{
    [SerializeField] private Airplane _airplane;
    [SerializeField] private Image _heartImage;
    [SerializeField] private Transform _spawnPoint;

    private List<Image> _images = new List<Image>();
    public Vector3 spawnPosition;

    private void Start()
    {
        spawnPosition = _spawnPoint.position;

        for (int i = 0; i < _airplane.HealthValue; i++)
        {   
            Image image = Instantiate(_heartImage, spawnPosition, Quaternion.identity, transform);
            spawnPosition.x += 100;
            _images.Add(image);
        }
    }
    private void Update()
    {
        if (_airplane.HealthValue <= 0)
        {
            StopGame();
        }
    }

    private void StopGame()
    {
        Debug.Log("Game Over");
        Time.timeScale = 0;
    }

    private void OnEnable() => _airplane.HealthChanged += OnHealthChanged;
    private void OnDisable() => _airplane.HealthChanged -= OnHealthChanged;

    private void OnHealthChanged()
    {
        
        if(_airplane.HealthValue < _images.Count)
        {
            var deletedHeart = _images[_images.Count - 1];
            _images.Remove(deletedHeart);
            deletedHeart.gameObject.SetActive(false);
        }
        else if(_airplane.HealthValue > _images.Count)
        {
            Image image = Instantiate(_heartImage, spawnPosition, Quaternion.identity, transform);
            spawnPosition.x += 100;
            _images.Add(image);
         }
    }
}
