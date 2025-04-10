namespace Basic.Classes;

public class MyList<T>
{
    // Array interna que armazena os elementos da lista
    private T[] List { get; set; } = [];

    // Propriedade que retorna o tamanho atual da lista
    public int Size => List.Length;

    // Construtor padrão (cria lista vazia)
    public MyList() { }

    // Construtor que permite criar a lista a partir de uma array
    public MyList(T[] list)
    {
        List = [..list];
    }

    // Adiciona um elemento no início da lista
    public T[] Prepend(T obj)
    {
        List = [obj, ..List];
        return List;
    }

    // Adiciona um elemento no final da lista
    public T[] Append(T obj)
    {
        List = [..List, obj];
        return List;
    }

    // Insere um elemento em uma posição específica da lista
    public void Insert(int index, T obj)
    {
        // Verifica se o índice é válido
        if (index < 0 || index > Size) throw new IndexOutOfRangeException();

        // Divide o array, insere o elemento no meio
        List = [..List.Take(index), obj, ..List.Skip(index)];
    }

    // Remove o primeiro elemento igual ao valor passado
    public bool Remove(T obj)
    {
        for (int i = 0; i < Size; i++)
        {
            if (List[i]!.Equals(obj))
            {
                // Remove o elemento na posição i
                List = [..List.Take(i), ..List.Skip(i + 1)];
                return true;
            }
        }

        return false;
    }

    // Remove o elemento no índice especificado
    public void RemoveAt(int index)
    {
        if (index < 0 || index > Size - 1) throw new IndexOutOfRangeException();

        List = [..List.Take(index), ..List.Skip(index + 1)];
    }

    // Remove todos os elementos da lista
    public void Clear()
    {
        List = [];
    }

    // Retorna o índice do primeiro elemento igual ao valor passado
    public int IndexOf(T obj)
    {
        for (int i = 0; i < Size; i++)
            if (List[i]!.Equals(obj)) return i;

        return -1;
    }

    // Verifica se a lista contém um determinado elemento
    public bool Contains(T obj)
    {
        foreach (var item in List)
            if (item!.Equals(obj)) return true;

        return false;
    }

    // Indexador: permite acessar a lista como se fosse um array (ex: list[2])
    public T this[int index]
    {
        get { return List[index]; }
        set { List[index] = value; }
    }

    // Retorna uma cópia da array interna
    public T[] ToArray()
    {
        T[] array = new T[Size];
        Array.Copy(List, array, Size);
        return array;
    }

    // Retorna uma string representando a lista
    public override string ToString()
    {
        return "[ " + string.Join(", ", List) + " ]";
    }
}
