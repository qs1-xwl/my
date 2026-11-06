using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int totalCoins = 0;
    public AudioClip coinSound;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            totalCoins++;
            if (UIManager.Instance != null) { UIManager.Instance.UpdateCoinUI(totalCoins); }
            Debug.Log("吃到金币，分数+1！");

            if (coinSound != null)
            {
                AudioSource.PlayClipAtPoint(coinSound, Camera.main.transform.position);
            }
            Destroy(gameObject);
        }
    }
        
}
