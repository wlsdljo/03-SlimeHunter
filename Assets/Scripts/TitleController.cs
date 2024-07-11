using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleController : MonoBehaviour
{
    [SerializeField] private Text pressText;    //�����Ÿ� PressText ������Ʈ
    [SerializeField] private float fadingInterval;  // �����Ÿ� �ð� ����
    private float elapsedTime;  // ���� �ð�
    private bool isFadeIn = false;  // FadeIn �� ����?

    void Start()
    {
         
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (isFadeIn)
        {
            float alpha = Mathf.Lerp(0.0f, 1.0f, elapsedTime / fadingInterval);
            SetTextAlpha(alpha);

            if (elapsedTime > fadingInterval)
            {
                isFadeIn = false;
                elapsedTime = 0.0f;
            }
        }
        else
        {
            float alpha = Mathf.Lerp(1.0f, 0.0f, elapsedTime / fadingInterval);
            SetTextAlpha(alpha);
            if (elapsedTime > fadingInterval)
            {
                isFadeIn = true;
                elapsedTime = 0.0f;
            }
        }
    }

    // Text�� ������ �������ִ� �޼���
    private void SetTextAlpha(float alpha)
    {
        Color color = pressText.color;
        color.a = alpha;
        pressText.color = color;
    }

    // ���ηָ��� �ε��ϴ� �޼���
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main");
    }
}
