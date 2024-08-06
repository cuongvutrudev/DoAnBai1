using System;

class MergeSortExample
{
    // Hàm để hợp nhất hai mảng con arr[l..m] và arr[m+1..r]
    static void Merge(int[] arr, int left, int mid, int right)
    {
        // Tìm kích thước của hai mảng con cần hợp nhất
        int n1 = mid - left + 1;
        int n2 = right - mid;

        // Tạo các mảng tạm thời
        int[] L = new int[n1];
        int[] R = new int[n2];

        // Sao chép dữ liệu vào các mảng tạm thời
        Array.Copy(arr, left, L, 0, n1);
        Array.Copy(arr, mid + 1, R, 0, n2);

        // Chỉ số ban đầu của hai mảng con
        int i = 0, j = 0;

        // Chỉ số ban đầu của mảng hợp nhất
        int k = left;

        while (i < n1 && j < n2)
        {
            if (L[i] <= R[j])
            {
                arr[k] = L[i];
                i++;
            }
            else
            {
                arr[k] = R[j];
                j++;
            }
            k++;
        }

        // Sao chép các phần tử còn lại của L[], nếu có
        while (i < n1)
        {
            arr[k] = L[i];
            i++;
            k++;
        }

        // Sao chép các phần tử còn lại của R[], nếu có
        while (j < n2)
        {
            arr[k] = R[j];
            j++;
            k++;
        }
    }

    // Hàm chính thực hiện MergeSort
    static void MergeSort(int[] arr, int left, int right)
    {
        if (left < right)
        {
            // Tìm điểm giữa
            int mid = left + (right - left) / 2;

            // Gọi đệ quy cho nửa đầu và nửa sau
            MergeSort(arr, left, mid);
            MergeSort(arr, mid + 1, right);

            // Hợp nhất hai nửa đã sắp xếp
            Merge(arr, left, mid, right);
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        int[] arr = { 12, 11, 13, 5, 6, 7 };
        Console.WriteLine("Mảng ban đầu:");
        Console.WriteLine(string.Join(" ", arr));

        MergeSort(arr, 0, arr.Length - 1);

        Console.WriteLine("\nMảng đã sắp xếp:");
        Console.WriteLine(string.Join(" ", arr));
    }
}

