// Author - Ronnie Rawlings.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;

public class PetEggCrack : MonoBehaviour
{
    [SerializeField] private List<Sprite> petEggSprites = new List<Sprite>();
    [SerializeField] private float rotationAmount = 15f, rotationSpeed = 1f, rotationPause = 0.5f;

    private int currentSprite = 0;
    private Image imageToRotate;
    private Quaternion originalRotation;

    private void Awake()
    {
        if (StaticValues.loadedSave != null)
        {
            transform.name = StaticValues.loadedSave.petEggs[transform.GetSiblingIndex() - 1];

            if (!transform.name.Contains("Egg"))
            {
                StaticPetMethods.LoadPets(GetComponent<Image>(), transform.GetComponent<PetInfoChange>());
                currentSprite = 4;
            }
        }

        StaticPetInfo.petEggs[transform.GetSiblingIndex() - 1] = gameObject;
        Debug.Log(StaticPetInfo.petEggs[transform.GetSiblingIndex() - 1].name);
    }


    void Start()
    {
        imageToRotate = GetComponent<Image>();
        originalRotation = imageToRotate.transform.localRotation;
    }

    public void StartCrackEgg()
    {
        if (currentSprite <= petEggSprites.Count)
        {
            StartCoroutine(CrackEgg());
        }
    }

    private IEnumerator CrackEgg()
    {
        transform.GetComponent<Button>().interactable = false;

        float startTime = Time.time;
        while (Time.time - startTime < 2f)
        {
            Quaternion targetRotation = Quaternion.Euler(0f, 0f, rotationAmount);
            float elapsedTime = 0f;

            while (Quaternion.Angle(imageToRotate.transform.localRotation, targetRotation) > 0.1f)
            {
                imageToRotate.transform.localRotation = Quaternion.RotateTowards(imageToRotate.transform.localRotation,
                    targetRotation, rotationSpeed * Time.deltaTime);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(rotationPause);

            targetRotation = Quaternion.Euler(0f, 0f, -rotationAmount);
            elapsedTime = 0f;

            while (Quaternion.Angle(imageToRotate.transform.localRotation, targetRotation) > 0.1f)
            {
                imageToRotate.transform.localRotation = Quaternion.RotateTowards(imageToRotate.transform.localRotation,
                    targetRotation, rotationSpeed * Time.deltaTime);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            yield return new WaitForSeconds(rotationPause);
        }

        StartCoroutine(ChangeImage(0.5f));
    }

    public IEnumerator ChangeImage(float duration)
    {
        if (currentSprite != petEggSprites.Count)
        {
            imageToRotate.sprite = petEggSprites[currentSprite++];       
        }
        else
        {
            StaticPetMethods.DecideOnPet(transform.parent.parent.parent.GetChild(0), imageToRotate, transform.GetComponent<PetInfoChange>());
            currentSprite++;
        }

        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            imageToRotate.transform.localRotation = Quaternion.Slerp(imageToRotate.transform.localRotation, originalRotation, t / duration);
            yield return null;
        }
        transform.GetComponent<Button>().interactable = true;
    }
}
