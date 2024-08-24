namespace RefStructLinq;


public readonly ref struct RefStructIterator<TElement,  TEnumerator>(TEnumerator enumerator)
    where TElement : allows ref struct
    where TEnumerator : IRefStructEnumerator<TElement,TEnumerator>, allows ref struct
{
    public  readonly TEnumerator Enumerator = enumerator;
    
    public  TEnumerator GetEnumerator() => Enumerator.GetEnumerator();
}
