// 日本語対応
using UnityEngine;

public class DirectionUtility
{
    public static Quaternion GetRotationFromDirection(Vector2 input)
    {
        if (input == Vector2.up)
        {
            return Quaternion.Euler(0f, 0f, 0f);
        }
        if (input == Vector2.right)
        {
            return Quaternion.Euler(0f, 90f, 0f);
        }
        if (input == Vector2.down)
        {
            return Quaternion.Euler(0f, 180f, 0f);
        }
        if (input == Vector2.left)
        {
            return Quaternion.Euler(0f, 270f, 0f);
        }
        Debug.Log($"{nameof(input)} は無効です。");
        return Quaternion.identity;
    }

    public static Vector2 GetClosestDirection(Vector2 startPoint, Vector2 endPoint)
    {
        return CorrectToClosestDirection(endPoint - startPoint);
    }

    public static Vector2 CorrectToClosestDirection(Vector2 inputVector)
    {
        // 入力ベクトルと各方向ベクトルとの内積を計算
        float dotUp = Vector2.Dot(inputVector, Vector2.up);
        float dotDown = Vector2.Dot(inputVector, Vector2.down);
        float dotRight = Vector2.Dot(inputVector, Vector2.right);
        float dotLeft = Vector2.Dot(inputVector, Vector2.left);

        // 最も内積が大きい方向を選択
        if (dotUp > dotDown && dotUp > dotRight && dotUp > dotLeft)
        {
            return Vector2.up;
        }
        else if (dotDown > dotUp && dotDown > dotRight && dotDown > dotLeft)
        {
            return Vector2.down;
        }
        else if (dotRight > dotUp && dotRight > dotDown && dotRight > dotLeft)
        {
            return Vector2.right;
        }
        else
        {
            return Vector2.left;
        }
    }
}