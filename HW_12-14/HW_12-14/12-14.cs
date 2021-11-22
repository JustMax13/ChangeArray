class Program
{
    static void Main()
    {
        int[] myArray = {2 ,-4 ,6 ,0 ,-3 ,-8 ,19 ,10 ,0}; // допустим этот массив пришел с базы данных
        myArray ??= new int[0];
        if (myArray.Length == 0)
        {
            Console.WriteLine("Внимание!\n Массив пришел пустой\n\n");
        }
        
        HowToChangeTheArray(ref myArray);
    }
    static void HowToChangeTheArray(ref int[] volatibleArray)
    {
        
        for (;;)
        {

            Console.WriteLine(
           "Как ты хочешь изменить массив?:" +
            "\n\t1 - Изменитить размер массива;" +
            "\n\t2 - Добавить елемент массива;" +
            "\n\t3 - Удалить елемент массива;"
            );
                       
            char choice = Console.ReadKey(true).KeyChar;
            if (choice == '1' || choice == '2' || choice == '3')
            {
                switch (choice)
                {
                    case '1':
                        Console.WriteLine("Сколько елементов в массиве ты хочешь сделать?" +
                            "\n\n*Предосторожность: есть массив уменшить, то уберуться елементы массива с конца," +
                            " если добавить количество елементов, то пустые елементы будут заполнены нулями."
                            );
                        int length = 0;
                        for (bool ifnum = false; ifnum == false ;)
                        {
                            Console.WriteLine("Введите число: ");
                            ifnum = int.TryParse(Console.ReadLine(), out length);
                        }
                        Resize(ref volatibleArray, length);
                        break;
                    case '2':
                        Console.WriteLine("\nПод каким индексом ты хочешь добавить елемент?" +
                            "\nИндексы массива начинаються с 0 и заканчиваються " + volatibleArray.Length);

                        int index = 0;
                        for (bool ifnum = false; ifnum == false;)
                        {
                            Console.WriteLine("Введите индекс: ");
                            ifnum = int.TryParse(Console.ReadLine(), out index);
                            if (index > volatibleArray.Length)
                            {
                                ifnum = false;
                            }
                        }

                        int number = 0;
                        Console.WriteLine("\nКакое число ты хочешь поместить в елемент? ");
                        for (bool ifnum = false; ifnum == false;)
                        {
                            Console.WriteLine("Введите число: ");
                            ifnum = int.TryParse(Console.ReadLine(), out number);
                        }

                        if (index != (volatibleArray.Length))
                        {
                            Console.WriteLine("\nЖелаете:" +
                            $"\n1 - сдвинуть елемент который находился под индексом {index}" +
                            "\n\n2 - удалить прошлый елемент");
                            char moveOrRemove = ' ';
                            for (; moveOrRemove != '1' && moveOrRemove != '2';)
                            {
                                moveOrRemove = Console.ReadKey(true).KeyChar;
                            }
                            if (moveOrRemove == '1')
                            {
                                addElement(ref volatibleArray, index, number);
                            }
                            else
                            {
                                volatibleArray[index] = number;
                            }
                            break;
                        }
                        else
                        {
                            addElement(ref volatibleArray, index, number);

                            break;
                        }
                    case '3':
                        Console.WriteLine("\nПод каким индексом ты хочешь удалить елемент?" +
                            "\nИндексы массива начинаються с 0 и заканчиваються " + (volatibleArray.Length - 1));

                        index = 0;
                        for (bool ifnum = false; ifnum == false;)
                        {
                            Console.WriteLine("Введите индекс: ");
                            ifnum = int.TryParse(Console.ReadLine(), out index);
                            if (index > volatibleArray.Length - 1)
                            {
                                ifnum = false;
                            }
                        }
                        removeIndex(ref volatibleArray, index);

                        break;
                }
                Console.WriteLine("Хочешь еще как либо изменить массив?:" +
                    "\n1 - Да" +
                    "\n2 - Нет"
                    );
                char YesNo = '0';
                while (YesNo != '1' && YesNo != '2')
                {
                    YesNo = Console.ReadKey(true).KeyChar;
                }
                if (YesNo == '1')
                {
                    Console.Clear();
                    
                    continue;
                }
                else
                {
                    break;
                }
            }
            else
            {
                Console.Clear();
            }
        }
    }
    static void Resize(ref int[] ResizeArray , int length)
    {
        int[] SaveArray = ResizeArray;
        ResizeArray = new int[length];
        for (int i = 0; i < ResizeArray.Length && i < SaveArray.Length ; i++)
        {
            ResizeArray[i] = SaveArray[i];
        }
    }
    
    static void addElement(ref int[] volatibleArray, int index, int number)
    {
        int[] SaveArray = volatibleArray;
        volatibleArray = new int[volatibleArray.Length + 1];
        int i = 0;
        for (; i < index; i++)
        {
            volatibleArray[i] = SaveArray[i];
        }

        volatibleArray[index] = number;

        for (; i < SaveArray.Length; i++)
        {
            volatibleArray[i+1] = SaveArray[i];
        }
    }

    static void removeIndex(ref int[] myArray, int index)
    {
        int[] SaveArray = myArray;
        myArray = new int[myArray.Length - 1];

        int i = 0;
        for (; i < index; i++)
        {
            myArray[i] = SaveArray[i];
        }
        for (; i < myArray.Length; i++)
        {
            myArray[i] = SaveArray[i+1];
        }
    }
}