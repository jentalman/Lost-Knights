using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryCard : MonoBehaviour
{
    [SerializeField] private GameObject cardBack;
    [SerializeField] private SceneController controller;
    [SerializeField] private AudioSource flipCard;

    private int _id;
    public int id
    {
        get { return _id; }
    }
   
    public void SetCard(int id, Sprite image)
    {
        _id = id;
        GetComponent<SpriteRenderer>().sprite = image;
    }
    public void OnMouseDown()
    {
        
        if (cardBack.activeSelf && controller.CanReveal())
        {
            flipCard.Play();
            cardBack.SetActive(false);
            controller.CheckReveal(this);
        }
    }

    public void UnReveal()
    {
        cardBack.SetActive(true);
    }
}
