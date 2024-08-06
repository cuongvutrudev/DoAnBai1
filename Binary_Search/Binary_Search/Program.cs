using System;

class BinarySearchExample
{
    // Hàm tìm kiếm nhị phân
    static int BinarySearch(int[] arr, int left, int right, int target)
    {
        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            // Kiểm tra nếu target nằm tại mid
            if (arr[mid] == target)
                return mid;

            // Nếu target lớn hơn, bỏ qua nửa bên trái
            if (arr[mid] < target)
                left = mid + 1;

            // Nếu target nhỏ hơn, bỏ qua nửa bên phải
            else
                right = mid - 1;
        }

        // Nếu không tìm thấy target
        return -1;
    }

    static void Main()
    {
        // Mảng cần tìm kiếm (đã được sắp xếp)
        int[] arr = {1,3,5,7,9,11,13,15};
        Console.WriteLine("Phan tu co trong mang: 1,3,5,7,9,11,13,15");
        Console.WriteLine("Nhap phan tu can tim: ");
        string input = Console.ReadLine();
        int n = arr.Length;
        int target = Convert.ToInt32(input);

        // Gọi hàm tìm kiếm nhị phân
        int result = BinarySearch(arr, 0, n - 1, target);

        // Kiểm tra kết quả
        if (result == -1)
            Console.WriteLine("Phan tu khong co trong mang");
        else
            Console.WriteLine("Phan tu co mat tai chi so " + result);
        Console.ReadKey();
    }
}
