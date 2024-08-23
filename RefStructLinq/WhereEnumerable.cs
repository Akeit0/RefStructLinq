namespace RefStructLinq;

public ref struct WhereEnumerable<T, TEnumerable, TEnumerator>(in TEnumerable inner,Func<T, bool> predicate) : IRefStructEnumerable<T, WhereEnumerator<T, TEnumerator>>
    where TEnumerator : struct, IRefStructEnumerator<T>, allows ref struct
    where TEnumerable : IRefStructEnumerable<T, TEnumerator>, allows ref struct
    where T : allows ref struct
{

    TEnumerable inner = inner;
    public WhereEnumerator<T, TEnumerator> GetEnumerator() 
        => new(inner.GetEnumerator(), predicate);
}