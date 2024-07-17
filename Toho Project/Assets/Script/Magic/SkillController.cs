using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillController : MonoBehaviour
{
    [SerializeField] private List<Skill> _skills;
    private GameObject _emptyGO;

    [SerializeField] private Transform firePoint;

    [SerializeField] private Image _skill1;
    float timer1;
    [SerializeField] private Image _skill2;
    float timer2;
    [SerializeField] private Image _skill3;
    float timer3;
    [SerializeField] private Image _ultimate;
    float timer4;

    Vector2 spawnPos;

    void Start()
    {
        _emptyGO = FindFirstObjectByType<Test>().gameObject;
    }

    void Update()
    {
        spawnPos = FindFirstObjectByType<Rotation>().spawnPos;

        timer1 -= Time.deltaTime;
        timer2 -= Time.deltaTime;
        timer3 -= Time.deltaTime;
        timer4 -= Time.deltaTime;

        _skill1.fillAmount = timer1 / _skills[0]._skillCd;
        //_skill2.fillAmount = timer2 / _skills[1]._skillCd;
        //_skill3.fillAmount = timer3 / _skills[2]._skillCd;
        _ultimate.fillAmount = timer4 / _skills[3]._skillCd;

        if (Input.GetKeyDown(KeyCode.Z) && timer1 <= 0f)
        {
            for (int i = 0; i < _skills[0]._amount; i++)
            {
                GameObject skill = Instantiate(_skills[0]._skill, transform.position, Quaternion.identity);
                skill.transform.parent = _emptyGO.transform;
            }
            timer1 = _skills[0]._skillCd;
        }
        if (Input.GetKeyDown(KeyCode.X) && timer2 <= 0f)
        {

            timer2 = _skills[1]._skillCd;
        }
        if (Input.GetKeyDown(KeyCode.C) && timer3 <= 0f)
        {
            for (int i = 0; i < _skills[2]._amount; i++)
            {
                GameObject skill = Instantiate(_skills[2]._skill, spawnPos, firePoint.rotation);
            }
            timer3 = _skills[2]._skillCd;
        }
        if (Input.GetKeyDown(KeyCode.E) && timer4 <= 0f)
        {
            for (int i = 0; i < _skills[3]._amount; i++)
            {
                Invoke("SpawnUltimate",i * 0.3f);
            }
            timer4 = _skills[3]._skillCd;
        }
    }

    void SpawnUltimate()
    {
        Instantiate(_skills[3]._skill, transform.position, Quaternion.identity);
    }

}

[System.Serializable]
public class Skill
{
    public GameObject _skill;
    public float _skillCd;
    public int _amount;
}
