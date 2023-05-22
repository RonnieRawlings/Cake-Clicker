// Author - Ronnie Rawlings.

using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EggHoverAnim : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public float rotationAmount = 15f, rotationSpeed = 1f, rotationPause = 0.5f;

    private Image imageToRotate;
    private Quaternion originalRotation;
    private Coroutine rotateCoroutine;

    void Start()
    {
        imageToRotate = GetComponent<Image>();
        originalRotation = imageToRotate.transform.localRotation;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        rotateCoroutine = StartCoroutine(RotateCoroutine());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopRotate();
    }

    public void StopRotate()
    {
        if (rotateCoroutine != null)
        {
            StopCoroutine(rotateCoroutine);
            rotateCoroutine = null;
            imageToRotate.transform.localRotation = originalRotation;
        }
    }

    private IEnumerator RotateCoroutine()
    {
        while (true)
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
    }
}
