namespace RefStructLinq;

public  ref struct ReadOnlySpanEnumerator<T>(ReadOnlySpan<T> span): IRefStructEnumerator<T>
{
    readonly ReadOnlySpan<T> span=span;
    int index=-1;

    public T Current => span[index];

    public bool MoveNext() => ++index < span.Length;

    public void Dispose() { }
}