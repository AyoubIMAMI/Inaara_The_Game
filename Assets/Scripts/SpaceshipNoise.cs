using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceshipNoise : MonoBehaviour
{
    [SerializeField] private float xPositionRange = 1;
    [SerializeField] private float yPositionRange = 2f;

    [SerializeField] private float minPositionSpeed = .5f;
    [SerializeField] private float maxPositionSpeed = .8f;
    
    private Vector3 initialPosition;

    private float positionSpeed;
    
    private Vector3 positionObjective;


    private void Start()
    {
        Transform t = transform;
        initialPosition = t.position;
        GenerateNewPositionObjective();
    }
    
    private void Update()
    {
        if(Vector3.Distance(transform.position, positionObjective) <= .1f) GenerateNewPositionObjective();
        MoveToObjective();
    }

    private void GenerateNewPositionObjective()
    {
        positionObjective = new Vector3(
            initialPosition.x - xPositionRange + Random.Range(0f, 2 * xPositionRange),
            initialPosition.y - yPositionRange + Random.Range(0f, 2 * yPositionRange),
            initialPosition.z
        );

        positionSpeed = Random.Range(minPositionSpeed, maxPositionSpeed);
    }

    private void MoveToObjective()
    {
        Vector3 posDelta = positionObjective - transform.position;
        transform.position +=  positionSpeed * Time.deltaTime * posDelta.normalized;
    }
}
