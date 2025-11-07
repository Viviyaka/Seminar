namespace DU_3
{
    namespace LinkedListAssignment
    {
        public class Node
        {
            public int Value;
            public Node Next;

            public Node(int value)
            {
                Value = value;
                Next = null;
            }
        }

        public class LinkedList
        {
            public Node Head;

            public void AddLast(int value)
            {
                Node newNode = new Node(value);
                if (Head == null)
                {
                    Head = newNode;
                    return;
                }

                Node current = Head;
                while (current.Next != null)
                    current = current.Next;

                current.Next = newNode;
            }


            public void RemoveFromEnd()
            {
                if (Head == null)
                    return;

                if (Head.Next == null)
                {
                    Head = null;
                    return;
                }

                Node current = Head;
                while (current.Next.Next != null)
                    current = current.Next;

                current.Next = null;
            }


            public bool Exist(int value)
            {
                Node current = Head;
                while (current != null)
                {
                    if (current.Value == value)
                        return true;
                    current = current.Next;
                }
                return false;
            }

            public void RemoveAll(int value)
            {
                while (Head != null && Head.Value == value)
                {
                    Head = Head.Next;
                }

                Node current = Head;
                while (current != null && current.Next != null)
                {
                    if (current.Next.Value == value)
                        current.Next = current.Next.Next;
                    else
                        current = current.Next;
                }
            }

            public static LinkedList Intersection(LinkedList list1, LinkedList list2)
            {
                LinkedList result = new LinkedList();

                Node current1 = list1.Head;
                while (current1 != null)
                {
                    if (list2.Exist(current1.Value) && !result.Exist(current1.Value))
                    {
                        result.AddLast(current1.Value);
                    }
                    current1 = current1.Next;
                }

                return result;
            }

            public static LinkedList Union(LinkedList list1, LinkedList list2)
            {
                LinkedList result = new LinkedList();

                Node current1 = list1.Head;
                while (current1 != null)
                {
                    if (!result.Exist(current1.Value))
                        result.AddLast(current1.Value);
                    current1 = current1.Next;
                }

                Node current2 = list2.Head;
                while (current2 != null)
                {
                    if (!result.Exist(current2.Value))
                        result.AddLast(current2.Value);
                    current2 = current2.Next;
                }

                return result;
            }

            public static LinkedList AddNumbers(LinkedList num1, LinkedList num2)
            {
                Node n1 = num1.Head;
                Node n2 = num2.Head;
                LinkedList result = new LinkedList();
                Node last = null;
                int carry = 0;

                while (n1 != null || n2 != null || carry > 0)
                {
                    int sum = carry;
                    if (n1 != null) { sum += n1.Value; n1 = n1.Next; }
                    if (n2 != null) { sum += n2.Value; n2 = n2.Next; }

                    carry = sum / 10;
                    Node newNode = new Node(sum % 10);

                    if (result.Head == null)
                    {
                        result.Head = newNode;
                        last = newNode;
                    }
                    else
                    {
                        last.Next = newNode;
                        last = newNode;
                    }
                }

                return result;
            }

            public void Print()
            {
                Node current = Head;
                while (current != null)
                {
                    Console.Write(current.Value + " ");
                    current = current.Next;
                }
                Console.WriteLine();
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                LinkedList list1 = new LinkedList();
                list1.AddLast(5);
                list1.AddLast(2);
                list1.AddLast(8);
                list1.AddLast(2);

                Console.WriteLine("Původní seznam:");
                list1.Print();

                list1.RemoveFromEnd();
                Console.WriteLine("Po RemoveFromEnd:");
                list1.Print();

                Console.WriteLine("Existuje číslo 2? " + list1.Exist(2));
                Console.WriteLine("Existuje číslo 9? " + list1.Exist(9));

                list1.RemoveAll(2);
                Console.WriteLine("Po RemoveAll(2):");
                list1.Print();

                LinkedList list2 = new LinkedList();
                list2.AddLast(3);
                list2.AddLast(5);
                list2.AddLast(9);

                Console.WriteLine("\nSeznam 1:");
                list1.Print();
                Console.WriteLine("Seznam 2:");
                list2.Print();

                LinkedList intersection = LinkedList.Intersection(list1, list2);
                Console.WriteLine("Průnik:");
                intersection.Print();

                LinkedList union = LinkedList.Union(list1, list2);
                Console.WriteLine("Sjednocení:");
                union.Print();

                LinkedList num1 = new LinkedList();
                num1.AddLast(7);
                num1.AddLast(1);
                num1.AddLast(6);

                LinkedList num2 = new LinkedList();
                num2.AddLast(5);
                num2.AddLast(9);
                num2.AddLast(2);

                LinkedList sum = LinkedList.AddNumbers(num1, num2);
                Console.WriteLine("\nSčítání dlouhých čísel (617 + 295):");
                sum.Print();
            }
        }
    }
}