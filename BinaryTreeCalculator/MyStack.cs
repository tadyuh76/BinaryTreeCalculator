namespace BinaryTreeCalculator;

// Lớp MyStack sử dụng generic T để quản lý kiểu dữ liệu
public class MyStack<T>
{
    // Lớp Node để đại diện cho từng phần tử trong stack
    private class Node
    {
        public T Data { get; } // Dữ liệu của node
        public Node? Next { get; } // Con trỏ tới node tiếp theo

        public Node(T data, Node? next)
        {
            Data = data; // Gán giá trị dữ liệu
            Next = next; // Gán giá trị node tiếp theo
        }
    }

    private Node? top; // Phần tử ở trên cùng của stack
    private int count; // Số lượng phần tử trong stack

    // Hàm khởi tạo stack, ban đầu top là null và count = 0
    public MyStack()
    {
        top = null;
        count = 0;
    }

    /// <summary>
    /// Thêm một phần tử vào stack.
    /// </summary>
    /// <param name="item">Phần tử cần thêm vào stack.</param>
    public void Push(T item)
    {
        top = new Node(item, top); // Tạo node mới và đặt nó làm top
        count++; // Tăng số lượng phần tử
    }

    /// <summary>
    /// Loại bỏ và trả về phần tử ở trên cùng của stack.
    /// </summary>
    /// <returns>Phần tử trên cùng của stack.</returns>
    /// <exception cref="InvalidOperationException">Ném lỗi khi stack rỗng.</exception>
    public T Pop()
    {
        if (IsEmpty()) // Kiểm tra stack có rỗng không
            throw new InvalidOperationException("Stack is empty.");

        T item = top!.Data; // Lấy dữ liệu từ top
        top = top.Next; // Di chuyển top tới phần tử tiếp theo
        count--; // Giảm số lượng phần tử
        return item; // Trả về dữ liệu
    }

    /// <summary>
    /// Lấy phần tử trên cùng của stack mà không xóa nó.
    /// </summary>
    /// <returns>Phần tử trên cùng của stack.</returns>
    /// <exception cref="InvalidOperationException">Ném lỗi khi stack rỗng.</exception>
    public T Peek()
    {
        if (IsEmpty()) // Kiểm tra stack có rỗng không
            throw new InvalidOperationException("Stack is empty.");

        return top!.Data; // Trả về dữ liệu của top
    }

    /// <summary>
    /// Kiểm tra xem stack có rỗng không.
    /// </summary>
    /// <returns>True nếu stack rỗng, ngược lại false.</returns>
    public bool IsEmpty()
    {
        return count == 0; // Stack rỗng khi count = 0
    }

    /// <summary>
    /// Lấy số lượng phần tử trong stack.
    /// </summary>
    public int Count => count; // Trả về số lượng phần tử
}
