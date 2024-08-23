namespace RefStructLinq;

public interface IRefStructEnumerator<out TElement>
    where TElement: allows ref struct
{
    TElement Current { get; }
    bool MoveNext();
    void Dispose();
}