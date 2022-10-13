using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tweens : MonoBehaviour
{

    float currentTime;
    Vector3 initialPosition;
    [SerializeField] private float time;
    [SerializeField,Range(0,1)] private float Tparameter = 0;
    [SerializeField] private Transform targetTransform;
    Vector3 targetPosition;
    [SerializeField] private Color initialColor;
    [SerializeField] private Color finalColor;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        Tparameter = currentTime / time;
        transform.position = Vector3.Lerp(initialPosition, targetPosition, Tparameter);
        spriteRenderer.color = Color.Lerp(initialColor, finalColor, Tparameter);
        currentTime += Time.deltaTime;

        if(Input.GetKeyDown(KeyCode.Space))
        {
            StartTween();   
        }
    }

    private void StartTween() //reiniciar el contador
    {
        Tparameter = 0;
        currentTime = 0;
        initialPosition = transform.position;
        targetPosition = targetTransform.position;

    }
}
