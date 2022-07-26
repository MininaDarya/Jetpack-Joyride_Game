using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{
    public Sprite laserOnSprite;
    public Sprite laserOffSprite;
    public float toggleInterval = 0.5f;
    public float rotationSpeed = 0.0f;
    private bool isLaserOn = true;
    private float timeUntilNextToggle;
    private Collider2D laserCollider;
    private SpriteRenderer laserRenderer;

    void Start()
    {
        timeUntilNextToggle = toggleInterval;
        laserCollider = gameObject.GetComponent<Collider2D>();
        laserRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        timeUntilNextToggle -= Time.deltaTime;

        if (timeUntilNextToggle <= 0)
        {
            isLaserOn = !isLaserOn;
            laserCollider.enabled = isLaserOn;

            if (isLaserOn)
            {
                laserRenderer.sprite = laserOnSprite;
            }
            else
            {
                laserRenderer.sprite = laserOffSprite;
            }

            timeUntilNextToggle = toggleInterval;
        }
        transform.RotateAround(transform.position, Vector3.forward, rotationSpeed * Time.deltaTime);
    }
}
