using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathWall : MonoBehaviour
{
    public Transform _wall;
    public Transform _checkpoints;
    public float _speed = 10f;

    int indexed = 0;
    float totalDist = 0;

    Transform[] checkp;
    Transform actualCheck;

    void Start()
    {
        checkp = new Transform[_checkpoints.childCount];

        for (int i = 0; i < checkp.Length; i++)
        {
            checkp[i] = _checkpoints.GetChild(i);
        }

        actualCheck = checkp[indexed];
    }

    void Update()
    {
        actualCheck = checkp[indexed];
        float dist = Vector3.Distance(_wall.position, actualCheck.position);

        if (dist < 0.1f)
        {
            if (indexed < checkp.Length - 1)
                indexed++;
        }
        _wall.LookAt(checkp[indexed]);
        _wall.Translate(-_wall.right * _speed);

        if (indexed == checkp.Length - 1)
        {
            _speed = 0;
        }
        //_wall.position = Vector3.Lerp(_wall.position, checkp[indexed].position, _speed);

        //_wall.Translate(dir * _speed, Space.World);

        /*
        Vector3 dir = _checkpoints[indexed].position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        */
    }
}
