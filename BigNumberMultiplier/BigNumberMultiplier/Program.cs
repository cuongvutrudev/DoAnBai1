using System;
using System.Collections.Generic;
using System.Text;

public class BigNumberMultiplier
{
    public static string Multiply(string num1, string num2)
    {
        // Chuyển đổi chuỗi số thành danh sách chữ số
        List<int> digits1 = ConvertToDigits(num1);
        List<int> digits2 = ConvertToDigits(num2);

        // Tạo danh sách chứa các kết quả từng vị trí
        List<int> result = new List<int>();

        // Nhân từng chữ số của num1 với num2
        for (int i = digits1.Count - 1; i >= 0; i--)
        {
            for (int j = digits2.Count - 1; j >= 0; j--)
            {
                int product = digits1[i] * digits2[j];

                // Thêm kết quả vào danh sách
                int index = digits1.Count - 1 - i + digits2.Count - 1 - j;
                while (index >= result.Count)
                {
                    result.Add(0);
                }
                result[index] += product;
            }
        }

        // Xử lý việc nhớ (carry) khi cộng các chữ số
        int carry = 0;
        for (int i = 0; i < result.Count; i++)
        {
            result[i] += carry;
            carry = result[i] / 10;
            result[i] %= 10;
        }
        if (carry > 0)
        {
            result.Add(carry);
        }

        // Chuyển đổi danh sách chữ số thành chuỗi kết quả
        return ConvertToString(result);
    }

    private static List<int> ConvertToDigits(string num)
    {
        List<int> digits = new List<int>();
        for (int i = num.Length - 1; i >= 0; i--)
        {
            digits.Add(num[i] - '0');
        }
        return digits;
    }

    private static string ConvertToString(List<int> digits)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = digits.Count - 1; i >= 0; i--)
        {
            sb.Append(digits[i]);
        }
        return sb.ToString();
    }
    static void Main(string[] args)
    {
        string num1 = "12345678901234567890";
        string num2 = "98765432109876543210";
        Console.WriteLine("So thu nhat : 12345678901234567890");
        Console.WriteLine("So thu hai :  98765432109876543210");
        string result = BigNumberMultiplier.Multiply(num1, num2);
        Console.WriteLine(result); // Output: "1219326876543209876543209876543210"
    }
}

