namespace RefStructLinq;


public readonly ref struct RefStructIterator<TElement,  TEnumerator>(TEnumerator enumerable)
    where TElement : allows ref struct
    where TEnumerator : IRefStructEnumerator<TElement,TEnumerator>, allows ref struct
{
    readonly TEnumerator enumerable = enumerable;
    public TEnumerator GetEnumerator() => enumerable.GetEnumerator();
}
