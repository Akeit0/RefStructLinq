namespace RefStructLinq;

public interface IRefStructEnumerable<TElement, out TEnumerator>
    where TElement: allows ref struct
    where TEnumerator  : IRefStructEnumerator<TElement>, allows ref struct
{
    TEnumerator GetEnumerator();
}


public readonly ref struct RefStructEnumerable<TElement, TEnumerable, TEnumerator>(TEnumerable enumerable) : IRefStructEnumerable<TElement, TEnumerator>
    where TElement : allows ref struct
    where TEnumerable : IRefStructEnumerable<TElement, TEnumerator>, allows ref struct
    where TEnumerator : IRefStructEnumerator<TElement>, allows ref struct
{
    public readonly TEnumerable Enumerable = enumerable;
    
     public TEnumerator GetEnumerator() => Enumerable.GetEnumerator();
}
