using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private MemoryCard originalCard;
    [SerializeField] private Transform Parent;
    [SerializeField] private AudioSource yeah;
    [SerializeField] private Text scorelabel;

    [SerializeField] private Sprite[] images;
    
    private MemoryCard _firstReveal;
    private MemoryCard _secondReveal;
    private int _score = 0;
    public int[] numbers;

    private void Start()
    {
        
        

        Difficulty(30);
        Shuffle(numbers);

        for (int i = 0; i < 30; i++)
        {
            MemoryCard card;
            if (i == 0)
            {
                card = originalCard;
            }
            else
            {
                card = Instantiate(originalCard, Parent);
            }
            
            card.SetCard(numbers[i], images[numbers[i]]);
        }
        
    }

    
    public void Difficulty(int difficult)
    {

        numbers = new int[difficult];
        int x = 0;
        for (int i = 0; i < (difficult / 2); i++)
        {
            
            if (i <= images.Length - 1)
            {
                numbers[i] = i;
            }
            else
            {
                numbers[i] = x;
                x++;
                if (x > images.Length - 1)
                {
                    x = 0;
                }
            }
        }

        Array.Copy(numbers, 0, numbers, difficult / 2, difficult / 2);
    }

    public static void Shuffle<T>(T[] array)
    {
        System.Random rand = new System.Random();
        for (int i = array.Length - 1; i >= 1; i--)
        {
            int j = rand.Next(i + 1);
            T tmp = array[j];
            array[j] = array[i];
            array[i] = tmp;
        }
    }

    public bool CanReveal()
    {
        if (_secondReveal == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void CheckReveal(MemoryCard card)
    {
        if (_firstReveal == null)
        {
            _firstReveal = card;
        }
        else
        {
            _secondReveal = card;
            StartCoroutine(CheckMath());
        }
    }
    private  IEnumerator CheckMath()
    {
            if (_firstReveal.id == _secondReveal.id)
            {
                _score++;
                 scorelabel.text = "Score : " + _score;
                Debug.Log("СОВПАДЕНИЕ! Текущий счет: " + _score);
                yeah.Play();
            }
            else
            {
            yield return new WaitForSeconds(0.5f);
                _firstReveal.UnReveal();
                _secondReveal.UnReveal();

            }
            _firstReveal = null;
            _secondReveal = null;
        
    }
}
