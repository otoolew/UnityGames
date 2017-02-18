using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITakeDamage {
    void TakeDamage(int amount);
}
public interface IMove
{
    void Move(float h, float v);
}
public interface IShoot
{
    void Shoot();
}
public interface IHeal<T>
{
    void Heal(T damageTaken);
}
public interface ICollectable
{
    void OnCollect();
}
public interface IThrow<T>
{
    void Throw();
}

