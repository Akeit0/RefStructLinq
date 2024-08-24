namespace RefStructLinq;

public interface IRefStructEnumerator<out TElement,TRefStructEnumerator>
    where TElement: allows ref struct
    where TRefStructEnumerator : IRefStructEnumerator<TElement,TRefStructEnumerator>, allows ref struct
{
    
    
    public TRefStructEnumerator GetEnumerator();
    TElement Current { get; }
    bool MoveNext();
    void Dispose();
}