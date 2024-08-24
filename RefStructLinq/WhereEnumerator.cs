namespace RefStructLinq;

public ref struct WhereEnumerator<T, TEnumerator>(TEnumerator enumerator, Func<T, bool> predicate) : IRefStructEnumerator<T,WhereEnumerator<T, TEnumerator>>
    where T : allows ref struct
    where TEnumerator : IRefStructEnumerator<T,TEnumerator>, allows ref struct
{
    TEnumerator enumerator = enumerator;


    public readonly WhereEnumerator<T, TEnumerator> GetEnumerator()=>
        new(enumerator.GetEnumerator(), predicate);

    public T Current => enumerator.Current;

    public bool MoveNext()
    {
        while (enumerator.MoveNext())
            if (predicate(enumerator.Current))
                return true;
            
        return false;
    }

    public void Dispose() => enumerator.Dispose();
}